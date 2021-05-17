namespace Alura.LeilaoOnline.Tests
{
    using System.Linq;
    using Alura.LeilaoOnline.Core;
    using Xunit;

    public class LeilaoRecebeLance
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            // Arranje
            IModalidadeAvaliacao modalidade = new MaiorValor();
            Leilao leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);


            // Act
            leilao.RecebeLance(fulano, 1000);


            // Assert
            int quantidadeEsperada = 1;
            int quantidadeObtida = leilao.Lances.Count();
            Assert.Equal(quantidadeEsperada, quantidadeObtida);
        }

        [Theory]
        [InlineData(4, new double[] { 100, 1200, 1400, 1300 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int quantidadeEsperada, double[] ofertas)
        {
            // Arranje
            IModalidadeAvaliacao modalidade = new MaiorValor();
            Leilao leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                leilao.RecebeLance(i % 2 == 0 ? fulano : maria, ofertas[i]);
            }

            leilao.TerminaPregao();

            // Act
            leilao.RecebeLance(fulano, 1000);

            // Assert
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }
    }
}