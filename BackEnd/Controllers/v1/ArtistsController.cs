using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models.Json;
using BackEnd.Extensions.AppLogger;

namespace BackEnd.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "ResponseCache")]
    public class ArtistsController : ControllerBase
    {

        private readonly IAppLogger FAppLogger;

        public ArtistsController(IAppLogger AAppLogger) 
        {
            FAppLogger = AAppLogger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/v1/artists/bands/
        [HttpGet("bands")]
        public async Task<IActionResult> GetBands() 
        {

            var LResponse = new ReturnBands();
            try
            {


                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/artists/bands/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/v1/artists/bands/{id}/members/
        [HttpGet("bands/{id}/members/")]
        public async Task<IActionResult> GetMembers(int Id)
        {

            var LResponse = new ReturnMembers();
            try
            {


                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/artists/bands/{Id}/members/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/v1/artists/bands/{id}/details/
        [HttpGet("bands/{id}/details/")]
        public async Task<IActionResult> GetBandDetails(int Id)
        {

            var LResponse = new ReturnBandDetails();
            try
            {


                return StatusCode(200, LResponse);

            }
            catch (Exception E)
            {
                LResponse.Error.ErrorCode = E.HResult.ToString();
                LResponse.Error.ErrorDesc = string.IsNullOrEmpty(E.InnerException?.Message) ? E.Message : $"{E.Message} ({ E.InnerException.Message}).";
                FAppLogger.LogFatality($"GET api/v1/artists/bands/{Id}/details/ | Error has been raised while processing request. Message: {LResponse.Error.ErrorDesc}.");
                return StatusCode(500, LResponse);
            }

        }

    }

}
