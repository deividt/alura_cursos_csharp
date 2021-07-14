using System;

namespace CursoDesignPatterns
{
    public class EnviadorDeEmail : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("E-mail");
        }
    }
}