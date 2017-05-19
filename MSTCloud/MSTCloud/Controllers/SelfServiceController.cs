using MSTCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MSTCloud.Controllers
{
    public class SelfServiceController : ApiController
    {
        private string Error;

        [AllowAnonymous]
        [HttpGet]
        [Route("api/selfservice/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is " + DateTime.Now);
        }

        [Authorize]
        [HttpGet]
        [Route("api/selfservice/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Authenticated: " + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/selfservice/authorize")]
        public IHttpActionResult GetForAuthorize()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok("Authorized: " + identity.Name + "    Roles:" + string.Join(",", roles.ToList()));
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/selfservice/getcallouts")]
        public IHttpActionResult GetCallOuts(string div, string loc, string shiftstart)
        {

            List<callout> result = null;
            try
            {
                result = (new BL.BusinessFactory()).GetCallOuts(div, loc
                    , string.IsNullOrEmpty(shiftstart) ? DateTime.Now : Convert.ToDateTime(shiftstart));

                if (result.Count == 1 && !string.IsNullOrEmpty(result[0].errorcode))
                {
                    Error = result[1].errorcode;
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(Error),
                        ReasonPhrase = "Critical Exception"
                    });
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Critical Exception"
                });
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/selfservice/getcalloutswosec")]
        public IHttpActionResult GetCallOutsWOSec(string div, string loc, string shiftstart)
        {

            List<callout> result = null;
            try
            {
                result = (new BL.BusinessFactory()).GetCallOuts(div, loc
                    , string.IsNullOrEmpty(shiftstart) ? DateTime.Now : Convert.ToDateTime(shiftstart));

                if (result.Count == 1 && !string.IsNullOrEmpty(result[0].errorcode))
                {
                    Error = result[1].errorcode;
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(Error),
                        ReasonPhrase = "Critical Exception"
                    });
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Critical Exception"
                });
            }
            return Ok(result);
        }
    }
}
