using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaP2API.Models
{
    public class Material
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string valor { get; set; }
        public int status { get; set; }
    }
}