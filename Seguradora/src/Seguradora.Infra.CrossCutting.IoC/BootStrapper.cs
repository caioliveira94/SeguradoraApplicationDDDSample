using Seguradora.Application;
using Seguradora.Application.Interfaces;
using Seguradora.Domain.Interfaces.Repository;
using Seguradora.Domain.Interfaces.Services;
using Seguradora.Domain.Services;
using Seguradora.Infra.Data.Context;
using Seguradora.Infra.Data.Interfaces;
using Seguradora.Infra.Data.Repository;
using Seguradora.Infra.Data.UnitOfWork;
using SimpleInjector;

namespace Seguradora.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        //Quando a aplicação chama um controller que recebe a instância de uma interface, faz o mapeamento de acordo com uma classe que implementa a interface
        public static void Register(Container container)
        {
            //Lifestyle.Transient (Uma instância para cada solicitação, inclusive no mesmo request);
            //Lifestyle.Singleton (Uma instância unica para classe, independente do request);
            //Lifestyle.Scoped (Uma instância única para cada request);

            //Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            //Infra data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ApplicationDBContext>(Lifestyle.Scoped);
            //container.Register(typeof(IRepository<>), typeof(Repository<>)); Não precisa registrar pois vai usar os repositórios específicos

            //Application
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
        }
    }
}
