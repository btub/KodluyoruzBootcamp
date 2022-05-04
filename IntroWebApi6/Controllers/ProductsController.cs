using IntroWebApi6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products;

        public ProductsController()
        {
            products = new List<Product>()
            {
                new Product{Id=1,Name="Product 1", Description="Products 1 description",Price=19.99,ImageUrl="https://picsum.photos/200/300"},
                new Product{Id=2,Name="Product 2", Description="Products 2 description",Price=19.99,ImageUrl="https://picsum.photos/200/300"},
                new Product{Id=3,Name="Product 3", Description="Products 3 description",Price=19.99,ImageUrl="https://picsum.photos/200/300"},
                new Product{Id=4,Name="Product 4", Description="Products 4 description",Price=19.99,ImageUrl="https://picsum.photos/200/300"}
            };
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            // model binder http request body den gelen verileri product a dönüştürür

            if (ModelState.IsValid)
            {
                //return Ok("succes!");
                //return Created("https://www.myproducts.com/products/1", product);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = 5}, value: product);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")] //https://.............com/id? // yazmak zorunda değilsin yazılımcılara bilgi vermek için daha çok
        public IActionResult GetProduct([FromRoute] int id)
        {
            var product = products.Find(p => p.Id == id); //generic olarak en hızlısı find
            if(product == null)
            {
                return NotFound(new {message = $"{id} numaralı ürün bulunamadı."});
            }
            return Ok(product);
        }
    }
}
