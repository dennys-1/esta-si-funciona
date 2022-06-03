using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace hostal.Models
{
    [Table("t_product")]
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Column("Nombre")]
        public string Nombre {get; set;}
        [Display(Name = "Descripción")]
        [Column("Descripcion")]
        public string Descripcion {get; set;}
        [Display(Name = "Precio por noche")]
        [Column("Precio")]
        public Decimal Precio {get; set;}
        [Display(Name = "Imagen")]
        [Column("Imagen")]
        public String Imagen { get; set; }
        [Display(Name = "Fecha Ingreso")]
        [Column("Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Estado")]
        [Column("Estado")]
        public String Estado{ get; set; }
        
    }
}