using AutoMapper;
using Seguradora.Application.ViewModels;
using Seguradora.Domain.Entities;

namespace Seguradora.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteEnderecoViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}