namespace Alura.LeilaoOnline.Core
{
    using System;
    using System.Collections.Generic;

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

        private IModalidadeAvaliacao _avaliador;
        #endregion

        #region Propriedades
        public IEnumerable<Lance> Lances => _lances;

        public EstadoLeilao Estado { get; private set; }

        public string Peca { get; }

        public Lance Ganhador { get; private set; }
        #endregion

        #region Construtor
        public Leilao(string peca, IModalidadeAvaliacao avaliador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            this.Estado = EstadoLeilao.LeilaoAntesPregao;
            _avaliador = avaliador;
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

            this.Ganhador = _avaliador.Avalia(this);
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