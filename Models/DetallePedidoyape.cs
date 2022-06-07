using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostal.Models
{
    [Table("t_order_detailyape")]
    public class DetallePedidoyape
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}
        public Product Producto {get; set;}
        public int Quantity{get; set;}
        public Decimal Precio { get; set; }
        public Pedidoyape pedido {get; set;}
    }
}