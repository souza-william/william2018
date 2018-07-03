using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Infra.Dados.Contexto;
using TrabalhoFinal.Infra.Dados.Repositorios;

namespace TrabalhoFinal.Web.Controllers
{
    public class QuartosController : Controller
    {
        private QuartoRepositorio repositorio = new QuartoRepositorio();

        // GET: Quartos
        public ActionResult Index()
        {
            return View(repositorio.BuscarTudo());
        }

        // GET: Quartos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = repositorio.BuscarPor((int) id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // GET: Quartos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quartos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Preco,TipoQuarto")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                repositorio.Adicionar(quarto);
                return RedirectToAction("Index");
            }

            return View(quarto);
        }

        // GET: Quartos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = repositorio.BuscarPor((int) id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // POST: Quartos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,TipoQuarto")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                repositorio.Editar(quarto);
                return RedirectToAction("Index");
            }
            return View(quarto);
        }

        // GET: Quartos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = repositorio.BuscarPor((int) id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // POST: Quartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quarto quarto = repositorio.BuscarPor((int) id);
            repositorio.Deletar(quarto);
            return RedirectToAction("Index");
        }

    }
}
