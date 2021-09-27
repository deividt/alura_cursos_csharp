using System;

namespace DesignPatterns2.Cap6
{
    public class MensagemCliente : IMensagem
    {
        public IEnviador Enviador { get; set; }
        private string nome;

        public MensagemCliente(string nome)
        {
            this.nome = nome;
        }

        public void Envia()
        {
            this.Enviador.Envia(this);
        }

        public string Formata()
        {
            return $"Enviando a mensagem para o cliente {this.nome}";
        }
    }
}