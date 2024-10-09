using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TarefaTeste.Models;

namespace TarefaTeste.Controllers
{
    public class TarefasController : Controller
    {
        private DBTarefaTesteEntities1 db = new DBTarefaTesteEntities1();

        // GET: Tarefas
        public ActionResult Index()
        {
            var tarefas = db.Tarefas.Include(t => t.StatusTarefa).Include(t => t.Usuário);
            return View(tarefas.ToList());
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            ViewBag.IDStatusTarefas = new SelectList(db.StatusTarefa, "ID", "Descricao");
            ViewBag.IDUsuario = new SelectList(db.Usuário, "ID", "Nome");
            return View();
        }

        // POST: Tarefas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descricao,Data,IDUsuario,IDStatusTarefas")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDStatusTarefas = new SelectList(db.StatusTarefa, "ID", "Descricao", tarefas.IDStatusTarefas);
            ViewBag.IDUsuario = new SelectList(db.Usuário, "ID", "Nome", tarefas.IDUsuario);
            return View(tarefas);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDStatusTarefas = new SelectList(db.StatusTarefa, "ID", "Descricao", tarefas.IDStatusTarefas);
            ViewBag.IDUsuario = new SelectList(db.Usuário, "ID", "Nome", tarefas.IDUsuario);
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descricao,Data,IDUsuario,IDStatusTarefas")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDStatusTarefas = new SelectList(db.StatusTarefa, "ID", "Descricao", tarefas.IDStatusTarefas);
            ViewBag.IDUsuario = new SelectList(db.Usuário, "ID", "Nome", tarefas.IDUsuario);
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefas tarefas = db.Tarefas.Find(id);
            db.Tarefas.Remove(tarefas);
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
