using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProverbsController : ControllerBase
    {
        private static List<string> Texts = new List<string>
        {
            "Без труда не выловишь и рыбку из пруда",
            "Не плюй в колодец, пригодится воды напиться",
            "Под лежачий камень и вода не течет "
        };

        private readonly ILogger<ProverbsController> _logger;

        public ProverbsController(ILogger<ProverbsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetText")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(Texts);
        }

        [HttpPost("Add", Name = "Add")]
        public ActionResult Add([FromBody] string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
            {
                return BadRequest("Text can't be empty.");
            }

            Texts.Add(newText);
            return Ok();
        }

        [HttpPut("Update", Name = "Update")]
        public ActionResult Update(int index, [FromBody] string updateText)
        {
            if (index < 0 || index >= Texts.Count)
            {
                return NotFound("Text not found.");
            }

            if (string.IsNullOrWhiteSpace(updateText))
            {
                return BadRequest("Text can't be empty.");
            }

            Texts[index] = updateText;
            return Ok();
        }

        [HttpDelete("Delete", Name = "Delete")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= Texts.Count)
            {
                return NotFound("Text not found.");
            }

            Texts.RemoveAt(index);
            return Ok();
        }
    }
}
