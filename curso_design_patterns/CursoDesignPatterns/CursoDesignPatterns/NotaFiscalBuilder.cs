using System;
using System.Collections;
using System.Collections.Generic;

namespace CursoDesignPatterns
{
    public class NotaFiscalBuilder
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }

        public string Observacoes { get; private set; }

        public DateTime Data { get; private set; }

        private double valorTotal;
        private double impostos;
        private IList<ItemDaNota> todosItens = new List<ItemDaNota>();

        private IList<IAcaoAposGerarNota> todasAcoesASeremExecutadas = new List<IAcaoAposGerarNota>();

        public NotaFiscal Constroi()
        {
            NotaFiscal nf = new NotaFiscal(RazaoSocial, Cnpj,Data,valorTotal,impostos,todosItens,Observacoes);

            foreach (IAcaoAposGerarNota acao in todasAcoesASeremExecutadas)
            {
                acao.Executa(nf);
            }

            return nf;
        }

        public void AdicionaAcao(IAcaoAposGerarNota acao)
        {
            this.todasAcoesASeremExecutadas.Add(acao);
        }

        public NotaFiscalBuilder ParaEmpresa(string razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder ComCnpj(string cnpj)
        {
            this.Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder ComObservacoes(string observacoes)
        {
            this.Observacoes = observacoes;
            return this;
        }

        public NotaFiscalBuilder NaDataAtual()
        {
            this.Data = DateTime.Now;
            return this;
        }

        public NotaFiscalBuilder ComItem(ItemDaNota item)
        {
            todosItens.Add(item);
            valorTotal += item.Valor;
            impostos += item.Valor * 0.05;
            return this;
        }
    }
}