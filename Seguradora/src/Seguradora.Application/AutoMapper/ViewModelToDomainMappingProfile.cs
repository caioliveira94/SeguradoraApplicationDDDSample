using AutoMapper;
using Seguradora.Application.ViewModels;
using Seguradora.Domain.Entities;

namespace Seguradora.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}
