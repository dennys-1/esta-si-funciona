using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace hostal.Models
{
    [Table("t_contact")]
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Display(Name = "Email")]
        [Column("email")]
        public string Email { get; set; }
        [Display(Name = "Celular")]
        [Column("phone")]
        public string Phone { get; set; }
        [Display(Name = "Nombre")]
        [Column("name")]
        public string Name {get; set;}
        [Display(Name = "Comentario")]
        [Column("comment")]
        public string Comment {get; set; }  
        [Display(Name = "Nacimiento")]  
        [Column("birthdate")]
        public DateTime BirthDate {get; set; }

    }
}