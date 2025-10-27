<<<<<<< HEAD
=======
# dotnet-api-sqlserver-domain-interfaces-repository-service
API em .NET com SQL Server e arquitetura limpa (camadas Service, Repository e Domain).
>>>>>>> 0c2074bf8b8d4db2f4f252d151bb2f888910b807
# API Web Exemplo - Sistema de Gerenciamento de Produtos

Uma API RESTful desenvolvida em ASP.NET Core (.NET 9) para gerenciamento de produtos, utilizando Entity Framework Core, AutoMapper e documentação interativa com Scalar.

## 📋 Características

- **.NET 9.0** - Framework mais recente do ASP.NET Core
- **Entity Framework Core** - ORM para acesso ao banco de dados
- **SQL Server** - Banco de dados
- **AutoMapper** - Mapeamento automático entre entidades e DTOs
- **Scalar** - Interface de documentação moderna e interativa da API
- **Arquitetura em Camadas** - Separação clara entre Controllers, Services, Repositories e Domain

## 🔧 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- **[.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)** - SDK do .NET 9 ou superior
- **[SQL Server 2019+](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)** ou **[SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)** - Banco de dados SQL Server
- **[SQL Server Management Studio (SSMS)](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms)** - Opcional, mas recomendado para gerenciar o banco de dados
- **Git** - Para clonar o repositório
- **Visual Studio 2022** ou **Visual Studio Code** - IDE para desenvolvimento

## 🚀 Como Configurar o Projeto

### 1. Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/APIWebExemplo.git
cd APIWebExemplo
```

### 2. Configurar a Connection String

Edite o arquivo `APIWebExemplo/appsettings.json` e atualize a connection string com as informações do seu SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=WebApiExemplo;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Exemplo de connection strings:**

**Para autenticação Windows (recomendado):**
```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=WebApiExemplo;Trusted_Connection=True;TrustServerCertificate=True;"
```

**Para autenticação SQL Server:**
```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=WebApiExemplo;User Id=sa;Password=SuaSenha123;TrustServerCertificate=True;"
```

**Variáveis importantes:**
- `Server` - Nome do servidor SQL Server (ex: `localhost` ou `localhost\\SQLEXPRESS`)
- `Database` - Nome do banco de dados (será criado automaticamente)
- `Trusted_Connection=True` - Usa autenticação Windows
- `TrustServerCertificate=True` - Necessário para conexões SSL

### 3. Restaurar as Dependências

Abra um terminal na pasta `APIWebExemplo` e execute:

```bash
dotnet restore
```

Este comando irá baixar todos os pacotes NuGet necessários definidos no arquivo `APIWebExemplo.csproj`:

- **AutoMapper** (15.0.1) - Mapeamento de objetos
- **Microsoft.AspNetCore.OpenApi** (9.0.10) - Suporte ao OpenAPI
- **Microsoft.EntityFrameworkCore** (9.0.10) - Entity Framework Core
- **Microsoft.EntityFrameworkCore.SqlServer** (9.0.10) - Provider SQL Server
- **Scalar.AspNetCore** (2.9.0) - Documentação interativa da API

### 4. Executar as Migrations

As migrations já existem no projeto. Execute o seguinte comando para criar/atualizar o banco de dados:

```bash
dotnet ef database update
```

Este comando irá:
- Criar o banco de dados `WebApiExemplo` (se não existir)
- Aplicar todas as migrations existentes
- Criar a tabela `Produtos` com a estrutura necessária

**Se precisar criar uma nova migration:**
```bash
dotnet ef migrations add NomeDaMigration --project APIWebExemplo.csproj
```

### 5. Executar o Projeto

Execute o projeto com o comando:

```bash
dotnet run --project APIWebExemplo.csproj
```

Ou, se estiver na pasta do projeto:
```bash
dotnet run
```

O servidor será iniciado e estará disponível em:
- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`

Os números de porta podem variar - verifique o terminal para a URL exata.

## 📚 Documentação da API com Scalar

Após iniciar o projeto, acesse a documentação interativa da API:

**URL da Documentação Scalar:**
```
https://localhost:5001/scalar/v1
```

> **Nota:** Esta URL só está disponível no ambiente de **Development**. 
> A configuração está em `Program.cs` linha 34.

### Características do Scalar:
- Interface moderna e intuitiva
- Teste diretamente os endpoints pela interface
- Documentação completa dos modelos e respostas
- Validação automática dos parâmetros
- Exportação de requisições para várias ferramentas

