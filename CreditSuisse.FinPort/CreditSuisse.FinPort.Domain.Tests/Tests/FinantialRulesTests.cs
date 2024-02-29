using CreditSuisse.FinPort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.FinPort.Domain.Tests.Tests
{
    public class FinantialRulesTests
    {
        [Fact]
        public void FinantialRule_Range_Success()
        {
            // Arrange
            FinantialRule rule = new("Medium", 1000000, 5000000);
            FinantialInstrument instrument = new(3000000, "Derivative");

            // Act
            bool applies = rule.Applies(instrument);

            // Assert
            Assert.True(applies);
        }

        [Fact]
        public void FinantialRule_Range_Fail()
        {
            // Arrange
            FinantialRule rule = new("Medium", 1000000, 5000000);
            FinantialInstrument instrument = new(8000000, "Derivative");

            // Act
            bool applies = rule.Applies(instrument);

            // Assert
            Assert.False(applies);
        }
    }
}
