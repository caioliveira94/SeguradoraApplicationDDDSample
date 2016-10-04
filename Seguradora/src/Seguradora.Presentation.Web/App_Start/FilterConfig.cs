using Seguradora.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace Seguradora.Presentation.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
            //Filtro que será chamado a cada execução de action. Uma boa forma de criar log.
            filters.Add(new GlobalErrorHandler());
        }
    }
}