## 🔌 Endpoints da API

### Produtos

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/api/produto` | Lista todos os produtos |
| `GET` | `/api/produto/{id}` | Busca produto por ID |
| `GET` | `/api/produto/nome/{nome}` | Busca produto por nome |
| `GET` | `/api/produto/codigoDeBarras/{codigo}` | Busca produto por código de barras |
| `POST` | `/api/produto` | Cria um novo produto |
| `PUT` | `/api/produto/{id}` | Atualiza um produto existente |
| `DELETE` | `/api/produto/{id}` | Deleta um produto |

### Modelo de Produto

```json
{
  "id": "string (máx. 8 caracteres)",
  "nome": "string (obrigatório, máx. 100 caracteres)",
  "descricao": "string (máx. 500 caracteres)",
  "quantidadeEstoque": 0,
  "codigoDeBarras": "string (obrigatório, máx. 50 caracteres)",
  "marca": "string (obrigatório, máx. 50 caracteres)"
}
```

### Exemplo de Requisição POST

```json
{
  "nome": "Notebook Dell",
  "descricao": "Notebook Dell Inspiron 15",
  "quantidadeEstoque": 25,
  "codigoDeBarras": "7891234567890",
  "marca": "Dell"
}
```

## 🏗️ Estrutura do Projeto

```
APIWebExemplo/
├── Controllers/          # Controladores da API
│   └── ProdutoController.cs
├── Services/             # Lógica de negócio
│   └── ProdutoService.cs
├── Repositories/         # Acesso a dados
│   ├── IProdutoRepository.cs
│   └── ProdutoRepository.cs
├── Models/               # Modelos de dados (Entity Framework)
│   └── ProdutoModel.cs
├── Domain/               # Entidades de domínio
│   └── Produto.cs
├── Interfaces/           # Interfaces de serviços
│   └── IProdutoService.cs
├── Mappings/             # Configuração do AutoMapper
│   ├── AutoMapperConfiguration.cs
│   └── ProdutoProfile.cs
├── Data/                 # Contexto do banco de dados
│   └── AppDbContext.cs
├── Migrations/           # Migrations do Entity Framework
└── Program.cs            # Configuração da aplicação
```

## 🎯 Arquitetura

O projeto segue uma **Arquitetura em Camadas**:

- **Controllers** - Recebem requisições HTTP e retornam respostas
- **Services** - Contêm a lógica de negócio
- **Repositories** - Gerenciam acesso aos dados
- **Domain** - Entidades de domínio com regras de negócio
- **Models** - Modelos do Entity Framework para persistência

## 🧪 Testando a API

### Usando o Scalar (Recomendado)
1. Acesse `https://localhost:5001/scalar/v1`
2. Navegue pelos endpoints disponíveis
3. Teste as requisições diretamente na interface

### Usando curl

**Listar todos os produtos:**
```bash
curl -X GET https://localhost:5001/api/produto
```

**Criar um produto:**
```bash
curl -X POST https://localhost:5001/api/produto \
  -H "Content-Type: application/json" \
  -d '{"nome":"Mouse","descricao":"Mouse óptico sem fio","quantidadeEstoque":50,"codigoDeBarras":"123456789","marca":"Logitech"}'
```

## 🔍 Troubleshooting

### Erro de Conexão com o Banco

**Problema:** Não é possível conectar ao SQL Server

**Soluções:**
1. Verifique se o SQL Server está rodando
2. Confirme que a connection string está correta no `appsettings.json`
3. Tente usar `localhost\\SQLEXPRESS` para SQL Server Express
4. Verifique se o `TrustServerCertificate=True` está na connection string

### Erro ao Executar Migrations

**Problema:** Erro ao executar `dotnet ef database update`

**Solução:**
```bash
# Instale o Entity Framework Tools globalmente
dotnet tool install --global dotnet-ef

# Execute novamente
dotnet ef database update
```

### Porta Já em Uso

**Problema:** A porta 5000 ou 5001 já está em uso

**Solução:**
Altere as portas no arquivo `launchSettings.json` na pasta `Properties`.

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## 📄 Licença

Este projeto é um exemplo educacional e está livre para uso.

## 📞 Contato +351 938 120 961

Para dúvidas ou sugestões, abra uma issue no repositório.

---

**Desenvolvido com ❤️ usando ASP.NET Core, Entity Framework e Scalar**

