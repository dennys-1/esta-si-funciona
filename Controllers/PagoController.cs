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
    public class PagoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PagoController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
       
         public IActionResult Index()
        {
            
            return View(_context.DataPago.ToList());
        }
        public IActionResult Confirmacion()
        {
            return View();
        }

        public IActionResult Create(Decimal monto)
        {
            Pago pago = new Pago();
            pago.UserID = _userManager.GetUserName(User);
            pago.MontoTotal = monto;
            return View(pago);
        }
        

        [HttpPost]
        public IActionResult Pagar(Pago pago)
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
              Pedido pedido = new Pedido();
              pedido.UserID = pago.UserID;
              pedido.Total = pago.MontoTotal;
              pedido.pago = pago;
               pedido.Status = "PENDIENTE";
               _context.Add(pedido);

            /**GUARDAR EN TABLA DETALLE PEDIDO/ORDER**/  
                List<DetallePedido> itemsPedido = new List<DetallePedido>();
                foreach(var item in itemsProforma.ToList()){
                    DetallePedido detallePedido = new DetallePedido();
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

         public IActionResult Delete(int id)
        {
            Pago objPago = _context.DataPago.Find(id);
            _context.DataPago.Remove(objPago);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        /*************************EXPORTAR EXCEL******************************/
        public IActionResult ExportarExcel()
        {
            string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var pagos = _context.DataPago.AsNoTracking().ToList();
            using (var libro = new ExcelPackage())
            {
                var worksheet = libro.Workbook.Worksheets.Add("Pagos");
                worksheet.Cells["A1"].LoadFromCollection(pagos, PrintHeaders: true);
                for (var col = 1; col < pagos.Count + 1; col++)
                {
                    worksheet.Column(col).AutoFit();
                }
                // Agregar formato de tabla
                var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: pagos.Count + 1, toColumn: 2), "Pagos");
                tabla.ShowHeader = true;
                tabla.TableStyle = TableStyles.Light6;
                tabla.ShowTotal = true;

                return File(libro.GetAsByteArray(), excelContentType, "Pagos.xlsx");
            }
        }
        /*************************GENERAR PDF******************************/
        public async Task<IActionResult> Documento()
        {
            int a =10;
            var norma = _context.DataPago.ToList();
            foreach(var item in norma.ToList()){
                a=Convert.ToInt32(item.Id);
            }
            var userID = _userManager.GetUserName(User);
            var Impresion = from o in _context.DataPedido select o;
            Impresion = Impresion.
                Include(p => p.pago).
                Where(s => s.pago.Id.Equals(a));
           return new ViewAsPdf("Documento", await Impresion.ToListAsync());
            {

            }
        }


    }

    }
