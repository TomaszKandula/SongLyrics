using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Logic;
using BackEnd.Models.Json;
using BackEnd.Extensions.AppLogger;

namespace BackEnd.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "ResponseCache")]
    public class MusicController : ControllerBase
    {

        private readonly IAppLogger    FAppLogger;
        private readonly ILogicContext FLogicContext;

        public MusicController(IAppLogger AAppLogger, ILogicContext ALogicContext) 
        {
            FAppLogger    = AAppLogger;
            FLogicContext = ALogicContext;
        }

        /// <summary>
        /// Return all albums from the entire collection.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/music/albums/
        [HttpGet("albums")]
        public async Task<IActionResult> GetAlbums() 
        {

            var LResponse = new ReturnAlbums();
            try
            {
                LResponse.Albums = await FLogicContext.Music.GetAlbums(null);
                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/music/albums/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Return specific album from the entire collection.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // GET api/v1/music/albums/{id}/
        [HttpGet("albums/{id}")]
        public async Task<IActionResult> GetAlbum(int Id)
        {

            var LResponse = new ReturnAlbums();
            try
            {
                LResponse.Albums = await FLogicContext.Music.GetAlbums(Id);
                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/music/albums/{Id} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Return all albums for given Band Id.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        // GET api/v1/music/albums/?BandId={id}
        [HttpGet("albums")]
        public async Task<IActionResult> GetBandAlbums([FromQuery] int BandId)
        {

            var LResponse = new ReturnAlbums();
            try
            {
                LResponse.Albums = await FLogicContext.Music.GetAlbum(BandId);
                return StatusCode(200, LResponse);
            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/music/albums/?BandId={BandId} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Return all songs from collection.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/music/songs/
        [HttpGet("songs")]
        public async Task<IActionResult> GetSongs() 
        {

            var LResponse = new ReturnSongs();
            try
            {

                return StatusCode(200, LResponse);
            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/music/songs/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Return specific song from collection.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/music/songs/{id}
        [HttpGet("songs/{id}")]
        public async Task<IActionResult> GetSongs(int Id)
        {

            var LResponse = new ReturnSongs();
            try
            {

                return StatusCode(200, LResponse);
            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/music/songs/{Id} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Return song belonging to given Album.
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns></returns>
        // GET api/v1/music/songs/?AlbumId={id}
        [HttpGet("songs")]
        public async Task<IActionResult> GetAlbumSong([FromQuery] int AlbumId)
        {

            var LResponse = new ReturnSongs();
            try
            {

                return StatusCode(200, LResponse);
            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/music/songs/?AlbumId={AlbumId} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}
