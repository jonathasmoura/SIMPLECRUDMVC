using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIMPLECRUD.MVC.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public int UniversidadeId { get; set; }

        [ForeignKey("UniversidadeId")]
        public virtual Universidade Universidade { get; set; }
    }
}