using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace hostal.Models
{
    //CARRITO
    [Table("t_ProformaPaquetes")]
    public class ProformaPaquetes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public String UserID {get; set;}

        [Display(Name = "Paquetes: ")]
        public Paquetes Paquetes {get; set;}      

        [Display(Name = "Cantidad de Noches: ")]
        public int Quantity{get; set;}

        [Display(Name = "Precio por noche: ")]
        public Decimal Precio { get; set; }

        [Display(Name = "Estado: ")]
        public String Status { get; set; } = "PENDIENTE";
    }
}