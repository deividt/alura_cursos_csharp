using System;
using System.Data;
using System.Data.SqlClient;
using DesignPatterns2.Cap1;

namespace DesignPatterns2
{
    class Program
    {
        static void Main(string[] args)
        {
            // FactoryPattern();
            
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        private static void FactoryPattern()
        {
            IDbConnection conexao = new ConnectionFactory().GetConnection();
            IDbCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tabela";
        }
    }
}