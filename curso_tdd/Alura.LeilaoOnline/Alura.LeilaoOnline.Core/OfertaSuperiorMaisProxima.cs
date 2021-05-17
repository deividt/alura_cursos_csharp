namespace Alura.LeilaoOnline.Core
{
    using System.Linq;

    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; }

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            this.ValorDestino = valorDestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(x => x.Valor > this.ValorDestino)
                .OrderBy(x => x.Valor)
                .FirstOrDefault();
        }
    }
}