using AutoMapper;
using APIWebExemplo.Models;
using APIWebExemplo.Domain;

namespace APIWebExemplo.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            // Mapeamento de Model para Domain
            CreateMap<ProdutoModel, Produto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.QuantidadeEstoque, opt => opt.MapFrom(src => src.QuantidadeEstoque))
                .ForMember(dest => dest.CodigoDeBarras, opt => opt.MapFrom(src => src.CodigoDeBarras))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca));

            // Mapeamento de Domain para Model
            CreateMap<Produto, ProdutoModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.QuantidadeEstoque, opt => opt.MapFrom(src => src.QuantidadeEstoque))
                .ForMember(dest => dest.CodigoDeBarras, opt => opt.MapFrom(src => src.CodigoDeBarras))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca));
        }
    }
}
