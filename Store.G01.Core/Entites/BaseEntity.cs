﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Entites
{
	public class BaseEntity<TKey>
	{
		public TKey Id { get; set; }
        public DateTime CreatAt { get; set; }= DateTime.Now;
    }
}
