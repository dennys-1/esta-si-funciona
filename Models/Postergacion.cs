using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace hostal.Models
{
    [Table("t_postergacion")]
    public class Postergacion
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

         [Display(Name = "Motivo")]
        [Column("Motivo")]
        public string Motivo {get; set;}

        [Display(Name = "Estado")]
        [Column("Estado")]
        public String Estado{ get; set; } = "En revisión";
        
    }
}