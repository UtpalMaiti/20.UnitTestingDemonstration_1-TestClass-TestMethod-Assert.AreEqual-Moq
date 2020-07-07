using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingDemonstration_1.Models;
using Moq;
using UnitTestingDemonstration_1.Contracts;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class PriceCalculatorUnitTests
    {
        [TestMethod]
        public void CalculateTotalPrice_Test()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();

            mock.Setup(e => e.ApplyDiscount(It.Is<decimal>(p=>p>=5000)))
                .Returns<decimal>(x => x * 0.8m);

            mock.Setup(e => e.ApplyDiscount(It.IsInRange<decimal>(1000,4999,Range.Inclusive)))
                .Returns<decimal>(x => x * 0.9m);

            mock.Setup(e => e.ApplyDiscount(It.IsInRange<decimal>(0,999,Range.Inclusive)))
                .Returns<decimal>(x => x );

            mock.Setup(e => e.ApplyDiscount(It.Is<decimal>(p => p < 0))).Throws<ArgumentOutOfRangeException>();

            PriceCalculator calc = new PriceCalculator(mock.Object);

            var productsList = new List<Product>
            {
                new Product {Quantity=5,Price=1000 }
            };

            var expectedTotalPrice = 4000;

            var actualTotalPrice = calc.CalculateTotalPrice(productsList);

            Assert.AreEqual(expectedTotalPrice, actualTotalPrice, 
                "CalculateTotalPrice Method is failed for the Price of 5000");

            productsList = new List<Product>
            {
                new Product {Quantity=4,Price=1000 }
            };

            expectedTotalPrice = 3600;

            actualTotalPrice = calc.CalculateTotalPrice(productsList);

            Assert.AreEqual(expectedTotalPrice, actualTotalPrice,
                "CalculateTotalPrice Method is failed for the Price of 4000");

        }
    }
}
