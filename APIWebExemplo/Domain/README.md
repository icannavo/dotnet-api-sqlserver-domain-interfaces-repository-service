# Domain Layer

Esta pasta contém as entidades de domínio da aplicação seguindo os princípios de Domain-Driven Design (DDD).

## Estrutura

### Produto.cs
- Entidade de domínio principal representando um produto
- Contém lógica de negócio específica do domínio
- Inclui validações e métodos de domínio
- Não contém anotações de persistência (Data Annotations)

### Características implementadas:
- Construtores para facilitar a criação de instâncias
- Métodos de domínio para operações de negócio:
  - `AtualizarEstoque()`: Atualiza o estoque com validação
  - `AtualizarInformacoes()`: Atualiza informações do produto
  - `TemEstoqueSuficiente()`: Verifica se há estoque suficiente

### Validações de Domínio:
- Estoque não pode ser negativo
- Nome é obrigatório
- Lógica de negócio encapsulada na entidade

## Padrões Utilizados:
- **Domain-Driven Design (DDD)**: Separação clara entre domínio e infraestrutura
- **Rich Domain Model**: Entidades com comportamento e lógica de negócio
- **Encapsulamento**: Validações e regras de negócio dentro da entidade
