using Repository.Repository;
using System.Web.Http;
namespace WebAPI.Controllers

{
    public class PicturesBgController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var a = new PicturesBgServices();
            var picture = a.GetByIdPictureBg(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(a.GetByIdPictureBg(id));
        }

        public IHttpActionResult Get()
        {
            PicturesBgServices a = new PicturesBgServices();
            return Ok(a.GetAllPicturesBg());
        }
    }
}