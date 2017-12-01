using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaP2API.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
    }
}