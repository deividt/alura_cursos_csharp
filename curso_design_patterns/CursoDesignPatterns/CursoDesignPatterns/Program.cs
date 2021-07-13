﻿using System;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // StrategyPattern();

            //ChainOfResponsibilityPattern();

            //TemplateMethodPattern();

            DecoratorPattern();

            Console.WriteLine("Press any key to close!");
            Console.ReadKey();
        }
        
        private static void StrategyPattern()
        {
            Imposto iss = new ISS();
            Imposto icms = new ICMS();

            Orcamento orcamento = new Orcamento(500.0);

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, iss);
            calculador.RealizaCalculo(orcamento, icms);
        }

        private static void ChainOfResponsibilityPattern()
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
        
        private static void TemplateMethodPattern()
        {
            Imposto ikcv = new IKCV();
            Imposto icpp = new ICPP();

            Orcamento orcamento = new Orcamento(1200.0);

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, ikcv);
            calculador.RealizaCalculo(orcamento, icpp);
            
        }
        
        private static void DecoratorPattern()
        {
            Imposto iss = new ISS(new ICMS(new IKCV()));

            Orcamento orcamento = new Orcamento(500.0);

            double valor = iss.Calcula(orcamento);
            Console.WriteLine(valor);
        }
    }
}