using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostal.Models
{
    [Table("t_orderyape")]
    public class Pedidoyape
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}
        public String UserID{ get; set; }
        public Decimal Total { get; set; }
        public Pagoyape pago { get; set; }
        public String Status { get; set; }
    }
}