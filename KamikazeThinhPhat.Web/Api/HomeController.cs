using KamikazeThinhPhat.Service;
using KamikazeThinhPhat.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KamikazeThinhPhat.Web.Api
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;
        public HomeController(IErrorService errorService):base(errorService)
        {
                
        }
        [HttpGet]
        [Route("MethodDefault")]
        
        public string MethodDefault()
        {
            return "Hello, Administrator";
        }
    }
}