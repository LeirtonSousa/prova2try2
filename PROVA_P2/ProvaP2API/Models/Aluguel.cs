using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaP2API.Models
{
    public class Aluguel
    {
        [Key]
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idMaterial { get; set; }
        public int idFuncionario { get; set; }
        public double valor { get; set; }
        public string dataEntrega { get; set; }
        public string dataDevolucao { get; set; }
        public string formaPgmt { get; set; }

    }
}