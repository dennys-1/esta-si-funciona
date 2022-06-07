using Microsoft.AspNetCore.Mvc;
using hostal.Models;
using hostal.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace esta_si_funciona.Controllers
{
    public class CancelarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CancelarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexCancelar()
        {
            
            return View();
        }
        public IActionResult ListarCancelar()
        {
            return View(_context.DataCancelar.ToList());
        }

        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Motivo,Estado")] Cancelar objCancelar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objCancelar);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "Solicitud de postergación enviada";
                return RedirectToAction(nameof(IndexCancelar));
            }
            return View(objCancelar);
        }
        public IActionResult EditCancelar(int id) {
            var region = _context.DataCancelar.Find(id);
            return View(region);
        }
        [HttpPost]
        public IActionResult EditCancelar(Cancelar r) {
            if (ModelState.IsValid) {
                var region = _context.DataCancelar.Find(r.Id);               
                region.Estado=r.Estado;              
                _context.SaveChanges();
                return RedirectToAction("ListarCancelar");
            }
            return View(r);
        }

        public IActionResult Delete(int id)
        {
            Cancelar objCancelar = _context.DataCancelar.Find(id);
            _context.DataCancelar.Remove(objCancelar);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListarCancelar));
        }
    }
}