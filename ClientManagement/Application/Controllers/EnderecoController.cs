using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Models;
using Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;
using Service.Validators;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private IBaseService<Endereco> _baseEnderecoService;
        private IEnderecoServices _enderecoService;
        
        //APENAS PARA A CADEIRA DE POO
        public static int _totalEnderecos = 2;

        public EnderecoController(IBaseService<Endereco> baseEnderecoService, IEnderecoServices enderecoService)
        {
            _baseEnderecoService = baseEnderecoService;
            _enderecoService = enderecoService;
        }

        /// <summary>
        /// Cria um novo Endereco.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Cria um novo Endereco.
        ///     POST /api/Endereco
        ///     
        /// Exemplo:
        /// 
        ///     {   
        ///        "cep": "00000000",
        ///        "logradouro": "Rua Teste, 000",
        ///        "complemento": "Apto 000",
        ///        "bairro": "Liberdade",
        ///        "cidade": "São Paulo",
        ///        "uf": "SP"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Um novo item foi criado.</response>
        /// <response code="400">A requisição possui um ou mais erros de validação.</response> 
        [HttpPost]
        [ProducesResponseType(typeof(IdResponseDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] EnderecoRequestDTO endereco)
        {
            if (endereco == null)
                return NotFound();
            else
                _totalEnderecos++;

            return await ExecuteAsync(async () => await _baseEnderecoService
                .AddAsync<EnderecoRequestDTO, IdResponseDTO, EnderecoValidator>(endereco));
        }

        /// <summary>
        /// Atualiza os dados de um Endereco.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Atualiza os dados de um Endereco.
        ///     PUT /api/Endereco/{id}
        ///     
        /// id
        /// 
        ///     2
        ///     
        /// Exemplo:
        /// 
        ///     {   
        ///        "cep": "00000000",
        ///        "logradouro": "Rua Teste, 000",
        ///        "complemento": "Apto 000",
        ///        "bairro": "Liberdade",
        ///        "cidade": "São Paulo",
        ///        "uf": "SP"
        ///     }
        ///     
        /// </remarks>
        /// <returns>O item foi atualizado.</returns>
        /// <response code="200">O item foi atualizado.</response>
        /// <response code="400">A requisição possui um ou mais erros de validação.</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IdResponseDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(long id, [FromBody] EnderecoRequestDTO endereco)
        {
            if (id <= 0 || endereco == null)
                return NotFound();

            return await ExecuteAsync(async () => await _baseEnderecoService
                .UpdateAsync<EnderecoRequestDTO, IdResponseDTO, EnderecoValidator>(id, endereco));
        }

        /// <summary>
        /// Deleta um Endereco.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Deleta um Endereco.
        ///     DELETE /api/Endereco/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// </remarks>
        /// <response code="204">Remoção realizada</response>
        /// <response code="404">Endereco não existe</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0)
                return NotFound();
            else
                _totalEnderecos--;

            await ExecuteAsync(async () =>
            {
                await _baseEnderecoService.DeleteAsync(id);
                return true;
            });

            return new NoContentResult();
        }

        /// <summary>
        /// Retorna uma lista com todos os Enderecos.
        /// </summary>
        /// <remarks>
        /// Descrição:
        ///
        ///     GET /api/Enderecos
        ///     Retorna uma lista com todos os Enderecos.
        ///
        /// </remarks>
        /// <response code="200">Retorna uma lista com todos os Enderecos.</response>
        [HttpGet]
        [ProducesResponseType(typeof(EnderecoGetResponseDTO), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAsync(async () => await _baseEnderecoService.GetAsync<EnderecoGetResponseDTO>());
        }

        /// <summary>
        /// Retorna um Endereco correspondente ao id passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/Endereco/{id}
        ///     Retorna um Endereco correspondente ao id passado como parâmetro
        /// 
        /// Id Exemplo:
        ///
        ///     1
        ///
        /// </remarks>
        /// <response code="200">Retorna o Endereço correspondente ao id pesquisado</response>
        /// <response code="204">Se o valor pesquisado não for encontrado</response>
        /// <response code="404">Se o valor pesquisado não for válido</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EnderecoGetByIdResponseDTO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
                return NotFound();

            return await ExecuteAsync(async () => await _enderecoService.GetByIdAsync<EnderecoGetByIdResponseDTO>(id));
        }

        //APENAS PARA A CADEIRA DE POO
        /// <summary>
        /// Retorna o número total de endereços criados.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/Endereco/totalEnderecos
        ///     Retorna o número total de endereços criados
        /// 
        ///
        /// </remarks>
        /// <response code="200">Retorna o valor correspondente</response>
        [HttpGet("totalEnderecos")]
        public IActionResult ObterTotalEnderecos()
        {
            var totalEntidades = GetTotalEnderecos();
            return new JsonResult(totalEntidades);
        }

        //METODO ESTATICO APENAS PARA A CADEIRA DE POO
        private static int GetTotalEnderecos()
        {
            int totalEntidades = _totalEnderecos;
            return totalEntidades;
        }

        private async Task<IActionResult> ExecuteAsync(Func<Task<object>> func)
        {
            try
            {
                var result = await func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
