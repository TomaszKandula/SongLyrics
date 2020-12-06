using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongLyrics.Logic;
using SongLyrics.Shared;
using SongLyrics.AppLogger;
using SongLyrics.Controllers.Artists.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SongLyrics.Controllers.Artists
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "ResponseCache")]
    public class ArtistsController : ControllerBase
    {

        private readonly IAppLogger    FAppLogger;
        private readonly ILogicContext FLogicContext;

        public ArtistsController(IAppLogger AAppLogger, ILogicContext ALogicContext) 
        {
            FAppLogger    = AAppLogger;
            FLogicContext = ALogicContext;
        }

        /// <summary>
        /// Returns all bands from the entire collection.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(
            statusCode: 200,
            description: "Returns all bands from the entire collection.",
            type: typeof(ReturnArtists)
        )]
        // GET api/v1/artists/
        [HttpGet]
        public async Task<IActionResult> GetArtists() 
        {

            var LResponse = new ReturnArtists();
            try
            {

                var LResult = await FLogicContext.Artists.GetArtists(null);

                if (!LResult.Any()) 
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptyBandList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptyBandList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/artists/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Artists = LResult;
                LResponse.IsSucceeded = true;
                return StatusCode(200, LResponse);

            }
            catch (Exception LException)
            {
                LResponse.Error.ErrorCode = LException.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(LException.InnerException?.Message) ? LException.Message : $"{LException.Message} ({LException.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/artists/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns list of all band members.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(
            statusCode: 200,
            description: "Returns list of all band members.",
            type: typeof(ReturnMembers)
        )]
        // GET api/v1/artists/{AId}/members/
        [HttpGet("{AId}/members/")]
        public async Task<IActionResult> GetMembers([FromRoute] int AId)
        {

            var LResponse = new ReturnMembers();
            try
            {
                
                var LResult = await FLogicContext.Artists.GetMembers(AId);

                if (!LResult.Any())
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptyMembersList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptyMembersList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/artists/{AId}/members/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Members = LResult;
                LResponse.IsSucceeded = true;
                return StatusCode(200, LResponse);
            
            }
            catch (Exception LException)
            {
                LResponse.Error.ErrorCode = LException.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(LException.InnerException?.Message) ? LException.Message : $"{LException.Message} ({LException.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/artists/{AId}/members/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns all band detail for given band (by its Id).
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(
            statusCode: 200,
            description: "Returns all band detail for given band (by its Id).",
            type: typeof(ReturnArtistDetails)
        )]
        // GET api/v1/artists/{AId}/details/
        [HttpGet("{AId}/details/")]
        public async Task<IActionResult> GetArtistDetails([FromRoute] int AId)
        {

            var LResponse = new ReturnArtistDetails();
            try
            {

                var LBandDetails = await FLogicContext.Artists.GetArtistDetails(AId);

                LResponse.Name        = LBandDetails.Name;
                LResponse.Established = LBandDetails.Established;
                LResponse.ActiveUntil = LBandDetails.ActiveUntil;
                LResponse.Genere      = LBandDetails.Genere;
                LResponse.Members     = LBandDetails.Members;

                LResponse.IsSucceeded = true;
                return StatusCode(200, LResponse);

            }
            catch (Exception LException)
            {
                LResponse.Error.ErrorCode = LException.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(LException.InnerException?.Message) ? LException.Message : $"{LException.Message} ({LException.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/artists/{AId}/details/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}
