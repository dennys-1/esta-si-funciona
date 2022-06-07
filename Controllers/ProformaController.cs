using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hostal.Data;
using hostal.Models;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;


namespace hostal.Controllers
{
    public class ProformaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
               // GET: Proforma
        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserName(User);
           
            var items = from o in _context.DataProformass select o;
            items = items.
                Include(p => p.Proforma.Producto).
                Include(p => p.ProformaServi.Servicio).
                Include(p => p.ProformaPaquetes.Paquetes).
                Where(s => s.Proforma.UserID.Equals(userID)  && s.Proforma.Status.Equals("PENDIENTE") && s.ProformaServi.UserID.Equals(userID) && s.ProformaServi.Status.Equals("PENDIENTE")&& s.ProformaPaquetes.UserID.Equals(userID) && s.ProformaPaquetes.Status.Equals("PENDIENTE"));
                
            var elements = await items.ToListAsync();  
            return View(elements);

        }
        
       //-----------------------------------ELIMINAR
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proformass = await _context.DataProformass.FindAsync(id);
            _context.DataProformass.Remove(proformass);

            var proformaser = await _context.DataProformaServi.FindAsync(id);
            _context.DataProformaServi.Remove(proformaser);

             var proforma = await _context.DataProforma.FindAsync(id);
            _context.DataProforma.Remove(proforma);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //-----------------------------------EDITAR PROFOMA PRODUCTO/HABITACION
        // GET: Proforma/Edit/5
        public IActionResult Edit(int id) {
            var region = _context.DataProforma.Find(id);
            return View(region);
        }

        [HttpPost]
        public IActionResult Edit(Proforma r) {
            if (ModelState.IsValid) {
                var region = _context.DataProforma.Find(r.Id);               
                region.Quantity=r.Quantity;              
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }

        //-----------------------------------EDITAR PROFORMA SERVICIOS

        public IActionResult Edits(int id) {
            var region2 = _context.DataProformaServi.Find(id);
            return View(region2);
        }

        [HttpPost]
        public IActionResult Edits(ProformaServi r) {
            if (ModelState.IsValid) {
                var region2 = _context.DataProformaServi.Find(r.Id);               
                region2.Quantity=r.Quantity;              
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }

    }
}