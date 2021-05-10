using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Inicia leilão
            Leilao leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            // Lances
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);

            // Lance errado
            leilao.RecebeLance(maria, 990);

            // Finaliza pregão
            leilao.TerminaPregao();

            // Resultado
            Console.WriteLine(leilao.Ganhador.Valor);
        }
    }
}