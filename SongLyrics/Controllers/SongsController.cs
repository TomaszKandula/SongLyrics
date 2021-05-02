using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongLyrics.Logic;
using SongLyrics.Logger;
using SongLyrics.Exceptions;
using SongLyrics.Shared.Dto;
using SongLyrics.Shared.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace SongLyrics.Controllers
{
    public class SongsController : __BaseController
    {
        public SongsController(IAppLogger AAppLogger, ILogicContext ALogicContext) 
            : base(AAppLogger, ALogicContext) { }

        /// <summary>
        /// Returns all songs from the entire collection or songs belonging to given album.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Returns all songs from the entire collection or songs belonging to given album.", type: typeof(ReturnSongsDto))]
        // GET api/v1/songs/?AlbumId={id}
        [HttpGet]
        // ReSharper disable once InconsistentNaming for query string
        public async Task<IActionResult> GetSongs([FromQuery] int? AlbumId)
        {
            try
            {
                var LSongs = await FLogicContext.Songs.GetAlbumSongs(AlbumId);
                if (LSongs.Any())
                    return StatusCode(200, new ReturnSongsDto { Songs = LSongs });
                
                FAppLogger.LogWarn(ErrorCodes.EMPTY_SONG_LIST);
                return StatusCode(400, new ErrorHandlerDto
                {
                    ErrorCode = nameof(ErrorCodes.EMPTY_SONG_LIST),
                    ErrorDesc = ErrorCodes.EMPTY_SONG_LIST
                });
            }
            catch (Exception LException)
            {
                FAppLogger.LogFatality(ControllerException.Handle(LException).ErrorDesc);
                return StatusCode(500, ControllerException.Handle(LException));
            }
        }

        /// <summary>
        /// Returns selected song from the entire collection.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Returns selected song from the entire collection.", type: typeof(ReturnSongDto))]
        // GET api/v1/songs/{AId}/
        [HttpGet("{AId}")]
        public async Task<IActionResult> GetSong([FromRoute] int AId)
        {
            try
            {
                var LSong = await FLogicContext.Songs.GetSong(AId);
                if (LSong != null)
                    return StatusCode(200, new ReturnSongDto { Song = LSong });
                
                FAppLogger.LogWarn(ErrorCodes.EMPTY_SONG_LIST);
                return StatusCode(400, new ErrorHandlerDto
                {
                    ErrorCode = nameof(ErrorCodes.EMPTY_SONG_LIST),
                    ErrorDesc = ErrorCodes.EMPTY_SONG_LIST
                });
            }
            catch (Exception LException)
            {
                FAppLogger.LogFatality(ControllerException.Handle(LException).ErrorDesc);
                return StatusCode(500, ControllerException.Handle(LException));
            }
        }
    }
}
