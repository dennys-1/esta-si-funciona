using Microsoft.AspNetCore.Mvc;
using hostal.Models;
using hostal.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace hostal.Controllers
{
    public class PaquetesController:Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public PaquetesController(ApplicationDbContext context,  UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var paquetes = from o in _context.DataPaquetes select o;
            return View(await paquetes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            Paquetes objpaquetes = await _context.DataPaquetes.FindAsync(id);
            if(objpaquetes == null){
                return NotFound();
            }
            return View(objpaquetes);
        }

       public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de seleccionar un paquete promocional";
                List<Paquetes> paquetes = new List<Paquetes>();
                return  View("Index",paquetes);
            }else{
                var Paquetes = await _context.DataPaquetes.FindAsync(id);
                ProformaPaquetes ProformaPaquetes = new ProformaPaquetes();
                ProformaPaquetes.Paquetes= Paquetes;
                ProformaPaquetes.Precio = Paquetes.Precio;
                ProformaPaquetes.Quantity = 1;
                ProformaPaquetes.UserID = userID;
                _context.Add(ProformaPaquetes);                
                /*AGREGAR ID TABLA PROFORMASS*/
                var proformapq = from o in _context.DataProformaPaquetes select o;
                proformapq = proformapq.
                Include(p => p.Id).
                Where(s => s.UserID.Equals(ProformaPaquetes.UserID));

                Proformass proformass = new Proformass();

                proformass.ProformaPaquetes = ProformaPaquetes;     
                _context.Add(proformass);          
                

                /************************GUARDAR 0 EN PRODUCTO*************************/

                var producto = await _context.DataProducts.FindAsync(id=0);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Precio;
                proforma.Quantity = 0;
                proforma.UserID = userID;
                _context.Add(proforma);                
                /*AGREGAR ID TABLA PROFORMASS*/
                var proformap = from o in _context.DataProforma select o;
                proformap = proformap.
                Include(p => p.Id).
                Where(s => s.UserID.Equals(proforma.UserID));

                proformass.Proforma = proforma;                
                 _context.Add(proformass);
                
                          
                /************************GUARDAR 0 EN SERVICIO*************************/

                var servicio = await _context.DataServicios.FindAsync(id=0);
                ProformaServi ProformaServi = new ProformaServi();
                ProformaServi.Servicio = servicio;
                ProformaServi.Precio = servicio.Precio;
                ProformaServi.Quantity = 0;
                ProformaServi.UserID = userID;
                _context.Add(ProformaServi);
                 /*AGREGAR ID TABLA PROFORMASS*/
                 var proformas = from o in _context.DataProformaServi select o;
                proformas = proformas.
                Include(p => p.Id).
                Where(s => s.UserID.Equals(ProformaServi.UserID));

                proformass.ProformaServi = ProformaServi;
                _context.Add(proformass);



                await _context.SaveChangesAsync();


                return  RedirectToAction(nameof(Index));
                
            }
        }




public async Task<IActionResult> ListarPaquetes()
        {
            return View(await _context.DataPaquetes.ToListAsync());
        }


// GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Producto,Servicio,Descripción,Precio,Imagen,Estado")] Paquetes Paquetes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Paquetes);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "Paquete creado";
                return RedirectToAction(nameof(ListarPaquetes));
            }
            return View(Paquetes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paquetes = await _context.DataPaquetes.FindAsync(id);
            if (Paquetes == null)
            {
                return NotFound();
            }
            return View(Paquetes);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,Producto,Servicio,Descripción,Precio,Imagen,Estado")] Paquetes Paquetes)
        {
            if (id != Paquetes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Paquetes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaquetesExists(Paquetes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListarPaquetes));
            }
            return View(Paquetes);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paquetes = await _context.DataPaquetes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Paquetes == null)
            {
                return NotFound();
            }

            return View(Paquetes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Paquetes = await _context.DataPaquetes.FindAsync(id);
            _context.DataPaquetes.Remove(Paquetes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListarPaquetes));
        }

        private bool PaquetesExists(int id)
        {
            return _context.DataPaquetes.Any(e => e.Id == id);
        }
    }

}

