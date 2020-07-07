using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingDemonstration_1.Contracts;

namespace UnitTestingDemonstration_1.Models
{
    public class PriceCalculator
    {
        IDiscountHelper disc;

        public PriceCalculator(IDiscountHelper d)
        {
            disc = d;
        }

        public decimal CalculateTotalPrice(List<Product> products)
        {
            var totalPrice = products.Sum(p => p.Price * p.Quantity);

            var priceAfterDiscount = disc.ApplyDiscount(totalPrice);

            return priceAfterDiscount;
        }
    }
}