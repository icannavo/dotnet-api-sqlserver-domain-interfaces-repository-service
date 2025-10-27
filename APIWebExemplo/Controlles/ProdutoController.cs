using APIWebExemplo.Interfaces;
using APIWebExemplo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIWebExemplo.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> BuscarProduto()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorId(string id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não localizado");
            }
            return Ok(produto);
        }

        [HttpGet]
        [Route("nome/{nome}")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorNome(string nome)
        {
            var produto = await _produtoService.GetProdutoByNomeAsync(nome);
            if (produto == null)
            {
                return NotFound("Produto não localizado");
            }
            return Ok(produto);
        }

        [HttpGet]
        [Route("codigoDeBarras/{codigoDeBarras}")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorCodigoDeBarras(string codigoDeBarras)
        {
            var produto = await _produtoService.GetByCodigoDeBarrasAsync(codigoDeBarras);
            if (produto == null)
            {
                return NotFound("Produto não localizado");
            }
            return Ok(produto);
        }


        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> CriarProduto(ProdutoModel produtoModel)
        {
            try
            {
                if(produtoModel == null)
                {
                    return BadRequest("Ocorreu um erro na solicitação");
                }
                
                var produto = await _produtoService.CreateProdutoAsync(produtoModel);
                return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = produto.Id }, produto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ProdutoModel>> EditarProduto(ProdutoModel produtoModel, string id)
        {
            try
            {
                var produto = await _produtoService.UpdateProdutoAsync(id, produtoModel);

                if (produto == null)
                {
                    return NotFound("Registro não localizado");
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ProdutoModel>> DeletarProduto(string id)
        {
            try
            {
                var resultado = await _produtoService.DeleteProdutoAsync(id);
                if (!resultado)
                {
                    return NotFound("Registro não localizado");
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}