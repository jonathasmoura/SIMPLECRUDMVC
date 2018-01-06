using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIMPLECRUD.MVC.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public virtual Curso Curso { get; set; }

    }
}