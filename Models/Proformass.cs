using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostal.Models
{
    [Table("t_proformass")]
    public class Proformass
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         [Column("id")]
        public int Id { get; set; }

        public Proforma Proforma { get; set; }

        public ProformaServi ProformaServi { get; set; }

        public ProformaPaquetes ProformaPaquetes { get; set; }
        
    }
}