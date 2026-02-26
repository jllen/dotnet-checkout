using Supermarket.PricingStrategy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Supermarket.Test
{
    public class CheckoutTests
    {
        [Fact]
        public void TestTotal()
        {
            // Arrange
            var unitCodeA = new UnitCode('A');
            var unitCodeB = new UnitCode('B');
            var unitCodeC = new UnitCode('C');
            var unitCodeD = new UnitCode('D');
            var unitCodeE = new UnitCode('E');

            var pricingRules = new List<PricingRule>();
            pricingRules.Add(new PricingRule(unitCodeA, 50, "3 for 130"));
            pricingRules.Add(new PricingRule(unitCodeB, 30, "2 for 45"));
            pricingRules.Add(new PricingRule(unitCodeC, 20));
            pricingRules.Add(new PricingRule(unitCodeD, 15));
            pricingRules.Add(new PricingRule(unitCodeE, 60, "Buy 2 get 1 free"));


            var subject = new Checkout(pricingRules, new PricingStrategyFactory());

            // Act
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeB);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeE);
            subject.Scan(unitCodeB);
            subject.Scan(unitCodeC);
            subject.Scan(unitCodeD);
            subject.Scan(unitCodeE);
            subject.Scan(unitCodeE);
            subject.Scan(unitCodeE);

            // Assert
            Assert.Equal(440, subject.Total());
        }
    }
}
