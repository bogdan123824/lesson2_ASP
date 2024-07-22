using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Watch : ControllerBase
    {
            private static List<WristWatch> Watches = new List<WristWatch>
            {
                new WristWatch {Brand = "Rolex", Manufacter = "Rolex", Price = 100000, Name = "Submariner"},
                new WristWatch {Brand = "Omega", Manufacter = "Omega SA", Price = 50000, Name = "Speedmaster"},
                new WristWatch {Brand = "Casio", Manufacter = "Casio", Price = 1000, Name = "G-shock"}
            };

            private readonly ILogger<Watch> _logger;

            public Watch(ILogger<Watch> logger)
            {
                _logger = logger;
            }
            [HttpGet("AllListWaches", Name = "GetWatches")]

            public ActionResult<IEnumerable<WristWatch>> Get()
            {
                return Ok(Watches);
            }

            [HttpPost("AddWatches", Name = "AddWatches")]

            public ActionResult Add([FromBody] WristWatch addNewWatch) {
               if (addNewWatch == null) 
               {
                    return BadRequest("Enter correct data Watches");
               }
                Watches.Add(addNewWatch);
                return Ok();
            }

            [HttpPut("UpdateWatches", Name = "UpdateWatches")]

            public ActionResult Update(int index, [FromBody] WristWatch UpdateWatches) 
            {
                if(index < 0 || index >= Watches.Count)
                {
                    return NotFound("Watches not found ");
                }
                if (UpdateWatches == null)
                {
                    return BadRequest("Enter correct watches data");
                }

                Watches[index].Brand = UpdateWatches.Brand;
                Watches[index].Manufacter = UpdateWatches.Manufacter;
                Watches[index].Price = UpdateWatches.Price;
                Watches[index].Name = UpdateWatches.Name;

                return Ok();
            }

            [HttpDelete("DeleteWatches", Name = "DeleteWatches")]

            public ActionResult Delete(int index) 
            {                
                if(index < 0 || index >= Watches.Count)
                {
                    return NotFound("Watches with this name not found");
                }
                Watches.RemoveAt(index);
                return Ok();
            }
        }
}
