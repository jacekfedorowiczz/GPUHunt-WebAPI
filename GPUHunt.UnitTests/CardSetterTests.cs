using FluentAssertions;
using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Services.CardSetter;
using GPUHunt.Application.Services.StoreCrawlers;
using GPUHunt.Domain.Enums;
using Moq;

namespace GPUHunt.UnitTests
{
    public class CardSetterTests
    {
        [Fact]
        public async Task SetVendor_ForExampleCard_ReturnsCorrectVendor()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithSubvendorAndModel1();
            var expectedValue = Vendors.NVIDIA;

            mock.Setup(m => m.SetVendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetVendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Fact]
        public async Task SetVendor_ForExampleCard_ReturnsCorrectVendor2()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithSubvendorAndModel2();
            var expectedValue = Vendors.AMD;

            mock.Setup(m => m.SetVendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetVendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }


        [Fact]
        public async Task SetVendor_ForExampleCard_ReturnsUndefiniedVendor()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithoutSubvendorAndModel();
            var expectedValue = Vendors.Undefinied;

            mock.Setup(m => m.SetVendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetVendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Fact]
        public async Task SetVendor_ForExampleCard_ReturnsUndefiniedVendor2()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithoutSubvendorAndModel2();
            var expectedValue = Vendors.Undefinied;

            mock.Setup(m => m.SetVendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetVendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Fact]
        public async Task SetSubvendor_ForExampleCard_ReturnsCorrectSubvendor()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithSubvendorAndModel1();
            var expectedValue = Subvendors.MSI;

            mock.Setup(m => m.SetSubvendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetSubvendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Fact]
        public async Task SetSubvendor_ForExampleCard_ReturnsCorrectSubvendor2()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithSubvendorAndModel2();
            var expectedValue = Subvendors.ASRock;

            mock.Setup(m => m.SetSubvendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetSubvendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Fact]
        public async Task SetSubvendor_ForExampleCard_ReturnsUndefiniedSubvendor()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithoutSubvendorAndModel();
            var expectedValue = Subvendors.Undefinied;

            mock.Setup(m => m.SetSubvendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetSubvendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Fact]
        public async Task SetSubvendor_ForExampleCard_ReturnsUndefiniedSubvendor2()
        {
            // Arrange
            var mock = new Mock<ICardSetter>();
            var infoSetter = new CardSetter();
            var testedValue = GetExampleCardWithoutSubvendorAndModel2();
            var expectedValue = Subvendors.Undefinied;

            mock.Setup(m => m.SetSubvendor(testedValue)).Returns(expectedValue);

            // Act
            var result = infoSetter.SetSubvendor(testedValue);

            // Assert
            result.Should().Be(expectedValue);
        }

        private static string GetExampleCardWithSubvendorAndModel1()
        {
            return "MSI RTX 3070 Gaming X Trio 16 GB GDDR6X";
        }

        private static string GetExampleCardWithSubvendorAndModel2()
        {
            return "ASRock RX 7600 XT Turbo OC 24GB GDDR6X";
        }

        private static string GetExampleCardWithoutSubvendorAndModel()
        {
            return "3070 Gaming X Trio 16 GB GDDR6X";
        }

        private static string GetExampleCardWithoutSubvendorAndModel2()
        {
            return "9800 Turbo OP 6GB GDDR6";
        }
    }
}