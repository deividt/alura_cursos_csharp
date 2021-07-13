namespace CursoDesignPatterns
{
    public class SemDesconto:IDesconto
    {
        public double Desconta(Orcamento orcamento)
        {
            return 0;
        }

        public IDesconto Proximo { get; set; }
    }
}