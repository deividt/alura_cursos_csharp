using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
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
        #endregion

        #region Propriedades
        public IEnumerable<Lance> Lances => _lances;

        public EstadoLeilao Estado { get; private set; }

        public string Peca { get; }

        public Lance Ganhador { get; private set; }
        #endregion

        #region Construtor
        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            this.Estado = EstadoLeilao.LeilaoEmAndamento;
        }
        #endregion

        #region Métodos
        public void RecebeLance(Interessada cliente, double valor)
        {
            if (this.Estado == EstadoLeilao.LeilaoFinalizado)
            {
                return;
            }

            _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {
            this.Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            // Ganhador é o último lance
            this.Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(x => x.Valor)
                .LastOrDefault();

            this.Estado = EstadoLeilao.LeilaoFinalizado;
        }
        #endregion
    }
}