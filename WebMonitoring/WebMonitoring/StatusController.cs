using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebMonitoring
{
    public class StatusController : ApiController
    {
        [HttpGet]
        public bool CheckStatus(HttpStatusCode code)
        {
            return code == HttpStatusCode.OK;
        }
        [HttpGet]
        public IEnumerable<string> Headers()
        {
            return new [] {"It`s work!"};
        }
    }
}
