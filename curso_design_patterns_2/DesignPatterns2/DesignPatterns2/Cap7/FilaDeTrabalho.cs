using System.Collections.Generic;

namespace DesignPatterns2.Cap7
{
    public class FilaDeTrabalho
    {
        private IList<IComando> comandos = new List<IComando>();

        public void Adiciona(IComando comando)
        {
            this.comandos.Add(comando);
        }

        public void Processa()
        {
            foreach (var comando in comandos)
            {
                comando.Executa();
            }
        }
    }
}