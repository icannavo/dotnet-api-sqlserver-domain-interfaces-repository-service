using APIWebExemplo.Data;
using APIWebExemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWebExemplo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel?> GetByIdAsync(string id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<ProdutoModel?> GetByNomeAsync(string nome)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Nome == nome);
        }
        public async Task<ProdutoModel?> GetByCodigoDeBarrasAsync(string codigoDeBarras)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.CodigoDeBarras == codigoDeBarras);
        }

        public async Task<ProdutoModel> CreateAsync(ProdutoModel produto)
        {
            produto.Id = await GenerateUniqueIdAsync();
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoModel?> UpdateAsync(string id, ProdutoModel produto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id);
            if (produtoExistente == null)
                return null;

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Marca = produto.Marca;
            produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoExistente.CodigoDeBarras = produto.CodigoDeBarras;

            await _context.SaveChangesAsync();
            return produtoExistente;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Produtos.AnyAsync(p => p.Id == id);
        }

        public async Task<string> GenerateUniqueIdAsync()
        {
            string id;
            do
            {
                // Gerar string aleatória de 8 caracteres (letras e números)
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                id = "";
                for (int i = 0; i < 8; i++)
                {
                    id += chars[random.Next(chars.Length)];
                }
            } while (await ExistsAsync(id));
            
            return id;
        }
    }
}
