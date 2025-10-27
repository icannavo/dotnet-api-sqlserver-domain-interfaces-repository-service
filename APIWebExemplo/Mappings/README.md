# Mappings Layer

Esta pasta contém as configurações do AutoMapper para mapeamento entre diferentes camadas da aplicação.

## Estrutura

### ProdutoProfile.cs
- Profile do AutoMapper para mapeamento entre `ProdutoModel` e `Produto`
- Mapeamentos bidirecionais (Model ↔ Domain)
- Configurações explícitas para cada propriedade

### AutoMapperConfiguration.cs
- Configuração centralizada do AutoMapper
- Configurações globais aplicadas a todos os mapeamentos
- Registro de todos os profiles do assembly

## Configurações Implementadas:

### Configurações Globais:
- `AllowNullCollections = true`: Permite coleções nulas
- `AllowNullDestinationValues = true`: Permite valores nulos no destino

### Mapeamentos Específicos:
- **ProdutoModel → Produto**: Mapeamento do modelo para a entidade de domínio
- **Produto → ProdutoModel**: Mapeamento da entidade de domínio para o modelo

## Padrões Utilizados:
- **Profile Pattern**: Organização dos mapeamentos em profiles específicos
- **Configuration Pattern**: Configuração centralizada e reutilizável
- **Explicit Mapping**: Mapeamentos explícitos para melhor controle e manutenibilidade
