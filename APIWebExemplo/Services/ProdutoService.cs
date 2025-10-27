using APIWebExemplo.Interfaces;
using APIWebExemplo.Models;
using APIWebExemplo.Repositories;

namespace APIWebExemplo.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllProdutosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<ProdutoModel?> GetProdutoByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<ProdutoModel?> GetProdutoByNomeAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return null;

            return await _produtoRepository.GetByNomeAsync(nome);
        }
        public async Task<ProdutoModel?> GetByCodigoDeBarrasAsync(string codigoDeBarras)
        {
            if (string.IsNullOrWhiteSpace(codigoDeBarras))
                return null;

            return await _produtoRepository.GetByCodigoDeBarrasAsync(codigoDeBarras);
        }


        public async Task<ProdutoModel> CreateProdutoAsync(ProdutoModel produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new ArgumentException("Nome do produto é obrigatório", nameof(produto));

            if (string.IsNullOrWhiteSpace(produto.Marca))
                throw new ArgumentException("Marca do produto é obrigatória", nameof(produto));

            if (produto.QuantidadeEstoque < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa", nameof(produto));

            return await _produtoRepository.CreateAsync(produto);
        }

        public async Task<ProdutoModel?> UpdateProdutoAsync(string id, ProdutoModel produto)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID do produto é obrigatório", nameof(id));

            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new ArgumentException("Nome do produto é obrigatório", nameof(produto));

            if (string.IsNullOrWhiteSpace(produto.Marca))
                throw new ArgumentException("Marca do produto é obrigatória", nameof(produto));

            if (produto.QuantidadeEstoque < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa", nameof(produto));

            return await _produtoRepository.UpdateAsync(id, produto);
        }

        public async Task<bool> DeleteProdutoAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            return await _produtoRepository.DeleteAsync(id);
        }
    }
}
