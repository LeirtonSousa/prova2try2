using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaP2API.Models
{
    public class Despesa
    {
        [Key]
        public int id { get; set; }
        public double valor { get; set; }
        public string descricao { get; set; }
    }
}