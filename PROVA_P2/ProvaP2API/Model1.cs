namespace ProvaP2API
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ProvaP2API.Models;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ConnectionBD")
        {
        }

        public virtual DbSet<Aluguel> Aluguels { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Despesa> Despesas { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluguel>()
                .Property(e => e.dataEntrega)
                .IsUnicode(false);

            modelBuilder.Entity<Aluguel>()
                .Property(e => e.dataDevolucao)
                .IsUnicode(false);

            modelBuilder.Entity<Aluguel>()
                .Property(e => e.formaPgmt)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Despesa>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.valor)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
