namespace DesignPatterns2.Cap4
{
    public class Subtracao : IExpressao
    {
        private IExpressao esquerda;
        private IExpressao direita;
        
        public Subtracao(IExpressao esquerda, IExpressao direita)
        {
            this.esquerda = esquerda;
            this.direita = direita;
        }

        public int Avalia()
        {
            return this.esquerda.Avalia() - this.direita.Avalia();
        }
    }
}