using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sufragantes.Service.EventHandlers;
using Sufragantes.Service.EventHandlers.Command;
using Sufragantes.Tests.Config;
using System;
using System.Threading;

namespace Sufragantes.Test
{
    [TestClass]
    public class SufraganteCreateEventHandlersTest
    {
        private ILogger<SufraganteCreateEventHandlers> GetLogger
        {
            get
            {
                return new Mock<ILogger<SufraganteCreateEventHandlers>>()
                    .Object;
            }
        }

        [TestMethod]
        public void TryToAddSufraganteNew()
        {
            var context = ApplicationDbContextInMemory.Get();

            int Tipo_Identificacion = 1;
            string Identificacion = "123456789";
            string Nombres = "123456789";
            string Apellidos = "123456789";
            DateTime FechaNacimiento = Convert.ToDateTime("1990-04-08");
            int Sexo = 1;
            string CorreoElectronico = "123456789";


            var handler = new SufraganteCreateEventHandlers(context, GetLogger);

            handler.Handle(new SufraganteCreateCommand
            {
                Tipo_Identificacion = Tipo_Identificacion,
                Identificacion = Identificacion,
                Nombres = Nombres,
                Apellidos = Apellidos,
                FechaNacimiento = FechaNacimiento,
                Sexo = Sexo,
                CorreoElectronico = CorreoElectronico

            }, new CancellationToken()).Wait();
        }
    }
}
