using System;
using System.Collections.Generic;
using System.Linq;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;

namespace Testes
{
    public class RepositorioFake : IRepositorioTarefas
    {
        private List<Tarefa> lista = new List<Tarefa>();
        
        public void IncluirTarefas(params Tarefa[] tarefas)
        {
            tarefas.ToList().ForEach(t => lista.Add(t));
        }

        public void AtualizarTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public void ExcluirTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public Categoria ObtemCategoriaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefa> ObtemTarefas(Func<Tarefa, bool> filtro)
        {
            return lista.Where(filtro);
        }
    }
}