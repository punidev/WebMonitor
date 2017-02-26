using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebMonitoring.Controllers
{
    public class StatusController : ApiController
    {
        [HttpGet]
        public bool CheckStatus()
        {
            return Headers().Any();
        }

        [HttpGet]
        public IEnumerable<string> Headers()
        {
            return new [] {"It`s work!"};
        }
    }
}
