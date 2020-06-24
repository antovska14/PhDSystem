using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PhDSystem.Api.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        public CustomBaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
