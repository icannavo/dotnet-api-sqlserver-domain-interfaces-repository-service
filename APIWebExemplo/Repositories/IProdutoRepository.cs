using APIWebExemplo.Models;

namespace APIWebExemplo.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoModel>> GetAllAsync();
        Task<ProdutoModel?> GetByIdAsync(string id);
        Task<ProdutoModel?> GetByNomeAsync(string nome);
        Task<ProdutoModel?> GetByCodigoDeBarrasAsync(string codigoDeBarras);
        Task<ProdutoModel> CreateAsync(ProdutoModel produto);
        Task<ProdutoModel?> UpdateAsync(string id, ProdutoModel produto);
        Task<bool> DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
        Task<string> GenerateUniqueIdAsync();
    }
}
