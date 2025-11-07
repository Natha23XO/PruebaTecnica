using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMyper.Controllers;
using PruebaTecnicaMyper.Models;
using PruebaTecnicaMyper.Data;

namespace PruebaTecnica.Tests.Controllers
{
    public class TrabajadoresControllerTests
    {

        [Fact]
        public async Task validarTrabajador()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("Test")
                .Options;

            using var context = new DataContext(options);
            var controller = new TrabajadoresController(context);

            var trabajador = new Trabajador {
                NumDocumento = "74226963",
                Nombres = "Hugo",
                Apellidos = "Castro",
                TipoDocumento = "DNI",
                Sexo = "Masculino",
                Direccion = "Av Peru 123",
                Foto = "img.png"
            };

            var result = await controller.Create(trabajador);

            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.NotNull(jsonResult.Value);

            var data = jsonResult.Value.GetType().GetProperty("success")?.GetValue(jsonResult.Value, null);
            Assert.True((bool)data);
        }
        
    }
}
