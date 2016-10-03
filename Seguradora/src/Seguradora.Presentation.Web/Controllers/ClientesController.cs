using Seguradora.Application;
using Seguradora.Application.ViewModels;
using System;
using System.Net;
using System.Web.Mvc;

namespace Seguradora.Presentation.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteAppSerice _clienteAppService = new ClienteAppSerice();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Lembrar de utilizar o Bind em formulários com post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Lembrar do Bind também
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
