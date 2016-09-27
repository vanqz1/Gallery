using Repository;
using Repository.Repository;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PicturesEnController : ApiController
    {
        [HttpGet]
        [Route("api/en/pictures/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            PicturesEnServices a = new PicturesEnServices();
            var picture = a.GetByIdPictureEn(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(a.GetByIdPictureEn(id));
        }


        [HttpGet]
        [Route("api/en/pictures")]
        public IHttpActionResult Get()
        {
            PicturesEnServices a = new PicturesEnServices();
            return Ok(a.GetAllPicturesEn());
        }
    }
}