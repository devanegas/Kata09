using System;
using System.Collections.Generic;
using System.Text;

namespace Kata09.Models
{
    public class Checkout
    {
        private List<PricingRule> _pricingRules { get; set; }
        public Checkout(List<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules;
            ItemQuantityDictionary = new Dictionary<Item, int>();
        }
        public double Total { get; set; }
        public Dictionary<Item, int> ItemQuantityDictionary { get; set; }

        public void Scan(Item item)
        {
            AddItemToDictionary(item);
            var updatedPrice = CalculatePricesInDictionary();
            UpdateTotal(updatedPrice);
        }

        private void UpdateTotal(double updatedPrice)
        {
            Total = updatedPrice;
        }

        private double CalculatePricesInDictionary()
        {
            var total = 0.0;
            foreach (var keyValuePair in ItemQuantityDictionary)
            {
                var partialTotal = 0.0;
                if (HasPricingRule(keyValuePair))
                {
                    var rule = GetPricingRule(keyValuePair.Key);
                    partialTotal = CalculateDiscountedPrice(keyValuePair, rule);
                }
                else
                {
                    partialTotal = CalculateRegularPrice(keyValuePair);
                }

                total += partialTotal;

            }

            return total;
        }

        private bool HasPricingRule(KeyValuePair<Item, int> keyValuePair)
        {
            foreach (var rule in _pricingRules)
            {
                if (rule.Label == keyValuePair.Key.Label)
                {
                    return true;
                }
            }

            return false;
        }

        private double CalculateRegularPrice(KeyValuePair<Item, int> keyValuePair)
        {
            return keyValuePair.Key.Price * keyValuePair.Value;
        }

        private double CalculateDiscountedPrice(KeyValuePair<Item, int> keyValuePair, PricingRule rule)
        {
            var multiprice = (keyValuePair.Value / rule.BaseQuantityForDiscount) * rule.DiscountPrice;
            var remainingPrice = (keyValuePair.Value % rule.BaseQuantityForDiscount) * keyValuePair.Key.Price;
            return multiprice + remainingPrice;
        }

        private PricingRule GetPricingRule(Item key)
        {
            foreach (var rule in _pricingRules)
            {
                if (rule.Label == key.Label)
                {
                    return rule;
                }
            }

            return null;
        }

        private void AddItemToDictionary(Item item)
        {

            if (ItemQuantityDictionary == null || ItemQuantityDictionary.ContainsKey(item) == false)
            {
                ItemQuantityDictionary.Add(item, 1);
            }
            else
            {
                ItemQuantityDictionary[item]++;
            }
        }
    }
}
