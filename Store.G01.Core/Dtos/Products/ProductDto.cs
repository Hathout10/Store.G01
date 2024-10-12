﻿using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Dtos.Products
{
	public class ProductDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public string PictureUrl { get; set; }
		public decimal Price { get; set; }

		public int? BrandId { get; set; }  //fk
		public string BrandName { get; set; }

		public int? TypeId { get; set; }  //fk
		public string TypeName { get; set; }
	}
}