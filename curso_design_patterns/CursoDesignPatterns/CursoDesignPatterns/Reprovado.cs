using System;

namespace CursoDesignPatterns
{
    public class Reprovado:IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamentos reprovados não recebem desconto extra");
        }
        
        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está reprovado.");
            
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está reprovado.");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }
    }
}