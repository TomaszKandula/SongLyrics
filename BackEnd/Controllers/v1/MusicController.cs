using Microsoft.AspNetCore.Mvc;
using BackEnd.Extensions.AppLogger;

namespace BackEnd.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "ResponseCache")]
    public class MusicController : ControllerBase
    {

        private readonly IAppLogger FAppLogger;

        public MusicController(IAppLogger AAppLogger) 
        {
            FAppLogger = AAppLogger;
        }
                        
    


    }

}
