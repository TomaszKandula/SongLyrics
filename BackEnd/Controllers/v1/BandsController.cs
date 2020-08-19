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
    public class BandsController : ControllerBase
    {

        private readonly IAppLogger    FAppLogger;
        private readonly ILogicContext FLogicContext;

        public BandsController(IAppLogger AAppLogger, ILogicContext ALogicContext) 
        {
            FAppLogger    = AAppLogger;
            FLogicContext = ALogicContext;
        }

        /// <summary>
        /// Returns all bands from the entire collection.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/bands/
        [HttpGet]
        public async Task<IActionResult> GetBands() 
        {

            var LResponse = new ReturnBands();
            try
            {

                var LResult = await FLogicContext.Artists.GetBands(null);

                if (!LResult.Any()) 
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptyBandList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptyBandList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/bands/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Bands = LResult;
                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/bands/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns list of all band members.
        /// </summary>
        /// <returns></returns>
        // GET api/v1/bands/{id}/members/
        [HttpGet("{id}/members/")]
        public async Task<IActionResult> GetMembers(int Id)
        {

            var LResponse = new ReturnMembers();
            try
            {
                
                var LResult = await FLogicContext.Artists.GetMembers(Id);

                if (!LResult.Any())
                {
                    LResponse.Error.ErrorCode = Constants.Errors.EmptyMembersList.ErrorCode;
                    LResponse.Error.ErrorDesc = Constants.Errors.EmptyMembersList.ErrorDesc;
                    FAppLogger.LogWarn($"GET api/v1/bands/{Id}/members/. {LResponse.Error.ErrorDesc}.");
                    return StatusCode(200, LResponse);
                }

                LResponse.Members = LResult;
                return StatusCode(200, LResponse);
            
            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/bands/{Id}/members/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// Returns all band detail for given band (by its Id).
        /// </summary>
        /// <returns></returns>
        // GET api/v1/bands/{id}/details/
        [HttpGet("{id}/details/")]
        public async Task<IActionResult> GetBandDetails(int Id)
        {

            var LResponse = new ReturnBandDetails();
            try
            {

                var LBandDetails = await FLogicContext.Artists.GetBandDetails(Id);

                LResponse.Name        = LBandDetails.Name;
                LResponse.Established = LBandDetails.Established;
                LResponse.ActiveUntil = LBandDetails.ActiveUntil;
                LResponse.Genere      = LBandDetails.Genere;
                LResponse.Members     = LBandDetails.Members;

                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/bands/{Id}/details/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}
