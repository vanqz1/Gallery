using Repository;
using Repository.Repository;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PicturesBgController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            PicturesBgRepository a = new PicturesBgRepository();
            var picture = a.GetByIdPictureBg(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(a.GetByIdPictureBg(id));
        }

        public IHttpActionResult Get()
        {
            PicturesBgRepository a = new PicturesBgRepository();
            return Ok(a.GetAllPicturesBg());
        }
    }
}