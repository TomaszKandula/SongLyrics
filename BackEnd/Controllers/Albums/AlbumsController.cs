using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Logic;
using BackEnd.Helpers;
using BackEnd.AppLogger;
using BackEnd.Controllers.Albums.Models;

namespace BackEnd.Controllers.Albums
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "ResponseCache")]
    public class AlbumsController : ControllerBase
    {

        private readonly IAppLogger    FAppLogger;
        private readonly ILogicContext FLogicContext;

        public AlbumsController(IAppLogger AAppLogger, ILogicContext ALogicContext)
        {
            FAppLogger    = AAppLogger;
            FLogicContext = ALogicContext;
        }

        /// <summary>
        /// Returns all albums (or given band album) from the entire collection.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/albums/?AId={id}
        [HttpGet]
        public async Task<IActionResult> GetAlbums([FromQuery] int? AId)
        {

            var LResponse = new ReturnAlbums();
            try
            {
                var LResult = await FLogicContext.Albums.GetAlbums(AId);

                if (!LResult.Any())
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptyAlbumList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptyAlbumList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/albums/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(204, LResponse);
                }

                LResponse.Albums = LResult;
                LResponse.IsSucceeded = true;
                return StatusCode(200, LResponse);

            }
            catch (Exception LException)
            {
                LResponse.Error.ErrorCode = LException.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(LException.InnerException?.Message) ? LException.Message : $"{LException.Message} ({LException.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/albums/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns specific album from the entire collection.
        /// </summary>
        /// <param name="AId"></param>
        /// <returns></returns>
        // GET api/v1/albums/{AId}/
        [HttpGet("{AId}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int AId)
        {

            var LResponse = new ReturnAlbums();
            try
            {

                var LResult = await FLogicContext.Albums.GetAlbum(AId);

                if (LResult.Count == 0)
                {
                    LResponse.Error.ErrorCode = Constants.Errors.NoAlbumFound.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.NoAlbumFound.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/albums/{AId}. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(204, LResponse);
                }

                LResponse.Albums = LResult;
                LResponse.IsSucceeded = true;
                return StatusCode(200, LResponse);

            }
            catch (Exception LException)
            {
                LResponse.Error.ErrorCode = LException.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(LException.InnerException?.Message) ? LException.Message : $"{LException.Message} ({LException.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/albums/{AId} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}
