using System;
using System.Collections;
using System.Collections.Generic;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // StrategyPattern();

            //ChainOfResponsibilityPattern();

            //TemplateMethodPattern();

            //DecoratorPattern();

            //StatePattern();

            //BuilderPattern();
            
            ObserverPattern();

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

        private static void StatePattern()
        {
            Orcamento reforma = new Orcamento(500);

            Console.WriteLine(reforma.Valor);

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Aprova();

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Finaliza();

            // Deve retornar exception
            // reforma.AplicaDescontoExtra();
        }
        
        private static void BuilderPattern()
        {
            NotaFiscalBuilder criador = new NotaFiscalBuilder();
            criador
                .ParaEmpresa("Empresa Teste")
                .ComCnpj("3.456.789/0001-12")
                .ComItem(new ItemDaNota("item 1", 100.0))
                .ComItem(new ItemDaNota("item 2", 200.0))
                .NaDataAtual()
                .ComObservacoes("Obs qualquer");

            NotaFiscal nf = criador.Constroi();

            Console.WriteLine(nf.ValorBruto);
            Console.WriteLine(nf.Impostos);
        }
        
        private static void ObserverPattern()
        {
            NotaFiscalBuilder criador = new NotaFiscalBuilder();
            criador
                .ParaEmpresa("Empresa Teste")
                .ComCnpj("3.456.789/0001-12")
                .ComItem(new ItemDaNota("item 1", 100.0))
                .ComItem(new ItemDaNota("item 2", 200.0))
                .NaDataAtual()
                .ComObservacoes("Obs qualquer");
            
            criador.AdicionaAcao(new EnviadorDeEmail());
            criador.AdicionaAcao(new NotaFiscalDao());
            criador.AdicionaAcao(new EnviadorDeSms());

            NotaFiscal nf = criador.Constroi();

            Console.WriteLine(nf.ValorBruto);
            Console.WriteLine(nf.Impostos);
        }
    }
}