using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        #region Campos
        private IList<Lance> _lances;
        #endregion

        #region Propriedades
        public IEnumerable<Lance> Lances => _lances;

        public string Peca { get; }

        public Lance Ganhador { get; private set; }
        #endregion

        #region Construtor
        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
        }
        #endregion

        #region Métodos
        public void RecebeLance(Interessada cliente, double valor)
        {
            _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {

        }

        public void TerminaPregao()
        {
            // Ganhador é o último lance
            this.Ganhador = Lances
                .OrderBy(x => x.Valor)
                .Last();
        }
        #endregion
    }
}