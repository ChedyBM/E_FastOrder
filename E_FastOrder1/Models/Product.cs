﻿using System;

namespace E_FastOrder1.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Categories cat_id { get; set; }
    }
}