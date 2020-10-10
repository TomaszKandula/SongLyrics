using System;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.AppLogger;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Logic;
using BackEnd.Helpers;
using BackEnd.Models.Json;

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
        // GET api/v1/songs/?AId={id}
        [HttpGet]
        public async Task<IActionResult> GetSongs([FromQuery] int? AId)
        {

            var LResponse = new ReturnSongs();
            try
            {

                var LResult = await FLogicContext.Songs.GetAlbumSongs(AId);

                if (!LResult.Any())
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptySongList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptySongList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/songs/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Songs = LResult;
                LResponse.IsSucceeded = true;
                return StatusCode(200, LResponse);

            }
            catch (Exception LException)
            {
                LResponse.Error.ErrorCode = LException.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(LException.InnerException?.Message) ? LException.Message : $"{LException.Message} ({LException.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/songs/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns selected song from the entire collection.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/songs/{AId}/
        [HttpGet("{AId}")]
        public async Task<IActionResult> GetSong([FromRoute] int AId)
        {

            var LResponse = new ReturnSong();
            try
            {

                var LResult = await FLogicContext.Songs.GetSong(AId);

                if (LResult == null)
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptySongList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptySongList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/songs/{AId}. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Song = LResult;
                LResponse.IsSucceeded = true;
                return StatusCode(200, LResponse);

            }
            catch (Exception LException)
            {
                LResponse.Error.ErrorCode = LException.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(LException.InnerException?.Message) ? LException.Message : $"{LException.Message} ({LException.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/songs/{AId} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}
