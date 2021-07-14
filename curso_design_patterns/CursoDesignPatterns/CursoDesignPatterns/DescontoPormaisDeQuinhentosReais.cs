namespace CursoDesignPatterns
{
    public class DescontoPormaisDeQuinhentosReais : IDesconto
    {
        public double Desconta(Orcamento orcamento)
        {
            if (orcamento.Valor > 500)
            {
                return orcamento.Valor * 0.07;
            }

            return Proximo.Desconta(orcamento);
        }

        public IDesconto Proximo { get; set; }
    }
}