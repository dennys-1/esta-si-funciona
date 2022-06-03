using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostal.Models
{
    //CARRITO
    [Table("t_pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Nombre de tarjeta")]
        public String NombreTarjeta { get; set; }
        
        [Display(Name = "Numero de tarjeta")]
        public String NumeroTarjeta { get; set; }
        
        [NotMapped]
        public String DueDateYYMM { get; set; }
        [NotMapped]
        public String Cvv { get; set; }

        [Display(Name = "Monto Total")]
        public Decimal MontoTotal{ get; set; }

        [Display(Name = "Usuario")]
        public String UserID{ get; set; }
  
    }
}