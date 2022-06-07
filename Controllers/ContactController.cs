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
    public class ContactController:Controller
    {
        private readonly ApplicationDbContext _context;
        private const string URL_API_SPOTIFY = "https://api.sendgrid.com/v3/mail/send";
        private string ACCESS_TOKEN ="";



        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.DataContactos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "El contacto ya esta registrado";
            //return RedirectToAction(nameof(Index));
            ACCESS_TOKEN = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            Console.WriteLine( " token :" + ACCESS_TOKEN);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(URL_API_SPOTIFY);
             httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
  
            var jsonObject = new StringBuilder();
            jsonObject.Append("{");
            jsonObject.Append("\"categories\": [");
            jsonObject.Append("\"demo\" ");
            jsonObject.Append("],");
            jsonObject.Append("\"from\": {");
            jsonObject.Append("\"email\": \"yaraliz_gomez@usmp.pe\","); 
            jsonObject.Append("\"name\": \"Grupo BLanco \"");
            jsonObject.Append("},");
            jsonObject.Append("\"personalizations\": [");
            jsonObject.Append("{");
            jsonObject.Append("      \"to\": [");
            jsonObject.Append("        {");
            jsonObject.Append("\"email\": \""+objContacto+"\",");
            jsonObject.Append("\"name\": \"Grupo Blanco\" ");
            jsonObject.Append("}");
            jsonObject.Append("],");
            jsonObject.Append("\"subject\": \"Bienvenido\" ");
            jsonObject.Append("}");
            jsonObject.Append("],");
            jsonObject.Append("\"content\": [");
            jsonObject.Append("{");
            jsonObject.Append("\"type\": \"text/plain\",");
            jsonObject.Append("\"value\": \"Bienvenido al equipo de trabajo\" ");
            jsonObject.Append("}");
            jsonObject.Append("],  ");
            jsonObject.Append("}");

            Console.WriteLine( " trama :" + jsonObject.ToString());
            
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(URL_API_SPOTIFY, content);
            Console.WriteLine( " result :" + result);





            return View();
        }

        
        public IActionResult Edit(int id)
        {
            Contact objContacto = _context.DataContactos.Find(id);
            if(objContacto == null){
                return NotFound();
            }
            return View(objContacto);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,Name,Email,Comment,Phone")] Contact objContacto)
        {
             _context.Update(objContacto);
             _context.SaveChanges();
              ViewData["Message"] = "El contacto ya esta actualizado";
             return View(objContacto);
        }

        public IActionResult Delete(int id)
        {
            Contact objContacto = _context.DataContactos.Find(id);
            _context.DataContactos.Remove(objContacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        /*************************EXPORTAR EXCEL******************************/
        public IActionResult ExportarExcel()
        {
            string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var contacto = _context.DataContactos.AsNoTracking().ToList();
            using (var libro = new ExcelPackage())
            {
                var worksheet = libro.Workbook.Worksheets.Add("contacto");
                worksheet.Cells["A1"].LoadFromCollection(contacto, PrintHeaders: true);
                for (var col = 1; col < contacto.Count + 1; col++)
                {
                    worksheet.Column(col).AutoFit();
                }
                // Agregar formato de tabla
                var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: contacto.Count + 1, toColumn: 2), "contacto");
                tabla.ShowHeader = true;
                tabla.TableStyle = TableStyles.Light6;
                tabla.ShowTotal = true;

                return File(libro.GetAsByteArray(), excelContentType, "contacto.xlsx");
            }
        }
    }
}