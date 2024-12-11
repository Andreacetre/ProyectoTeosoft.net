using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeoSoft.Data;
using TeoSoft.Models;

namespace TeoSoft.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ventas.Include(v => v.Cliente).Include(v => v.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.VentaId == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            var venta = new Venta { Fecha = DateTime.Now, Estado = "Pendiente" };
            PrepareViewData(venta);
            return View(venta);
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,Fecha,Total,ClienteId,IdProducto,Estado")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                var producto = await _context.Productos.FindAsync(venta.IdProducto);
                if (producto == null)
                {
                    return Json(new { success = false, message = "El producto seleccionado no es válido." });
                }

                venta.Total = producto.Precio;
                venta.Fecha = DateTime.Now;

                _context.Add(venta);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "La venta ha sido creada exitosamente." });
            }

            return Json(new { success = false, message = "Hubo un error al crear la venta. Por favor, revise los datos ingresados." });
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            PrepareViewData(venta);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaId,Fecha,Total,ClienteId,IdProducto,Estado")] Venta venta)
        {
            if (id != venta.VentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.VentaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PrepareViewData(venta);
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return Json(new { success = false, message = "La venta no fue encontrada." });
            }

            try
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "La venta ha sido eliminada exitosamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error al eliminar la venta: " + ex.Message });
            }
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }

        private void PrepareViewData(Venta venta)
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "ProductoId", "Nombre", venta.IdProducto);
            ViewData["EstadoOptions"] = new List<SelectListItem>
            {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Completada", Text = "Completada" },
                new SelectListItem { Value = "Anulada", Text = "Anulada" }
            };
        }

        // GET: Ventas/GetVentaDetails/5
        public async Task<IActionResult> GetVentaDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (venta == null)
            {
                return NotFound();
            }

            return Json(new
            {
                ventaId = venta.VentaId,
                clienteNombre = venta.Cliente.Nombre,
                productoId = venta.IdProducto,
                productoNombre = venta.Producto.Nombre,
                cantidad = 1, // Por defecto, se puede ajustar según sea necesario
                fecha = venta.Fecha.ToString("yyyy-MM-dd")
            });
        }
    }
}