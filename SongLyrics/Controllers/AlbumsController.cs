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
    public class AlbumsController : __BaseController
    {
        public AlbumsController(IAppLogger AAppLogger, ILogicContext ALogicContext) 
            : base(AAppLogger, ALogicContext) { }

        /// <summary>
        /// Returns all albums (or given band album) from the entire collection.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Returns all albums (or given band album) from the entire collection.", type: typeof(ReturnAlbumsDto))]
        // GET api/v1/albums/?ArtistId={id}
        [HttpGet]
        // ReSharper disable once InconsistentNaming for query string
        public async Task<IActionResult> GetAlbums([FromQuery] int? ArtistId)
        {
            try
            {
                var LAlbums = await FLogicContext.Albums.GetAlbums(ArtistId);
                if (LAlbums.Any())
                    return StatusCode(200, new ReturnAlbumsDto { Albums = LAlbums });
                
                FAppLogger.LogWarn(ErrorCodes.EMPTY_ALBUM_LIST);
                return StatusCode(400, new ErrorHandlerDto 
                { 
                    ErrorCode = nameof(ErrorCodes.EMPTY_ALBUM_LIST),
                    ErrorDesc = ErrorCodes.EMPTY_ALBUM_LIST
                });

            }
            catch (Exception LException)
            {
                FAppLogger.LogFatality(ControllerException.Handle(LException).ErrorDesc);
                return StatusCode(500, ControllerException.Handle(LException));
            }
        }

        /// <summary>
        /// Returns specific album from the entire collection.
        /// </summary>
        /// <param name="AId"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Returns specific album from the entire collection.", type: typeof(ReturnAlbumsDto))]
        // GET api/v1/albums/{AId}/
        [HttpGet("{AId}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int AId)
        {
            try
            {
                var LAlbum = await FLogicContext.Albums.GetAlbum(AId);
                if (LAlbum.Count != 0)
                    return StatusCode(200, new ReturnAlbumsDto { Albums = LAlbum });
                
                FAppLogger.LogWarn(ErrorCodes.NO_ALBUM_FOUND);
                return StatusCode(400, new ErrorHandlerDto
                {
                    ErrorCode = nameof(ErrorCodes.NO_ALBUM_FOUND),
                    ErrorDesc = ErrorCodes.NO_ALBUM_FOUND
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
