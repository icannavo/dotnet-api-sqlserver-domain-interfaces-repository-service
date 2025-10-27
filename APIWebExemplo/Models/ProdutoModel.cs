using System.ComponentModel.DataAnnotations;

namespace APIWebExemplo.Models
{
    public class ProdutoModel
    {
        [Key]
        [MaxLength(8)]
        public string Id { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
        public string? Descricao { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade de estoque deve ser maior ou igual a 0")]
        public int QuantidadeEstoque { get; set; }
        
        [Required(ErrorMessage = "Código de barras é obrigatório")]
        [StringLength(50, ErrorMessage = "Código de barras deve ter no máximo 50 caracteres")]
        public string CodigoDeBarras { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Marca é obrigatória")]
        [StringLength(50, ErrorMessage = "Marca deve ter no máximo 50 caracteres")]
        public string Marca { get; set; } = string.Empty;
    }
}
