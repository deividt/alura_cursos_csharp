using System;

namespace CursoDesignPatterns
{
    public class EnviadorDeSms : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("sms");
        }
    }
}