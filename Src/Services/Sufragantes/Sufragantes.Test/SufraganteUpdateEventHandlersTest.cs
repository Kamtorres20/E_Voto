using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sufragantes.Domain;
using Sufragantes.Service.EventHandlers;
using Sufragantes.Service.EventHandlers.Command;
using Sufragantes.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sufragantes.Test
{
    [TestClass]
    public class SufraganteUpdateEventHandlersTest
    {
        private ILogger<SufraganteUpdateEventHandlers> GetLogger
        {
            get
            {
                return new Mock<ILogger<SufraganteUpdateEventHandlers>>()
                    .Object;
            }
        }

        [TestMethod]
        public void TryToModifySufragant()
        {
            var context = ApplicationDbContextInMemory.Get();

            int Tipo_Identificacion = 1;
            string Identificacion = "123456789";
            string Nombres = "123456789";
            string Apellidos = "123456789";
            DateTime FechaNacimiento = Convert.ToDateTime("1990-04-08");
            int Sexo = 1;
            string CorreoElectronico = "123456789";


            context.tbl_Sufragantes.Add(new Sufragante
            {
                Tipo_Identificacion = Tipo_Identificacion,
                Identificacion = Identificacion,
                Nombres = Nombres,
                Apellidos = Apellidos,
                FechaNacimiento = FechaNacimiento,
                Sexo = Sexo,
                CorreoElectronico = CorreoElectronico
            });

            context.SaveChanges();

            var handler = new SufraganteUpdateEventHandlers(context, GetLogger);

            handler.Handle(new SufraganteUpdateCommand
            {
                Tipo_Identificacion = Tipo_Identificacion,
                Identificacion = Identificacion,
                Nombres = "Andres",
                Apellidos = Apellidos,
                FechaNacimiento = FechaNacimiento,
                Sexo = 2,
                CorreoElectronico = CorreoElectronico

            }, new CancellationToken()).Wait();
        }

    }
}
