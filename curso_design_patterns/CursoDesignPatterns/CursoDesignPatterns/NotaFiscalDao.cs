using System;

namespace CursoDesignPatterns
{
    public class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("bd");
        }
    }
}