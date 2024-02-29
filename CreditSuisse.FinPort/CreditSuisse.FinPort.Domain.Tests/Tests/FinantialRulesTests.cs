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
        public void FinantialRule_Applies_Success()
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
        public void FinantialRule_Applies_Fail()
        {
            // Arrange
            FinantialRule rule = new("Medium", 1000000, 5000000);
            FinantialInstrument instrument = new(8000000, "Derivative");

            // Act
            bool applies = rule.Applies(instrument);

            // Assert
            Assert.False(applies);
        }

        [Fact]
        public async Task FinantialRule_ListApplies_Success()
        {
            // Arrange
            FinantialRule rule = new("Medium", 1000000, 5000000);
            List<FinantialInstrument> instruments =
                [
                    new(3000000, "Derivative"),
                    new(5000000, "Test 1"),
                    new(1000000, "Test 2"),
                    new(2503040, "Test 3")
                ];

            // Act
            bool applies = await rule.Applies(instruments);

            // Assert
            Assert.True(applies);
        }

        [Fact]
        public async Task FinantialRule_ListApplies_Fail()
        {
            // Arrange
            FinantialRule rule = new("Medium", 1000000, 5000000);
            List<FinantialInstrument> instruments =
                [
                    new(3000000, "Derivative"),
                    new(5000000, "Test"),
                    new(1000000, "Test 2"),
                    new(5000001, "Test fail")
                ];

            // Act
            bool applies = await rule.Applies(instruments);

            // Assert
            Assert.False(applies);
        }
    }
}
