using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMyper.Data;
using PruebaTecnicaMyper.Models;

namespace PruebaTecnicaMyper.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly DataContext _context;

        public TrabajadoresController(DataContext context)
        {
            _context = context;
        }

        // GET: Trabajadores
        public async Task<IActionResult> Index(string sexo)
        {
            ViewData["SexoActual"] = sexo;

            string sql = "EXEC sp_ListarTrabajadores @p0";
            var trabajadores = await _context.Trabajadores
                .FromSqlRaw(sql, string.IsNullOrEmpty(sexo) ? (object)DBNull.Value : sexo)
                .ToListAsync();

            return View(trabajadores);
        }

        // GET: Trabajadores/Create
        public IActionResult Create() => PartialView("CrearEditar", new Trabajador());

        // POST: Trabajadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trabajador trabajador)
        {
            if (!ModelState.IsValid)
                return PartialView("CrearEditar", trabajador);

            _context.Add(trabajador);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        // GET: Trabajadores/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador == null) return NotFound();

            return PartialView("CrearEditar", trabajador);
        }

        // POST: Trabajadores/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Trabajador trabajador)
        {
            if (id != trabajador.NumDocumento) return NotFound();

            if (!ModelState.IsValid)
                return PartialView("CrearEditar", trabajador);

            _context.Update(trabajador);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        // POST: Trabajadores/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador == null)
                return Json(new { success = false, message = "No encontrado" });

            _context.Trabajadores.Remove(trabajador);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
