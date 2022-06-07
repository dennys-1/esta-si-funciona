using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace hostal.Models
{
    [Table("t_pagoyape")]
    public class Pagoyape
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set;}
        public DateTime PaymentDate {get;set;}
        public String Capturayape {get; set;}
        public Decimal MontoTotal {get;set;}
        public String UserID {get; set;}
    }
}