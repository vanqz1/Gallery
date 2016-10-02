using System.Web.Http;
using WebAPI.Interfaces;

namespace WebAPI.Controllers

{
    public class PicturesBgController : ApiController
    {
        private readonly IPicturesBgServices m_PicturesBgServices;

        public PicturesBgController(IPicturesBgServices picturesBgServices)
        {
            m_PicturesBgServices = picturesBgServices;
        }

        [HttpGet]
        [Route("api/bg/pictures/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var picture = m_PicturesBgServices.GetByIdPictureBg(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }

        [HttpGet]
        [Route("api/bg/pictures")]
        public IHttpActionResult Get()
        {
            var pictures = m_PicturesBgServices.GetAllPicturesBg();
            return Ok(pictures);
        }
    }
}