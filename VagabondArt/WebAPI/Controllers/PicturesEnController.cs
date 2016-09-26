using Repository;
using Repository.Repository;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PicturesEnController : ApiController
    {
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

        public IHttpActionResult Get()
        {
            PicturesEnServices a = new PicturesEnServices();
            return Ok(a.GetAllPicturesEn());
        }
    }
}