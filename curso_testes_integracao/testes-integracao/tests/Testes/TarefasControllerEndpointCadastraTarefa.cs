using System;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;

namespace Testes
{
    public class TarefasControllerEndpointCadastraTarefa
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveRetornar200()
        {
          // Arrange
          var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

          var options = new DbContextOptionsBuilder<DbTarefasContext>()
              .UseInMemoryDatabase("DbTarefasContext")
              .Options;
          var contexto = new DbTarefasContext(options);
          contexto.Categorias.Add(new Categoria(20, "Estudo"));
          
          var repo = new RepositorioTarefa(contexto);

          var controlador = new TarefasController(repo, mockLogger.Object);
          var model = new CadastraTarefaVM();
          model.IdCategoria = 20;
          model.Titulo = "Estudar xUnit";
          model.Prazo = new DateTime(2021, 12, 31);
          
          // Act
          var retorno = controlador.EndpointCadastraTarefa(model);

          // Assert
          Assert.IsType<OkResult>(retorno); // 200
        }
    }
}