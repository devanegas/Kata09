using System;
using System.Collections.Generic;
using System.Text;

namespace Kata09.Models
{
    public class Item
    {
        public Item(char label, double price)
        {
            Label = label;
            Price = price;
        }

        public char Label { get; set; }
        public double Price { get; set; }
    }
}
