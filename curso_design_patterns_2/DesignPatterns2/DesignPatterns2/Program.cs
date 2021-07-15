using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DesignPatterns2.Cap1;
using DesignPatterns2.Cap2;

namespace DesignPatterns2
{
    class Program
    {
        static void Main(string[] args)
        {
            // FactoryPattern();

            FlyweightPattern();

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
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
    }
}