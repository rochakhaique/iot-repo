using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Iot.WebApi.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        protected BaseController(ILogger logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }

        /// <summary>
        /// Logging Object
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// AutoMapper Object
        /// </summary>
        protected IMapper Mapper { get; }
    }
}