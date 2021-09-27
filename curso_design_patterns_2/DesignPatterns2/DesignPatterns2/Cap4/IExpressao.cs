using DesignPatterns2.Cap5;

namespace DesignPatterns2.Cap4
{
    public interface IExpressao
    {
        int Avalia();

        void Aceita(IVisitor impressoraVisitor);
    }
}