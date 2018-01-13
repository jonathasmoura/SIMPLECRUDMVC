using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIMPLECRUD.MVC.Contexto;
using SIMPLECRUD.MVC.Models;

namespace SIMPLECRUD.MVC.Controllers
{
    public class UniversidadeController : Controller
    {
        private ConexaoTesteGitMvc db = new ConexaoTesteGitMvc();

        // GET: Universidade
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListarUniversidade(Universidade universidade, int pagina = 1, int registros = 5)
        {
            var univers = db.Universidades.Include(u => u.Cursos);

            if (!String.IsNullOrWhiteSpace(universidade.Nome))
            {
                univers = univers.Where(u => u.Nome.Contains(universidade.Nome));
            }

            if (!string.IsNullOrWhiteSpace(universidade.Cidade))
            {
                univers = univers.Where(u => u.Cidade.Contains(universidade.Cidade));
            }

            if (!String.IsNullOrWhiteSpace(universidade.UF))
            {
                univers = univers.Where(u => u.UF.Contains(universidade.UF));
            }

            var universPaginados = univers.OrderBy(u => u.Nome).Skip((pagina - 1) * registros).Take(registros);

            return PartialView("_ListarUniversidade", universPaginados.ToList());
        }

        // GET: Universidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidade universidade = db.Universidades.Find(id);
            if (universidade == null)
            {
                return HttpNotFound();
            }
            return View(universidade);
        }

        // GET: Universidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniversidadeId,Nome,Cidade,UF")] Universidade universidade)
        {
            if (ModelState.IsValid)
            {
                db.Universidades.Add(universidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universidade);
        }

        // GET: Universidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidade universidade = db.Universidades.Find(id);
            if (universidade == null)
            {
                return HttpNotFound();
            }
            return View(universidade);
        }

        // POST: Universidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniversidadeId,Nome,Cidade,UF")] Universidade universidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universidade);
        }

        // GET: Universidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidade universidade = db.Universidades.Find(id);
            if (universidade == null)
            {
                return HttpNotFound();
            }
            return View(universidade);
        }

        // POST: Universidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Universidade universidade = db.Universidades.Find(id);
            db.Universidades.Remove(universidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
