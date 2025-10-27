namespace APIWebExemplo.Domain
{
    public class Produto
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string CodigoDeBarras { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;

        // Construtor padrão
        public Produto()
        {
        }

        // Construtor com parâmetros
        public Produto(string nome, string? descricao, int quantidadeEstoque, string codigoDeBarras, string marca)
        {
            Nome = nome;
            Descricao = descricao;
            QuantidadeEstoque = quantidadeEstoque;
            CodigoDeBarras = codigoDeBarras;
            Marca = marca;
        }

        // Métodos de domínio
        public void AtualizarEstoque(int quantidade)
        {
            if (QuantidadeEstoque + quantidade < 0)
                throw new InvalidOperationException("Estoque não pode ser negativo");
            
            QuantidadeEstoque += quantidade;
        }

        public void AtualizarInformacoes(string nome, string? descricao, string marca)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório");

            Nome = nome;
            Descricao = descricao;
            Marca = marca;
        }

        public bool TemEstoqueSuficiente(int quantidadeSolicitada)
        {
            return QuantidadeEstoque >= quantidadeSolicitada;
        }
    }
}
