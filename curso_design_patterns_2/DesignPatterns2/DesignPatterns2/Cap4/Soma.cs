using DesignPatterns2.Cap5;

namespace DesignPatterns2.Cap4
{
    public class Soma : IExpressao
    {
        public IExpressao Esquerda { get; private set; }
        public IExpressao Direita { get; private set; }

        public Soma(IExpressao esquerda, IExpressao direita)
        {
            this.Esquerda = esquerda;
            this.Direita = direita;
        }

        public int Avalia()
        {
            return this.Esquerda.Avalia() + this.Direita.Avalia();
        }

        public void Aceita(IVisitor impressoraVisitor)
        {
            impressoraVisitor.ImprimeSoma(this);
        }
    }
}