using CreditSuisse.FinPort.Domain.Entities;
using CreditSuisse.FinPort.Domain.Interfaces;

namespace CreditSuisse.FinPort.Domain.Tests.Tests
{
    public class FinantialRulesTests
    {
        [Fact]
        public void FinantialRule_Applies_Success()
        {
            // Arrange
            FinantialRule rule = new BasicRule("Medium", 1000000, 5000000);
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
            FinantialRule rule = new BasicRule("Medium", 1000000, 5000000);
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
            FinantialRule rule = new BasicRule("Medium", 1000000, 5000000);
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
            FinantialRule rule = new BasicRule("Medium", 1000000, 5000000);
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

        [Fact]
        public async Task FinantialRule_Filter_Success()
        {
            // Arrange
            FinantialRule rule = new BasicRule("Medium", 1000000, 5000000);
            List<FinantialInstrument> instruments =
                [
                    new(3000000, "Passed"),
                    new(5000000, "Passed 2"),
                    new(1000000, "Passed 3"),
                    new(8000000, "Not Passed"),
                    new(930500, "Not Passed 2"),
                    new(2000, "Not Passed 3"),
                    new(2503040, "Passed 4")
                ];

            // Act
            List<IFinantialInstrument> filtered = await rule.Filter(instruments);

            // Assert
            Assert.Equal(4, filtered.Count);
            Assert.DoesNotContain(filtered, a => a.Type.Contains("Not"));
        }
    }
}
