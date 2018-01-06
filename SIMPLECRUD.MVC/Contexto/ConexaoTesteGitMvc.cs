using SIMPLECRUD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SIMPLECRUD.MVC.Contexto
{
    public class ConexaoTesteGitMvc : DbContext
    {
        public ConexaoTesteGitMvc()
        : base("PrjSimpleConex")
        {

        }

        public DbSet<Universidade> Universidades { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    }
}