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
    public class ClientesController : Controller
    {
        private ClienteRepositorio repositorio = new ClienteRepositorio();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(repositorio.BuscarTudo());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repositorio.BuscarPor((int)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrimeiroNome,Sobrenome,Telefone,DataNascimento,Endereco")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                repositorio.Adicionar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repositorio.BuscarPor((int) id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrimeiroNome,Sobrenome,Telefone,DataNascimento,Endereco")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                repositorio.Editar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repositorio.BuscarPor((int) id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = repositorio.BuscarPor((int) id);
            repositorio.Deletar(cliente);
            return RedirectToAction("Index");
        }

    }
}
