using System;

namespace CursoDesignPatterns
{
    public class Item
    {
        public String Nome { get; private set; }

        public double Valor { get; private set; }

        public Item(String nome, double valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }
    }
}