using SIMPLECRUD.MVC.Contexto;
using SIMPLECRUD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMPLECRUD.MVC.Controllers
{
    public class AlunosController : Controller
    {

        public ActionResult Index()
        {


            return View();
        }

        #region Método que lista todos Alunos
        public JsonResult ListarAlunos()
        {
            using (var db = new ConexaoTesteGitMvc())
            {
                List<Aluno> listarAlunos = db.Alunos.ToList();

                return Json(listarAlunos, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Método para criar um novo Aluno - Create

        public JsonResult InserirAlunoNovo(Aluno aluno)
        {
            if (aluno != null)
            {
                using (var db = new ConexaoTesteGitMvc())
                {
                    db.Alunos.Add(aluno);
                    db.SaveChanges();

                    return Json(new { success = true })
;
                }
            }
            return Json(new { success = false });
        }
        #endregion
    }
}