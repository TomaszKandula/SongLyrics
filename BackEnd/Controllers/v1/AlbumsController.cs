﻿using System;
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
        // GET api/v1/albums/?BandId={id}
        [HttpGet]
        public async Task<IActionResult> GetAlbums([FromQuery] int? BandId)
        {

            var LResponse = new ReturnAlbums();
            try
            {
                var LResult = await FLogicContext.Albums.GetAlbums(BandId);

                if (!LResult.Any())
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptyAlbumList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptyAlbumList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/albums/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Albums = LResult;
                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/albums/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns specific album from the entire collection.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // GET api/v1/albums/{id}/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int Id)
        {

            var LResponse = new ReturnAlbums();
            try
            {

                var LResult = await FLogicContext.Albums.GetAlbum(Id);

                if (LResult.Count == 0)
                {
                    LResponse.Error.ErrorCode = Constants.Errors.NoAlbumFound.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.NoAlbumFound.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/albums/{Id}. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Albums = LResult;
                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/albums/{Id} | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}