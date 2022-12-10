using System;
using Microsoft.AspNetCore.Mvc;
using restFull.Models;

namespace restFull.Controllers
{
	[Route("/api/[controller]")]
	public class ProductsController: Controller
	{
		private static List<Product> products = new List<Product>(new[]
		{
			new Product() {Id = 1, Name = "Yahooo", Price = 12000},
            new Product() {Id = 2, Name = "Google", Price = 96000},
            new Product() {Id = 3, Name = "Apple", Price = 120000},
        });

		[HttpGet]
		public IEnumerable<Product> Get() => products;
	}
}

