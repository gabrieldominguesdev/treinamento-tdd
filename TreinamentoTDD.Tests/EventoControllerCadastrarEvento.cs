using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoTDD.API.Controllers;
using TreinamentoTDD.API.Infra;
using TreinamentoTDD.API.Infra.Repositories;
using TreinamentoTDD.API.Model;
using Xunit;

namespace TreinamentoTDD.Tests
{
    public class EventoControllerCadastrarEvento
    {
        [Fact]
        public void DeveRetornarStatusCode200NaInclusaoDeEventoValido()
        {
            #region Arrange

            var options = new DbContextOptionsBuilder<TreinamentoTDDContext>()
                .UseInMemoryDatabase("TreinamentoTDDContext")
                .Options;
            var context = new TreinamentoTDDContext(options);

            var repository = new EventoRepository(context);

            var controller = new EventoController(repository);
            var model = new CadastraEventoModel
            {
                Nome = "Mizu após o expediente",
                Data = DateTime.Now
            };

            #endregion

            #region Act

            var retorno = controller.CadastrarEvento(model);

            #endregion

            #region Assert

            Assert.IsType<OkResult>(retorno);
            //Assert.IsType<BadRequestResult>(retorno);

            #endregion
        }
    }
}
