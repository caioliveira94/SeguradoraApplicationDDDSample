using AutoMapper;

namespace Seguradora.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>(); //Perfil de mapeamento de um objeto do dominio para viewmodel;
                x.AddProfile<ViewModelToDomainMappingProfile>(); //Perfil de mapeamento de viewmodel para um objeto do dominio;
            });
        }
    }
}
