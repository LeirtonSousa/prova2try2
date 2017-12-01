using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaP2API.Models
{
    public class Funcionario
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public double salario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

    }
}