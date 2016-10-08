using System.Collections;
using System.Linq;
using System.Resources;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ResourceController : ApiController
    {
        [HttpGet]
        [Route("api/en/resources")]
        public IHttpActionResult GetEnResources()
        {
            ResourceManager myManager = new ResourceManager(typeof(ResourceEn));
            var entry = myManager.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
              .OfType<DictionaryEntry>()
              .ToDictionary(s => s.Key, s => s.Value);

            return Ok(entry);
        }

        [HttpGet]
        [Route("api/bg/resources")]
        public IHttpActionResult GetBgResources()
        {
            ResourceManager myManager = new ResourceManager(typeof(ResourceBg));
            var entry = myManager.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
              .OfType<DictionaryEntry>()
              .ToDictionary(s => s.Key, s => s.Value);

            return Ok(entry);
        }
    }
}
