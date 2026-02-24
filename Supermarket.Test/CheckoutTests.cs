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

            var subject = new Checkout();

            // Act
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeB);
            subject.Scan(unitCodeA);
            subject.Scan(unitCodeB);

            // Assert
            Assert.Equal(175, subject.Total());
        }
    }
}
