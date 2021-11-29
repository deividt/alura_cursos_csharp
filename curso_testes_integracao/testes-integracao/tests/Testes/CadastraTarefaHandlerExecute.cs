using System;
using System.Linq;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbCadastrarTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repositorio = new RepositorioTarefa(contexto);
            
            var handler = new CadastraTarefaHandler(repositorio, mockLogger.Object);

            // Act
            handler.Execute(comando);

            // Assert
            var tarefa = repositorio.ObtemTarefas(t => t.Titulo == "Estudar xUnit").FirstOrDefault();
            Assert.NotNull(tarefa);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
        {
            // Arrange
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));
            
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).
                Throws(new Exception("Houve um erro na inclusão de tarefas"));
            var repo = mock.Object;
            
            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            // Act
            CommandResult resultado = handler.Execute(comando);

            // Assert
            Assert.False(resultado.IsSuccess);
        }

        delegate void CapturaMensagemLog(
            LogLevel logLevel,
            EventId eventId,
            object state,
            Exception exception,
            Func<object, Exception, string> function);

        [Fact]
        public void DadaTarefaComInfoValidasDeveLogar()
        {
            // Arrange
            var tituloTarefaEsperado = "Usar Moq para aprofuncar conhecimento de API";
            var comando = new CadastraTarefa(tituloTarefaEsperado, new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();
            
            LogLevel levelCapturado = LogLevel.Error;
            string mensagemCapturada = String.Empty;
            CapturaMensagemLog captura = (level, eventId, state, exception, func) =>
            {
                levelCapturado = level;
                mensagemCapturada = func(state, exception);
            };

            mockLogger.Setup(l => 
                l.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(), 
                    It.IsAny<object>(), 
                    It.IsAny<Exception>(), 
                    It.IsAny<Func<object, Exception, string>>())
                ).Callback(captura);
            
            var mock = new Mock<IRepositorioTarefas>();
            
            var handler = new CadastraTarefaHandler(mock.Object, mockLogger.Object);

            // Act
            handler.Execute(comando);

            // Assert
            Assert.Equal(LogLevel.Error, levelCapturado);
            Assert.Contains(tituloTarefaEsperado, mensagemCapturada);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExcecao()
        {
            // Arrange
            var mensagemDeErroEsperada = "Houve um erro na inclusão de tarefas";
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 31));
            var excecaoEsperada = new Exception(mensagemDeErroEsperada);
            
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).
                Throws(excecaoEsperada);
            var repo = mock.Object;
            
            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            // Act
            CommandResult resultado = handler.Execute(comando);
            
            // Assert
            mockLogger.Verify(l => 
                    l.Log(
                        LogLevel.Error,
                        It.IsAny<EventId>(), 
                        It.IsAny<object>(), 
                        excecaoEsperada, 
                        It.IsAny<Func<object, Exception, string>>()), 
                Times.Once());
        }
    }
}