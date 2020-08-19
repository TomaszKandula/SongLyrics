using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Logic;
using BackEnd.Helpers;
using BackEnd.Models.Json;
using BackEnd.Utilities.AppLogger;

namespace BackEnd.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "ResponseCache")]
    public class SongsController : ControllerBase
    {

        private readonly IAppLogger    FAppLogger;
        private readonly ILogicContext FLogicContext;

        public SongsController(IAppLogger AAppLogger, ILogicContext ALogicContext)
        {
            FAppLogger = AAppLogger;
            FLogicContext = ALogicContext;
        }

        /// <summary>
        /// Returns all songs from the entire collection or songs belonging to given album.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/songs/?AlbumId={id}
        [HttpGet]
        public async Task<IActionResult> GetSongs([FromQuery] int? AlbumId)
        {

            var LResponse = new ReturnSongs();
            try
            {

                var LResult = await FLogicContext.Songs.GetAlbumSongs(AlbumId);

                if (!LResult.Any())
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptySongList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptySongList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/songs/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Songs = LResult;
                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/songs/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns selected song from the entire collection.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/songs/{Id}/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int Id)
        {

            var LResponse = new ReturnSongs();
            try
            {

                var LResult = await FLogicContext.Songs.GetSong(Id);

                if (!LResult.Any())
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptySongList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptySongList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/songs/{Id}. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Songs = LResult;
                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/songs/{Id} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}
