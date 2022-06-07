using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hostal.Data;
using hostal.Models;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using Rotativa.AspNetCore;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace esta_si_funciona.Controllers
{
    public class ReclamosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReclamosController(ApplicationDbContext context,  UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult IndexReclamos()
        {
            
            return View();
        }
        public IActionResult ListarReclamo()
        {
            return View(_context.DataReclamos.ToList());
        }
        public async Task<IActionResult> Create([Bind("id,Dni,Nombres,Apellido,N_Celular,Correo,Reclamo")] Reclamos objReclamos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objReclamos);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "Solicitud de postergación enviada";
                return RedirectToAction(nameof(IndexReclamos));
            }
            return View(objReclamos);
        }
        public IActionResult Delete(int id)
        {
            Reclamos objReclamos = _context.DataReclamos.Find(id);
            _context.DataReclamos.Remove(objReclamos);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListarReclamo));
        }
    }
}