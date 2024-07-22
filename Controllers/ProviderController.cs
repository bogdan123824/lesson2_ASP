using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : ControllerBase
    {
        private static List<Provider> Providers = new List<Provider>
        {
            new Provider {Name = "Amazon"},
            new Provider {Name = "Jabko"}
        };

        [HttpGet("GetProvider", Name = "GetProvider")]
        public ActionResult<IEnumerable<Provider>> Get()
        {
            return Ok(Providers);
        }

        [HttpPost("AddProvider", Name = "AddProvider")]
        public ActionResult Add([FromBody] Provider addNewProvider)
        {
            Providers.Add(addNewProvider);
            return Ok();
        }

        [HttpPut("UpdateProvider", Name = "UpdateProvider")]
        public ActionResult Update(int index, [FromBody] Provider updatedProvider)
        {
            if (index < 0 || index >= Providers.Count)
                return NotFound();

            Providers[index].Name = updatedProvider.Name;
            return Ok();
        }

        [HttpDelete("DeleteProvider", Name = "DeleteProvider")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= Providers.Count)
                return NotFound();

            Providers.RemoveAt(index);
            return Ok();
        }
    }
}
