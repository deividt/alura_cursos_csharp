using System;
using System.Linq;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            // Arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbCadastrarTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repositorio = new RepositorioTarefa(contexto);
            
            var handler = new CadastraTarefaHandler(repositorio);

            // Act
            handler.Execute(comando);

            // Assert
            var tarefa = repositorio.ObtemTarefas(t => t.Titulo == "Estudar xUnit").FirstOrDefault();
            Assert.NotNull(tarefa);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveserFalso()
        {
            // Arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).
                Throws(new Exception("Houve um erro na inclusão de tarefas"));
            var repo = mock.Object;
            
            var handler = new CadastraTarefaHandler(repo);

            // Act
            CommandResult resultado = handler.Execute(comando);

            // Assert
            Assert.False(resultado.IsSuccess);
        }
    }
}