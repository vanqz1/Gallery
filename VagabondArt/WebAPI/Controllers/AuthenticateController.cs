using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class AuthenticateController : ApiController
    {
        private readonly ITokenService m_TokenService;

        public AuthenticateController(ITokenService tokenServices)
        {
            m_TokenService = tokenServices;
        }

        [HttpPost]
        public HttpResponseMessage Authenticate()
        {
            //if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            //{
            //    var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
            //    if (basicAuthenticationIdentity != null)
            //    {
            //        var userId = basicAuthenticationIdentity.UserId;
            //        return GetAuthToken(userId);
            //    }
            //}
            return null;
        }

        [HttpGet]
        [Route("api/auth/token")]
        public HttpResponseMessage GetAuthToken()
        {
            var adminId = 1;
            var token = m_TokenService.GenerateToken(adminId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");

            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", "12");
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");

            return response;
        }
    }
}
