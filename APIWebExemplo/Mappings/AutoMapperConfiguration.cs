using AutoMapper;

namespace APIWebExemplo.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(IMapperConfigurationExpression config)
        {
            // Configurações globais do AutoMapper
            config.AllowNullCollections = true;
            config.AllowNullDestinationValues = true;
            
            // Adiciona todos os profiles do assembly
            config.AddMaps(typeof(ProdutoProfile));
        }
    }
}
