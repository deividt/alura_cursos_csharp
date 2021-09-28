using System;

namespace DesignPatterns2.Cap6
{
    public class EnviaPorEmail : IEnviador
    {
        public void Envia(IMensagem mensagem)
        {
            Console.WriteLine("Enviando a mensagem por e-mail.");
            Console.WriteLine(mensagem.Formata());
        }
    }
}