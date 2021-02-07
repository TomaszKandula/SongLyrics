using Microsoft.AspNetCore.Mvc;
using SongLyrics.Logic;
using SongLyrics.Logger;

namespace SongLyrics.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "ResponseCache")]
    public class __BaseController : ControllerBase
    {
        protected readonly IAppLogger FAppLogger;
        protected readonly ILogicContext FLogicContext;

        public __BaseController(IAppLogger AAppLogger, ILogicContext ALogicContext) 
        {
            FAppLogger = AAppLogger;
            FLogicContext = ALogicContext;
        }
    }
}
