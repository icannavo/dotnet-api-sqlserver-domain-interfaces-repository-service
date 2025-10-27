using APIWebExemplo.Models;

namespace APIWebExemplo.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> GetAllProdutosAsync();
        Task<ProdutoModel?> GetProdutoByIdAsync(string id);
        Task<ProdutoModel?> GetProdutoByNomeAsync(string nome);
        Task<ProdutoModel?> GetByCodigoDeBarrasAsync(string codigoDeBarras);
        Task<ProdutoModel> CreateProdutoAsync(ProdutoModel produto);
        Task<ProdutoModel?> UpdateProdutoAsync(string id, ProdutoModel produto);
        Task<bool> DeleteProdutoAsync(string id);
    }
}
