using System;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // StrategyPattern();

            ChainOfResponsibilityPattern();

            Console.WriteLine("Press any key to close!");
            Console.ReadKey();
        }

        public static void StrategyPattern()
        {
            IImposto iss = new ISS();
            IImposto icms = new ICMS();

            Orcamento orcamento = new Orcamento(500.0);

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, iss);
            calculador.RealizaCalculo(orcamento, icms);
        }

        public static void ChainOfResponsibilityPattern()
        {
            CalculadorDeDescontos calculadorDeDescontos = new CalculadorDeDescontos();

            Orcamento orcamento = new Orcamento(1500);
            orcamento.AdicionaItem(new Item("CANETA", 250));
            orcamento.AdicionaItem(new Item("LAPIS", 250));
            orcamento.AdicionaItem(new Item("GELADEIRA", 250));
            orcamento.AdicionaItem(new Item("FOGAO", 250));
            orcamento.AdicionaItem(new Item("MICROONDAS", 250));
            orcamento.AdicionaItem(new Item("XBOX", 250));

            double desconto = calculadorDeDescontos.Calcula(orcamento);
            Console.WriteLine(desconto);
        }
    }
}