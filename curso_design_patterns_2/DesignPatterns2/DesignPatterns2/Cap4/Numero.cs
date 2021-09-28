using DesignPatterns2.Cap5;

namespace DesignPatterns2.Cap4
{
    public class Numero : IExpressao
    {
        public int Valor { get; private set; }

        public Numero(int numero)
        {
            this.Valor = numero;
        }

        public int Avalia()
        {
            return this.Valor;
        }

        public void Aceita(IVisitor impressoraVisitor)
        {
            impressoraVisitor.ImprimeNumero(this);
        }
    }
}