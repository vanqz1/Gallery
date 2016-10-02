using System.Collections;
using System.Linq;
using System.Resources;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ResourcesBgController : ApiController
    {
        [HttpGet]
        [Route("api/bg/resources")]
        public IHttpActionResult Get()
        {
            ResourceManager myManager = new ResourceManager(typeof(ResourceBg));
            var entry = myManager.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
              .OfType<DictionaryEntry>()
              .ToDictionary(s=>s.Key, s=> s.Value);
            
            return Ok(entry);
        }
    }
}
