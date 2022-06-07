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
    public class CatalogoController:Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public CatalogoController(ApplicationDbContext context,  UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.DataProducts select o;
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            Product objProduct = await _context.DataProducts.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

       public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de realizar una reserva";
                List<Product> productos = new List<Product>();
                return  View("Index",productos);
            }else{
                var producto = await _context.DataProducts.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Precio;
                proforma.Quantity = 1;
                proforma.UserID = userID;
                _context.Add(proforma);                
                /*AGREGAR ID TABLA PROFORMASS*/
                var proformap = from o in _context.DataProforma select o;
                proformap = proformap.
                Include(p => p.Id).
                Where(s => s.UserID.Equals(proforma.UserID));

                Proformass proformass = new Proformass();

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
                

                /************************GUARDAR 0 EN PAQUETES*************************/

                var Paquetes = await _context.DataPaquetes.FindAsync(id=0);
                ProformaPaquetes ProformaPaquetes = new ProformaPaquetes();
                ProformaPaquetes.Paquetes= Paquetes;
                ProformaPaquetes.Precio = Paquetes.Precio;
                ProformaPaquetes.Quantity = 0;
                ProformaPaquetes.UserID = userID;
                _context.Add(ProformaPaquetes); 
                 /*AGREGAR ID TABLA PROFORMASS*/
                 var proformapq = from o in _context.DataProformaPaquetes select o;
                proformapq = proformapq.
                Include(p => p.Id).
                Where(s => s.UserID.Equals(ProformaPaquetes.UserID));

                proformass.ProformaPaquetes = ProformaPaquetes;
                _context.Add(proformass);

                
                await _context.SaveChangesAsync();


                return  RedirectToAction(nameof(Index));
                
            }
        }

        }

    }