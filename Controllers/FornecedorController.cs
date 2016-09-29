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
    public class FornecedorController : Controller
    {
        private Arianna_Lima_av1DbContext _dbContext = new Arianna_Lima_av1DbContext();

        // GET: Fornecedor
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListaFornecedor(int? max)
        {
            var model = max.HasValue ? _dbContext.Fornecedores.Take(max.Value).ToList() : _dbContext.Fornecedores.ToList();
            return PartialView("_ListaFornecedores", model);
        }

        // GET: Fornecedor/Detalhes/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = _dbContext.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Fornecedor/Cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "Id,Cnpj,RazaoSocial,Endereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Fornecedores.Add(fornecedor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = _dbContext.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Cnpj,RazaoSocial,Endereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(fornecedor).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Apagar/5
        public ActionResult Apagar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = _dbContext.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public ActionResult ApagarConfirmado(int id)
        {
            Fornecedor fornecedor = _dbContext.Fornecedores.Find(id);
            _dbContext.Fornecedores.Remove(fornecedor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
