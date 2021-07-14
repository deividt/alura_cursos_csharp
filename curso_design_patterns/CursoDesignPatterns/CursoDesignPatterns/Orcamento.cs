using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CursoDesignPatterns
{
    public class Orcamento
    {
        public int EM_APROVACAO = 1;
        public int APROVADO = 2;
        public int REPROVADO = 3;
        public int FINALIZADO = 4;

        public IEstadoDeUmOrcamento EstadoAtual { get; set; }
        
        public double Valor { get; set; }
        public IList<Item> Itens { get; private set; }

        public Orcamento(double valor)
        {
            this.Valor = valor;
            this.Itens = new List<Item>();
            this.EstadoAtual = new EmAprovacao();
        }

        public void AplicaDescontoExtra()
        {
            EstadoAtual.AplicaDescontoExtra(this);
        }
        
        public void AdicionaItem(Item item)
        {
            Itens.Add(item);
        }

        public void Aprova()
        {
            EstadoAtual.Aprova(this);
        }
        
        public void Reprova()
        {
            EstadoAtual.Reprova(this);
        }
        
        public void Finaliza()
        {
            EstadoAtual.Finaliza(this);
        }
    }
}