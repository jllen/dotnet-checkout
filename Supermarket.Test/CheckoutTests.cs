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

            var pricingRules = new List<PricingRule>();
            pricingRules.Add(new PricingRule(unitCodeA, 50, "3 for 130"));
            pricingRules.Add(new PricingRule(unitCodeB, 30, "2 for 45"));
            pricingRules.Add(new PricingRule(unitCodeC, 20));
            pricingRules.Add(new PricingRule(unitCodeD, 15));

            var subject = new Checkout(pricingRules, new PricingStrategyFactory());

            // Act
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeB);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeB);
            subject.Scan(unitCodeC);
            subject.Scan(unitCodeD);

            // Assert
            Assert.Equal(260, subject.Total());
        }
    }
}
