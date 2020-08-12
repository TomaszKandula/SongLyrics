using Microsoft.AspNetCore.Mvc;
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






    }

}
