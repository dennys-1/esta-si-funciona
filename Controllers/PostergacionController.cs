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

namespace hostal.Controllers
{
    public class PostergacionController:Controller
    {
        private readonly ApplicationDbContext _context;

        public PostergacionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Indexpostergacion()
        {
            
            return View();
        }

        
        public IActionResult Listarpostergacion()
        {
            return View(_context.DataPostergacion.ToList());
        }

      
    public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Motivo,Estado")] Postergacion objPostergacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objPostergacion);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "Solicitud de postergación enviada";
                return RedirectToAction(nameof(Indexpostergacion));
            }
            return View(objPostergacion);
        }

       /*public IActionResult Editpostergacion(int id)
        {
            Postergacion objPostergacion = _context.DataPostergacion.Find(id);
            if(objPostergacion == null){
                return NotFound();
            }
            return View(objPostergacion);
        }

        [HttpPost]
        public IActionResult Editpostergacion(int id,[Bind("Id,Nombre,Fecha,Motivo,Estado")] Postergacion objPostergacion)
        {
             _context.Update(objPostergacion);
             _context.SaveChanges();
              ViewData["Message"] = "La postergación fue validada";
             return View(Listarpostergacion);
        }*/
        public IActionResult Editpostergacion(int id) {
            var region = _context.DataPostergacion.Find(id);
            return View(region);
        }

        [HttpPost]
        public IActionResult Editpostergacion(Postergacion r) {
            if (ModelState.IsValid) {
                var region = _context.DataPostergacion.Find(r.Id);               
                region.Estado=r.Estado;              
                _context.SaveChanges();
                return RedirectToAction("Listarpostergacion");
            }
            return View(r);
        }

        public IActionResult Delete(int id)
        {
            Postergacion objPostergacion = _context.DataPostergacion.Find(id);
            _context.DataPostergacion.Remove(objPostergacion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Listarpostergacion));
        }
    }
}