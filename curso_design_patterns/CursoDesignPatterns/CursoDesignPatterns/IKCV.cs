namespace CursoDesignPatterns
{
    public class IKCV:TemplateDeImpostoCondicional
    {
        public IKCV(Imposto outroImposto) : base(outroImposto)
        {
        }

        public IKCV() : base()
        {
        }

        public override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500 && temItemMaiorQue100ReaisNo(orcamento);
        }

        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.01;
        }
       
        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
        

        private bool temItemMaiorQue100ReaisNo(Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Valor > 100)
                {
                    return true;
                }
            }

            return false;
        }
    }
}