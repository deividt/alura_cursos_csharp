using System;

namespace DesignPatterns2.Cap7
{
    public class PagaPedido : IComando
    {
        private Pedido pedido;

        public PagaPedido(Pedido pedido)
        {
            this.pedido = pedido;
        }
        
        public void Executa()
        {
            Console.WriteLine($"Pagando o pedido do cliente {pedido.Cliente}");
            pedido.Paga();
        }
    }
}