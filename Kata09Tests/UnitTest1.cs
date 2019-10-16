using Kata09.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Kata09Tests
{
    public class Tests
    {
        private Dictionary<char, Item> ItemDictionary { get; set; }
        private List<PricingRule> Rules { get; set; }
        [SetUp]
        public void Setup()
        {
            ItemDictionary = new Dictionary<char, Item>
            {
                { 'A', new Item('A', 50) },
                { 'B', new Item('B', 30) },
                { 'C', new Item('C', 10) },
                { 'D', new Item('D', 15) },
                { 'E', new Item('E', 100) },
                { 'F', new Item('F', 1000) }
            };

            Rules = new List<PricingRule>()
            {
                new PricingRule('A', 3, 130),
                new PricingRule('B', 2, 45)
            };
        }


        [Test]
        public void PricingRuleIsApplied_PriceIsUpdated()
        {
            var itemA = new Item('A', 50);
            var itemB = new Item('B', 30);

            var co = new Checkout(Rules);
            co.Scan(itemB);
            co.Scan(itemA);
            co.Scan(itemB);

            var expected = 95;
            var actual = co.Total;
            Assert.AreEqual(actual, expected);
        }

        [TestCase("AAAAAA", 260)]
        public void Comprehensive_Test(string itemNames, double expected)
        {
            var actual = Price(itemNames);

            Assert.AreEqual(actual, expected);
        }

        public double Price(string items)
        {
            var co = new Checkout(Rules);
            foreach (var itemName in items)
            {
                var item = ItemDictionary[itemName];
                co.Scan(item);
            }

            return co.Total;
        }

    }
}