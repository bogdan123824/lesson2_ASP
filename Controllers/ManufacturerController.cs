using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private static List<Manufacturer> Manufacturers = new List<Manufacturer>
        {
            new Manufacturer {Name = "Apple"},
            new Manufacturer {Name = "Lenovo"}
        };

        [HttpGet("GetManufacturer", Name = "GetManufacturer")]
        public ActionResult<IEnumerable<Manufacturer>> Get()
        {
            return Ok(Manufacturers);
        }

        [HttpPost("AddManufacturreer", Name = "AddManufacturer")]
        public ActionResult Add([FromBody] Manufacturer addNewManufacturer)
        {
            Manufacturers.Add(addNewManufacturer);
            return Ok();
        }

        [HttpPut("UpdateManufacturer", Name = "UpdateManufacturer")]
        public ActionResult Update(int index, [FromBody] Manufacturer updatedManufacturer)
        {
            if (index < 0 || index >= Manufacturers.Count)
                return NotFound();

            Manufacturers[index].Name = updatedManufacturer.Name;
            return Ok();
        }

        [HttpDelete("DeleteManufacturer", Name = "DeleteManufacturer")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= Manufacturers.Count)
                return NotFound();

            Manufacturers.RemoveAt(index);
            return Ok();
        }
    }
}
