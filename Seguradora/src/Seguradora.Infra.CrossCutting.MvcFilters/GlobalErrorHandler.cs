using System.Web.Mvc;

namespace Seguradora.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {
                /* Criação do log de erro (gravar no banco, enviar e-mail, gravar arquivo, EventViewer), verificar detalhadamente os metodos abaixo
                filterContext.Controller.ControllerContext.HttpContext
                filterContext.Exception
                */
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
