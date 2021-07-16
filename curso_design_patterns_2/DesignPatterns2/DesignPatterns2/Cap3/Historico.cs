using System.Collections.Generic;

namespace DesignPatterns2.Cap3
{
    public class Historico
    {
        private IList<Estado> Estados = new List<Estado>();

        public void Adiciona(Estado estado)
        {
            this.Estados.Add(estado);
        }

        public Estado Pega(int i)
        {
            return this.Estados[i];
        }
    }
}