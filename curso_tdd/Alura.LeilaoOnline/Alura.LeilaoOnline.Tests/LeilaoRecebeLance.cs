namespace Alura.LeilaoOnline.Tests
{
    using System.Linq;
    using Alura.LeilaoOnline.Core;
    using Xunit;

    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(4, new double[] { 100, 1200, 1400, 1300 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int quantidadeEsperada, double[] ofertas)
        {
            // Arranje
            Leilao leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();

            foreach (double valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            leilao.TerminaPregao();

            // Act
            leilao.RecebeLance(fulano, 1000);

            // Assert
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }
    }
}