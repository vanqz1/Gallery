using System.Web.Http;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class PicturesController : ApiController
    {
        private readonly IPicturesService m_PicturesServices;

        public PicturesController(IPicturesService picturesServices)
        {
            m_PicturesServices = picturesServices;
        }

        [HttpGet]
        [Route("api/bg/pictures/{id:int}")]
        public IHttpActionResult GetBgPictures(int id)
        {
            var picture = m_PicturesServices.GetByIdPicture(id, EnumLanguages.Bulgarian);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }

        [HttpGet]
        [Route("api/en/pictures/{id:int}")]
        public IHttpActionResult GetEnPictures(int id)
        {
            var picture = m_PicturesServices.GetByIdPicture(id, EnumLanguages.English);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }

        [HttpGet]
        [Route("api/bg/pictures")]
        public IHttpActionResult GetAllBgPictures()
        {
            var pictures = m_PicturesServices.GetAllPictures(EnumLanguages.Bulgarian);
            return Ok(pictures);
        }

        [HttpGet]
        [Route("api/en/pictures")]
        public IHttpActionResult GetAllEnPictures()
        {
            var pictures = m_PicturesServices.GetAllPictures(EnumLanguages.English);
            return Ok(pictures);
        }
    }
}

