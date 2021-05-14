namespace Alura.LeilaoOnline.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Leilao
    {
        #region Enumeradores
        public enum EstadoLeilao
        {
            LeilaoAntesPregao,
            LeilaoEmAndamento,
            LeilaoFinalizado
        }
        #endregion

        #region Campos
        private IList<Lance> _lances;

        private Interessada _ultimoCliente;
        #endregion

        #region Propriedades
        public IEnumerable<Lance> Lances => _lances;

        public EstadoLeilao Estado { get; private set; }

        public string Peca { get; }

        public Lance Ganhador { get; private set; }

        public double ValorDestino { get; private set; }
        #endregion

        #region Construtor
        public Leilao(string peca, double valorDestino = 0)
        {
            Peca = peca;
            _lances = new List<Lance>();
            this.Estado = EstadoLeilao.LeilaoAntesPregao;
            this.ValorDestino = valorDestino;
        }
        #endregion

        #region Métodos
        #region Públicos
        public void RecebeLance(Interessada cliente, double valor)
        {
            if (!NovoLanceEhAceito(cliente))
            {
                return;
            }

            _lances.Add(new Lance(cliente, valor));
            _ultimoCliente = cliente;
        }

        public void IniciaPregao()
        {
            this.Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (this.Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new InvalidOperationException("Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método InicialPregao().");
            }

            // Ganhador é oferta superior mais próxima
            if (this.ValorDestino > 0)
            {
                this.Ganhador = Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .Where(x => x.Valor > this.ValorDestino)
                    .OrderBy(x => x.Valor)
                    .FirstOrDefault();
                return;
            }

            // Ganhador é o último lance
            this.Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(x => x.Valor)
                .LastOrDefault();

            this.Estado = EstadoLeilao.LeilaoFinalizado;
        }
        #endregion

        #region Privados
        private bool NovoLanceEhAceito(Interessada cliente)
        {
            return this.Estado == EstadoLeilao.LeilaoEmAndamento && cliente != _ultimoCliente;
        }
        #endregion
        #endregion
    }
}