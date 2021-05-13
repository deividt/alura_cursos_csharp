namespace Alura.LeilaoOnline.ConsoleApp
{
    using System;
    using Alura.LeilaoOnline.Core;

    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
                Console.ForegroundColor = defaultColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"TESTE FALHOU! Esperado {esperado}, obtido {obtido}");
            Console.ForegroundColor = defaultColor;
        }

        private static void LeilaoComVariosLances()
        {
            // Arranje
            Leilao leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 1200);

            // Act
            leilao.TerminaPregao();

            // Assert
            double valorEsperado = 1000;
            double valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }

        static void LeilaoComApenasUmLance()
        {
            // Arranje
            Leilao leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);

            // Act
            leilao.TerminaPregao();

            // Assert
            double valorEsperado = 800;
            double valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}