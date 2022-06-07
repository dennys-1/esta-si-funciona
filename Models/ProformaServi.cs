using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace hostal.Models
{
    //CARRITO
    [Table("t_proformaserv")]
    public class ProformaServi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public String UserID {get; set;}

        [Display(Name = "Servicios: ")]
        public Servicios Servicio {get; set;}

        [Display(Name = "Cantidad de personas: ")]
        public int Quantity{get; set;}

        [Display(Name = "Precio por persona: ")]
        public Decimal Precio { get; set; }

        [Display(Name = "Estado: ")]
        public String Status { get; set; } = "PENDIENTE";
    }
}