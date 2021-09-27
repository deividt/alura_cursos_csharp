using System;

namespace DesignPatterns2.Cap7
{
    public class FinalizaPedido : IComando
    {
        private Pedido pedido;

        public FinalizaPedido(Pedido pedido)
        {
            this.pedido = pedido;
        }
        
        public void Executa()
        {
            Console.WriteLine($"Finalizando o pedido do cliente {pedido.Cliente}");
            pedido.Finaliza();
        }
    }
}