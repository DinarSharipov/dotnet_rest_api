using System;
using Microsoft.AspNetCore.Mvc;
using restFull.Models;

namespace restFull.Controllers
{
	[Route("/api/[controller]")]
	public class ProductsController : Controller
	{
		private static List<Product> products = new List<Product>()
		{
			new Product() {Id = 1, Name = "Yahooo", Price = 12000},
			new Product() {Id = 2, Name = "Google", Price = 96000},
			new Product() {Id = 3, Name = "Apple", Price = 120000},
		};

		[HttpGet]
		public IEnumerable<Product> Get() => products;

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var product = products.SingleOrDefault((product) => product.Id == id);

			if (product == null)
			{
				return NotFound(new { Message = "Ничего не найдено..." });
			}

			return Ok(product);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var removedProduct = products.SingleOrDefault((product) => product.Id == id);
			if (removedProduct != null)
			{
				products.Remove(removedProduct);
			}

			return Ok();
		}

		[HttpPost]
		public IActionResult Post(Product product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			product.Id = products.Count() + 1;
			products.Add(product);
			return Ok();
		}

		[HttpPut("{id}")]
        public IActionResult Put(int id, string name)
        {
			var productById = products.FirstOrDefault((product) => product.Id == id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			productById.Name = name;
            return Ok();
        }
    }
}

