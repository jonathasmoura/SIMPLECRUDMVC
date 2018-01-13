using SIMPLECRUD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SIMPLECRUD.MVC.Contexto
{
    public class ConexaoTesteGitMvc : DbContext
    {
        public ConexaoTesteGitMvc()
        : base("PrjSimpleConex")
        {
            #region

            #endregion

        }

        public DbSet<Universidade> Universidades { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Configurações de pluralização de tabelas e exclusão em cascata

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
.Where(p => p.Name == p.ReflectedType.Name + "Id")
.Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
        .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
        .Configure(p => p.HasMaxLength(100));
            #endregion
        }

    }
}