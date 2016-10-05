[assembly: WebActivator.PostApplicationStartMethod(typeof(Seguradora.Presentation.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Seguradora.Presentation.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Infra.CrossCutting.IoC;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //Chama o projeto de IoC que ira registrar as dependências, não precisando referenciar outros projetos na apresentação e 
            //aproveita o código de registro entre apresentações diferentes;
            BootStrapper.Register(container);
        }
    }
}