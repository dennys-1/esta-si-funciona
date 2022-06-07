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
using OfficeOpenXml;
using OfficeOpenXml.Table;
using Rotativa.AspNetCore;

namespace hostal.Controllers
{
    public class PagoyapeController : Controller 
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PagoyapeController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Createyape(Decimal monto)
        {
            Pagoyape pago = new Pagoyape();
            pago.UserID = _userManager.GetUserName(User);
            pago.MontoTotal = monto;
            return View(pago);
        }
        public IActionResult Pagar(Pagoyape pago)
        {
            pago.PaymentDate = DateTime.Now;
            _context.Add(pago);
            
            /****/
            var itemsProforma = from o in _context.DataProforma select o;
            itemsProforma = itemsProforma.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(pago.UserID) && s.Status.Equals("PENDIENTE"));
            /****/
                var itemsProformaservi = from o in _context.DataProformaServi select o;
            itemsProformaservi = itemsProformaservi.
                Include(p => p.Servicio).
                Where(s => s.UserID.Equals(pago.UserID) && s.Status.Equals("PENDIENTE"));
            /****/

              /**GUARDAR EN TABLA PEDIDO/ORDER**/          
              Pedidoyape pedido = new Pedidoyape();
              pedido.UserID = pago.UserID;
              pedido.Total = pago.MontoTotal;
              pedido.pago = pago;
               pedido.Status = "PENDIENTE";
               _context.Add(pedido);

            /**GUARDAR EN TABLA DETALLE PEDIDO/ORDER**/  
                List<DetallePedidoyape> itemsPedido = new List<DetallePedidoyape>();
                foreach(var item in itemsProforma.ToList()){
                    DetallePedidoyape detallePedido = new DetallePedidoyape();
                    detallePedido.pedido=pedido;
                    detallePedido.Precio = item.Precio;
                    detallePedido.Producto = item.Producto;
                    detallePedido.Quantity = item.Quantity;

                if(item.Producto.Id==0){      


                }else{     
                    itemsPedido.Add(detallePedido);
                }
            
                _context.AddRange(itemsPedido);
                }
                /****/
               
            /**CAMBIAR A PROCESADO EN CARRITO**/  
            foreach (Proforma p in itemsProforma.ToList())
            {
                p.Status="PROCESADO";
            }
            _context.UpdateRange(itemsProforma);
            /****/
            foreach (ProformaServi p in itemsProformaservi.ToList())
            {
                p.Status="PROCESADO";
            }            
            _context.UpdateRange(itemsProformaservi);
            /****/
            _context.SaveChanges();
            /*************************************/
            ViewData["Message"] = "El pago se ha registrado";
            return View("Confirmacion");
        }
        public async Task<IActionResult> Documento()
        {
            int a =10;
            var norma = _context.DataPagoyape.ToList();
            foreach(var item in norma.ToList()){
                a=Convert.ToInt32(item.Id);
            }
            var userID = _userManager.GetUserName(User);
            var Impresion = from o in _context.DataPedidoyape select o;
            Impresion = Impresion.
                Include(p => p.pago).
                Where(s => s.pago.Id.Equals(a));
           return new ViewAsPdf("Documento", await Impresion.ToListAsync());
            {

            }
        }
    }
    
}