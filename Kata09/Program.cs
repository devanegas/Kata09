using Kata09.Models;
using System;
using System.Collections.Generic;

namespace Kata09
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = new List<PricingRule>()
            {
                new PricingRule('A', 3, 130),
                new PricingRule('B', 2, 45)
            };

            var itemA = new Item('A', 50);
            var itemB = new Item('B', 30);

            var co = new Checkout(rules);
            co.Scan(itemB);
            co.Scan(itemA);
            Console.WriteLine(co.Total);

            co.Scan(itemB);
            Console.WriteLine(co.Total);
        }
    }
}
