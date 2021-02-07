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

namespace SongLyrics.Controllers.Artists
{
    public class ArtistsController : __BaseController
    {
        public ArtistsController(IAppLogger AAppLogger, ILogicContext ALogicContext) : base(AAppLogger, ALogicContext)
        {
        }

        /// <summary>
        /// Returns all bands from the entire collection.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Returns all bands from the entire collection.", type: typeof(ReturnArtistsDto))]
        // GET api/v1/artists/
        [HttpGet]
        public async Task<IActionResult> GetArtists() 
        {
            try
            {
                var LArtists = await FLogicContext.Artists.GetArtists(null);
                if (!LArtists.Any()) 
                {
                    FAppLogger.LogWarn(ErrorCodes.EMPTY_BAND_LIST);
                    return StatusCode(400, new ErrorHandlerDto
                    {
                        ErrorCode = nameof(ErrorCodes.EMPTY_BAND_LIST),
                        ErrorDesc = ErrorCodes.EMPTY_BAND_LIST
                    });
                }

                return StatusCode(200, new ReturnArtistsDto 
                {
                    Artists = LArtists
                });
            }
            catch (Exception AException)
            {
                FAppLogger.LogFatality(ControllerException.Handle(AException).ErrorDesc);
                return StatusCode(500, ControllerException.Handle(AException));
            }
        }

        /// <summary>
        /// Returns list of all band members.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Returns list of all band members.", type: typeof(ReturnMembersDto))]
        // GET api/v1/artists/{AId}/members/
        [HttpGet("{AId}/members/")]
        public async Task<IActionResult> GetMembers([FromRoute] int AId)
        {
            try
            {               
                var LMembers = await FLogicContext.Artists.GetMembers(AId);
                if (!LMembers.Any())
                {
                    FAppLogger.LogWarn(ErrorCodes.EMPTY_MEMBERS_LIST);
                    return StatusCode(400, new ErrorHandlerDto
                    {
                        ErrorCode = nameof(ErrorCodes.EMPTY_MEMBERS_LIST),
                        ErrorDesc = ErrorCodes.EMPTY_MEMBERS_LIST
                    });
                }

                return StatusCode(200, new ReturnMembersDto 
                {
                    Members = LMembers
                });
            }
            catch (Exception AException)
            {
                FAppLogger.LogFatality(ControllerException.Handle(AException).ErrorDesc);
                return StatusCode(500, ControllerException.Handle(AException));
            }
        }

        /// <summary>
        /// Returns all band detail for given band (by its Id).
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Returns all band detail for given band (by its Id).", type: typeof(ReturnArtistDetailsDto))]
        // GET api/v1/artists/{AId}/details/
        [HttpGet("{AId}/details/")]
        public async Task<IActionResult> GetArtistDetails([FromRoute] int AId)
        {
            try
            {
                var LBandDetails = await FLogicContext.Artists.GetArtistDetails(AId);
                if (LBandDetails == null) 
                {
                    FAppLogger.LogWarn(ErrorCodes.UNEXPECTED_ERROR);
                    return StatusCode(400, new ErrorHandlerDto
                    {
                        ErrorCode = nameof(ErrorCodes.UNEXPECTED_ERROR),
                        ErrorDesc = ErrorCodes.UNEXPECTED_ERROR
                    });
                }

                return StatusCode(200, new ReturnArtistDetailsDto 
                {
                    Name = LBandDetails.Name,
                    Established = LBandDetails.Established,
                    ActiveUntil = LBandDetails.ActiveUntil,
                    Genere = LBandDetails.Genere,
                    Members = LBandDetails.Members
            });
            }
            catch (Exception AException)
            {
                FAppLogger.LogFatality(ControllerException.Handle(AException).ErrorDesc);
                return StatusCode(500, ControllerException.Handle(AException));
            }
        }
    }
}
