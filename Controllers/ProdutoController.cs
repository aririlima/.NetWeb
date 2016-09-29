using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Arianna_Lima_av1.Models;

namespace Arianna_Lima_av1.Controllers
{
    public class ProdutoController : Controller
    {
        private Arianna_Lima_av1DbContext db = new Arianna_Lima_av1DbContext();

        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListaProdutos(int? max)
        {
            var model = max.HasValue ? db.Produtos.Take(max.Value).ToList() : db.Produtos.ToList();
            return PartialView("_ListaProdutos", model);
        }

        // GET: Produto/Detalhes/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Produto/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "ProdutoId,nome,marca,estoque")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ProdutoId,nome,marca,estoque")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produto/Apagar/5
        public ActionResult Apagar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Apagar/5
        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public ActionResult ApagarConfirmado(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
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
