using WebAPI.Services;
using System.Web.Http;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class PicturesEnController : ApiController
    {
        private readonly IPicturesEnServices m_PicturesEnServices;

        public PicturesEnController(IPicturesEnServices picturesEnServices)
        {
            m_PicturesEnServices = picturesEnServices;
        }

        [HttpGet]
        [Route("api/en/pictures/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var picture = m_PicturesEnServices.GetByIdPictureEn(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }


        [HttpGet]
        [Route("api/en/pictures")]
        public IHttpActionResult Get()
        {
            var pictures = m_PicturesEnServices.GetAllPicturesEn();
            return Ok(pictures);
        }
    }
}