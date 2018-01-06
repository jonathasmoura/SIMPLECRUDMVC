using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLECRUD.MVC.Models
{
    public class Universidade
    {
        public int UniversidadeId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }


        public virtual ICollection<Curso> Cursos { get; set; }

    }
}