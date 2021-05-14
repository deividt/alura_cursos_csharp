namespace Alura.LeilaoOnline.Tests
{
    using Alura.LeilaoOnline.Core;
    using Xunit;

    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            // Arrange
            var valorNegativo = -100;

            // Assert
            Assert.Throws<System.ArgumentException>(
                // Act
                () => new Lance(null, valorNegativo));
        }
    }
}