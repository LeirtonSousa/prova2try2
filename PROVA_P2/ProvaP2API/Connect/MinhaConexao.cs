using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ProvaP2API.Connect
{
    public class MinhaConexao : DbContext
    {
        public MinhaConexao() : base("name=MinhaConexao")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
            modelBuider.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuider.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ProvaP2API.Models.Funcionario> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<ProvaP2API.Models.Aluguel> Aluguels { get; set; }

        public System.Data.Entity.DbSet<ProvaP2API.Models.Material> Materials { get; set; }

        public System.Data.Entity.DbSet<ProvaP2API.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<ProvaP2API.Models.Despesa> Despesas { get; set; }
    }
}