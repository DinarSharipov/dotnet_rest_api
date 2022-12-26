using System;
namespace restFull.Models
{
	public struct Book
	{
		static private int Count { get; set; }

		public string Name { get; set; }

		public string Author { get; set; }

		public Book()
		{
			Count += 1;
		}
	}
}

