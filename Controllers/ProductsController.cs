using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Operations_Santos.Models;

namespace Operations_Santos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Code = "P001",
                    Name = "Laptop",
                    Description = "A laptop computer",
                    Price = 20000m
                },
                new Product
                {
                    ProductId = 2,
                    Code = "P002",
                    Name = "Mouse",
                    Description = "Wireless mouse",
                    Price = 1000m
                }
            };  

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.ProductId = products.Count + 1;

            products.Add(product);

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.ProductId },
                product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Code = updatedProduct.Code;
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return NoContent();
        }

    }
}