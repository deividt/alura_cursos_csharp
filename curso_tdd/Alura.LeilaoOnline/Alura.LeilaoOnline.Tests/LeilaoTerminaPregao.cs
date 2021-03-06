namespace Alura.LeilaoOnline.Tests
{
    using System;
    using Alura.LeilaoOnline.Core;
    using Xunit;

    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1250, 1200, new double[] { 800, 1200, 1150, 1400, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorEsperado, double valorDestino, double[] ofertas)
        {
            // Arranje
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);
            Leilao leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                leilao.RecebeLance(i % 2 == 0 ? fulano : maria, ofertas[i]);
            }

            // Act
            leilao.TerminaPregao();

            // Assert
            double valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }


        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance
            (double valorEsperado, double[] ofertas)
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

            // Act
            leilao.TerminaPregao();

            // Assert
            double valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            // Arranje
            IModalidadeAvaliacao modalidade = new MaiorValor();
            Leilao leilao = new Leilao("Van Gogh", modalidade);

            // Assert
            InvalidOperationException excecaoObtida = Assert.Throws<InvalidOperationException>(
                // Act
                () => leilao.TerminaPregao());

            string mensagemEsperada = "Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método InicialPregao().";
            Assert.Equal(mensagemEsperada, excecaoObtida.Message);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            // Arranje
            IModalidadeAvaliacao modalidade = new MaiorValor();
            Leilao leilao = new Leilao("Van Gogh", modalidade);
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