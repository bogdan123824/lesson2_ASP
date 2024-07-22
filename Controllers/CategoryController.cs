using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> Categories = new List<Category>
        {
            new Category {Name = "Electronic"},
            new Category {Name = "Clothes"}
        };

        [HttpGet("GetCategory", Name = "GetCategory")]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return Ok(Categories);
        }

        [HttpPost("AddCategory", Name = "AddCategory")]
        public ActionResult Add([FromBody] Category addNewCategory)
        {
            Categories.Add(addNewCategory);
            return Ok();
        }

        [HttpPut("UpdateCategory", Name = "UpdateCategory")]
        public ActionResult Update(int index, [FromBody] Category updatedCategory)
        {
            if (index < 0 || index >= Categories.Count)
                return NotFound();

            Categories[index].Name = updatedCategory.Name;
            return Ok();
        }

        [HttpDelete("DeleteCategory", Name = "DeleteCategory")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= Categories.Count)
                return NotFound();

            Categories.RemoveAt(index);
            return Ok();
        }
    }
}
