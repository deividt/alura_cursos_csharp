namespace Alura.LeilaoOnline.Tests
{
    using System.Linq;
    using Alura.LeilaoOnline.Core;
    using Xunit;

    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {
            // Arranje
            Leilao leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(fulano, 900);
            leilao.TerminaPregao();

            // Act
            leilao.RecebeLance(fulano, 1000);

            // Assert
            int valorEsperado = 2;
            Assert.Equal(valorEsperado, leilao.Lances.Count());
        }
    }
}