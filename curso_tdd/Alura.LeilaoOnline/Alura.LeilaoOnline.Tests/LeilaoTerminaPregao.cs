namespace Alura.LeilaoOnline.Tests
{
    using Alura.LeilaoOnline.Core;
    using Xunit;

    public class LeilaoTerminaPregao
    {

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance
            (double valorEsperado, double[] ofertas)
        {
            // Arranje
            Leilao leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();

            foreach (double valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            // Act
            leilao.TerminaPregao();

            // Assert
            double valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            // Arranje
            Leilao leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            // Act
            leilao.TerminaPregao();

            // Assert
            double valorEsperado = 0;
            double valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}