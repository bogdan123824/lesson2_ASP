using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { Name = "Iphone", CategoryIdx = 0, ManufacturerIdx = 0, Price = 100000 },
            new Product { Name = "Samsung", CategoryIdx = 0, ManufacturerIdx = 1, Price = 5000 }
        };

        [HttpGet("GetProduct", Name = "GetProduct")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(Products);
        }

        [HttpPost("AddProduct", Name = "AddProduct")]
        public ActionResult Add([FromBody] Product addNewProduct)
        {
            Products.Add(addNewProduct);
            return Ok();
        }

        [HttpPut("UpdateProduct", Name = "UpdateProduct")]
        public ActionResult Update(int index, [FromBody] Product updatedProduct)
        {
            if (index < 0 || index >= Products.Count)
                return NotFound();

            Products[index].Name = updatedProduct.Name;
            Products[index].CategoryIdx = updatedProduct.CategoryIdx;
            Products[index].ManufacturerIdx = updatedProduct.ManufacturerIdx;
            Products[index].Price = updatedProduct.Price;
            return Ok();
        }

        [HttpDelete("DeleteProduct", Name = "DeleteProduct")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= Products.Count)
                return NotFound();

            Products.RemoveAt(index);
            return Ok();
        }
    }
}
