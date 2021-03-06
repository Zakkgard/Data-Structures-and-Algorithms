﻿using System;

namespace ProductsPriceRange
{
    public class Product : IComparable<Product>
    {
        public Product(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public float Price { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Price == other.Price)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Price, this.Name);
        }
    }
}
