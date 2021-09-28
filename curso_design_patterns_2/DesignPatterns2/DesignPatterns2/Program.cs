using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Serialization;
using DesignPatterns2.Cap1;
using DesignPatterns2.Cap2;
using DesignPatterns2.Cap3;
using DesignPatterns2.Cap4;
using DesignPatterns2.Cap5;
using DesignPatterns2.Cap6;
using DesignPatterns2.Cap7;
using DesignPatterns2.Cap8;
using DesignPatterns2.Cap9;

namespace DesignPatterns2
{
    class Program
    {
        static void Main(string[] args)
        {
            // FactoryPattern();

            // FlyweightPattern();

            //MementoPattern();

            // Interpreter();

            //Visitor();

            //Bridges();

            //DifferentActionsWithCommand();

            //Adapter();

            FacadesSingleton();

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        private static void FacadesSingleton()
        {
            string cpf = "1234";
            EmpresaFacade facade = new EmpresaFacadeSingleton().Instancia;

            Cliente cliente = facade.BuscaCliente(cpf);
            Fatura fatura = facade.CriaFatura(cliente, 5000);
            Cobranca cobranca = facade.GeraCobranca(TipoBoleto, fatura);
            ContatoCliente contato = facade.FazContato(cliente, cobranca);
        }

        private static void Adapter()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Deividt";
            cliente.Endereco = "Rua Jose Firmo Bernardi";
            cliente.DataDeNascimento = DateTime.Now;

            string xml = new GeradorDeXml().GeraXml(cliente);
            
            Console.WriteLine(xml);
        }

        private static void DifferentActionsWithCommand()
        {
            FilaDeTrabalho fila = new FilaDeTrabalho();
            Pedido pedido1 = new Pedido("Deividt", 100);
            Pedido pedido2 = new Pedido("Dani", 200);
            fila.Adiciona(new PagaPedido(pedido1));
            fila.Adiciona(new PagaPedido(pedido2));
            
            fila.Adiciona(new FinalizaPedido(pedido1));
            fila.Adiciona(new FinalizaPedido(pedido2));
            
            fila.Processa();
        }

        private static void Bridges()
        {
            IMensagem mensagem = new MensagemAdministrativa( "Deividt");
            IEnviador enviador = new EnviaPorEmail();
            mensagem.Enviador = enviador;
            mensagem.Envia();
            
            IMensagem mensagem2 = new MensagemCliente( "Deividt");
            IEnviador enviador2 = new EnviaPorSms();
            mensagem2.Enviador = enviador2;
            mensagem2.Envia();
        }

        private static void Visitor()
        {
            // (1 + 10) + (20 - 10)
            // + 1 100
            IExpressao esquerda = new Soma(new Numero(1), new Numero(10));
            IExpressao direita = new Subtracao(new Numero(20), new Numero(10));
            IExpressao soma = new Soma(esquerda, direita);
            Console.WriteLine(soma.Avalia());
            
            ImpressoraVisitor impressoraVisitor = new ImpressoraVisitor();
            soma.Aceita(impressoraVisitor);
            Console.WriteLine();
        }

        private static void Interpreter()
        {
            // ((1 + 100) + 10) + (20 - 10)
            IExpressao esquerda = new Soma(new Soma( new Numero(1), new Numero(100)), new Numero(10));
            IExpressao direita = new Subtracao(new Numero(20), new Numero(10));
            IExpressao soma = new Soma(esquerda, direita);
            Console.WriteLine(soma.Avalia());

            Expression exSoma = Expression.Add(Expression.Constant(10), Expression.Constant(100));
            Func<int> funcao = Expression.Lambda<Func<int>>(exSoma).Compile();
            Console.WriteLine(funcao());
        }

        private static void FactoryPattern()
        {
            IDbConnection conexao = new ConnectionFactory().GetConnection();
            IDbCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tabela";
        }

        private static void FlyweightPattern()
        {
            NotasMusicais notas = new NotasMusicais();
            IList<INota> musica = new List<INota>()
            {
                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("mi"),
                notas.Pega("fa"),
                notas.Pega("fa"),
                notas.Pega("fa")
            };

            Piano piano = new Piano();
            piano.Toca(musica);
        }
        
        private static void MementoPattern()
        {
            Historico historico = new Historico();

            Contrato c = new Contrato(DateTime.Now, "Eu",TipoContrato.Novo);
            historico.Adiciona(c.SalvaEstado());
            
            c.Avanca();
            historico.Adiciona(c.SalvaEstado());
            
            c.Avanca();
            historico.Adiciona(c.SalvaEstado());
            
            //Console.WriteLine(c.Tipo);
            Console.WriteLine(historico.Pega(2).Contrato.Tipo);
        }
    }
}