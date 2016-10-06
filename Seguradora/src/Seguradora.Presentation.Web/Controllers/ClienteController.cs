using Seguradora.Application.Interfaces;
using Seguradora.Application.ViewModels;
using Seguradora.Infra.CrossCutting.MvcFilters;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Mvc;

namespace Seguradora.Presentation.Web.Controllers
{
    [RoutePrefix("Administracao")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        //Modulo Cliente: Incluir, Editar, Listar, Consultar e Excluir
        
        [Route("ListaDeClientes")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        [Route("{id:guid}/InformacoesCliente")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Route("NovoCliente")]
        public ActionResult Create()
        {
            return View();
        }

        // Lembrar de colocar o Bind para actions com post de formulários. Ex: [Bind(Include = "ClienteId,Nome,DataNascimento,DataCadastro,Email")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("NovoCliente")]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);

                if (!clienteEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(clienteEnderecoViewModel);
                }
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [Route("{id:guid}/EditarCliente")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // Lembrar de colocar o Bind para actions com post de formulários. Ex: [Bind(Include = "ClienteId,Nome,DataNascimento,DataCadastro,Email")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:guid}/EditarCliente")]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("ModuloCliente", "Excluir")]
        [Route("{id:guid}/ExcluirCliente")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            //Exemplo de como passar as permissões do usuário para View, e montar a view de acordo com as permissões
            ViewBag.Permissoes = ((ClaimsIdentity)ControllerContext.HttpContext.User.Identity).Claims.FirstOrDefault(c => c.Type == "ModuloCliente");
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{id:guid}/ExcluirCliente")]
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
