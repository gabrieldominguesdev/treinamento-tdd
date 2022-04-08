using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TreinamentoTDD.API.Controllers;
using TreinamentoTDD.API.Domain;
using TreinamentoTDD.API.Domain.Commands;
using TreinamentoTDD.API.Domain.Entities;
using TreinamentoTDD.API.Domain.Handlers;
using TreinamentoTDD.API.Domain.Interfaces;
using TreinamentoTDD.API.Infra;
using TreinamentoTDD.API.Infra.Repositories;
using TreinamentoTDD.API.Model;
using Xunit;

namespace TreinamentoTDD.Tests
{
    public class CadastraEventoHandlerExecute
    {
        [Fact]
        public void FactDeveIncluirEventoValidoNoBD()
        {
            #region Arrange

            var nomeEvento = "Avaliação BMA";
            var command = new CadastraEvento(nomeEvento, DateTime.Now.AddDays(5));

            var options = new DbContextOptionsBuilder<TreinamentoTDDContext>()
                .UseInMemoryDatabase("TreinamentoTDDContext")
                .Options;

            var context = new TreinamentoTDDContext(options);
            var repository = new EventoRepository(context);

            var handler = new CadastraEventoHandler(repository);

            #endregion

            #region Act

            handler.Execute(command);

            #endregion

            #region Assert

            var evento = repository.RecuperarEventos(t => t.Nome == nomeEvento).FirstOrDefault();
            Assert.NotNull(evento);
            //Assert.Null(evento);

            #endregion
        }

        [Fact]
        public void QuandoExceptionForLancadaIsSuccessfulDeveConterValorFalse()
        {
            #region Arrange

            var nomeEvento = "Almoço BMA";
            var command = new CadastraEvento(nomeEvento, DateTime.Now.AddDays(6));

            var mockRepository = new Mock<IEventoRepository>();

            mockRepository.Setup(r => r.CriarEventos(It.IsAny<IEnumerable<Evento>>()))
                .Throws(new Exception("Erro ao cadastrar eventos"));

            var repository = mockRepository.Object;

            var handler = new CadastraEventoHandler(repository);

            #endregion

            #region Act

            OperationResult resultado = handler.Execute(command);

            #endregion

            #region Assert

            Assert.False(resultado.IsSuccessful);
            //Assert.True(resultado.IsSuccessful);

            #endregion
        }

        [Theory]
        [InlineData("Rolé com a galera")]
        public void TheoryDeveIncluirEventoValidoNoBD(string nomeEvento)
        {
            #region Arrange

            var command = new CadastraEvento(nomeEvento, DateTime.Now.AddDays(5));

            var options = new DbContextOptionsBuilder<TreinamentoTDDContext>()
                .UseInMemoryDatabase("TreinamentoTDDContext")
                .Options;
            var context = new TreinamentoTDDContext(options);
            var repository = new EventoRepository(context);

            var handler = new CadastraEventoHandler(repository);

            #endregion

            #region Act

            handler.Execute(command);

            #endregion

            #region Assert

            var evento = repository.RecuperarEventos(t => t.Nome == nomeEvento).FirstOrDefault();
            Assert.NotNull(evento);
            //Assert.Null(evento);

            #endregion
        }
    }
}