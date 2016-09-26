using Repository;
using Repository.Repository;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PicturesEnController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            PicturesEnRepository a = new PicturesEnRepository();
            var picture = a.GetByIdPictureEn(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(a.GetByIdPictureEn(id));
        }

        public IHttpActionResult Get()
        {
            PicturesEnRepository a = new PicturesEnRepository();
            return Ok(a.GetAllPicturesEn());
        }
    }
}