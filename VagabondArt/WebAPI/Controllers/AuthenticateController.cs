using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Services.Interfaces;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AuthenticateController : ApiController
    {
        private readonly IAuthenticationService m_AuthenticationService;

        public AuthenticateController(IAuthenticationService authenticationService)
        {
            m_AuthenticationService = authenticationService;
        }

        [HttpPost]
        [Route("api/admin/authenticate")]
        public IHttpActionResult Authenticate()
        {
            HttpContext httpContext = HttpContext.Current;

            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                var adminId = m_AuthenticationService.Authenticate(authHeader);

                if (adminId > 0)
                {
                    var token = m_AuthenticationService.GenerateToken(adminId);

                    return Ok(token);
                }
                else
                {
                    var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Username or password is invalid." };
                    throw new HttpResponseException(msg);
                }
            }
            else
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "The authorization header is either empty or isn't Basic." };
                throw new HttpResponseException(msg);
            }
        }

        [HttpPost]
        [Route("api/admin/authorize")]
        public IHttpActionResult Authorize()
        {
            var form = HttpContext.Current.Request.Form;
            var authToken = form["AuthToken"];

            if (!string.IsNullOrEmpty(authToken))
            {
                var isAuthorized = m_AuthenticationService.ValidateToken(authToken);

                if (isAuthorized)
                {
                    return Ok("Authorized");
                }

                m_AuthenticationService.Kill(authToken);
            }

            var msg = new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Unauthorized" };
            throw new HttpResponseException(msg);
        }

        [HttpDelete]
        [Route("api/admin/logout")]
        public IHttpActionResult LogOut()
        {
            var form = HttpContext.Current.Request.Form;
            var authToken = form["authToken"];

            var isTokenKilled = m_AuthenticationService.Kill(authToken);

            if (isTokenKilled)
            {
                return Ok("End session");
            }

            var msg = new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Invalid admin id" };
            throw new HttpResponseException(msg);
        }
    }
}
