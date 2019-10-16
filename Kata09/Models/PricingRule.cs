using System;
using System.Collections.Generic;
using System.Text;

namespace Kata09.Models
{
    public class PricingRule
    {
        public PricingRule(char label, int baseQtyForDiscount, double discountPrice)
        {
            Label = label;
            BaseQuantityForDiscount = baseQtyForDiscount;
            DiscountPrice = discountPrice;
        }
        public char Label { get; set; }
        public int BaseQuantityForDiscount { get; set; }
        public double DiscountPrice { get; set; }
    }
}
