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
    public class UsuárioController : Controller
    {
        private DBTarefaTesteEntities1 db = new DBTarefaTesteEntities1();

        // GET: Usuário
        public ActionResult Index()
        {
            return View(db.Usuário.ToList());
        }

        // GET: Usuário/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuário usuário = db.Usuário.Find(id);
            if (usuário == null)
            {
                return HttpNotFound();
            }
            return View(usuário);
        }

        // GET: Usuário/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuário/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Senha")] Usuário usuário)
        {
            if (ModelState.IsValid)
            {
                db.Usuário.Add(usuário);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuário);
        }


        // GET: Usuário/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Usuário/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "ID,Nome,Senha")] Usuário usuário)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(usuário);
        }

        // GET: Usuário/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuário usuário = db.Usuário.Find(id);
            if (usuário == null)
            {
                return HttpNotFound();
            }
            return View(usuário);
        }

        // POST: Usuário/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Senha")] Usuário usuário)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuário).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuário);
        }

        // GET: Usuário/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuário usuário = db.Usuário.Find(id);
            if (usuário == null)
            {
                return HttpNotFound();
            }
            return View(usuário);
        }

        // POST: Usuário/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuário usuário = db.Usuário.Find(id);
            db.Usuário.Remove(usuário);
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
