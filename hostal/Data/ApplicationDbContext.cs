using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using hostal.Models;


namespace hostal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            public DbSet<hostal.Models.Product> DataProducts { get; set; }
            public DbSet<hostal.Models.Servicios> DataServicios { get; set; }
            public DbSet<hostal.Models.Contact> DataContactos { get; set; }
            public DbSet<hostal.Models.Proforma> DataProforma { get; set; }
            public DbSet<hostal.Models.ProformaServi> DataProformaServi { get; set; }
            public DbSet<hostal.Models.Proformass> DataProformass { get; set; }
            public DbSet<hostal.Models.Pago> DataPago { get; set; }
            public DbSet<hostal.Models.Pedido> DataPedido { get; set; }
            public DbSet<hostal.Models.DetallePedido> DataDetallePedido { get; set; }

        }



    }

