using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace hostal.Models
{
    [Table("t_paquetes")]
    public class Paquetes
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        
        [Display(Name = "Nombre")]
        [Column("Nombre")]
        public string Nombre {get; set;}       

        [Display(Name = "Fecha")]
        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Habitación: ")]
        public Product Producto {get; set;}

        [Display(Name = "Actividad: ")]
        public Servicios Servicio {get; set;}

        [Display(Name = "Descripción")]
        [Column("Descripción")]
        public string Descripción {get; set;}

        [Display(Name = "Descuento")]
        [Column("Precio")]
        public Decimal Precio {get; set;}

        [Display(Name = "Imagen")]
        [Column("Imagen")]
        public String Imagen { get; set; }

        [Display(Name = "Estado")]
        [Column("Estado")]
        public String Estado{ get; set; }
        
    }
}