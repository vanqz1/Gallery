using Repository;
using Repository.Repository;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TestController : ApiController
    {

        public IHttpActionResult Get(int id)
        {
            PicturesBgRepository a = new PicturesBgRepository();
            return Ok(a.GetAllPicturesBg());
        }
    }
}