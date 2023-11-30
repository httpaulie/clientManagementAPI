using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.Validators;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePessoaFisicaController : ControllerBase
    {
        private IBaseService<ClientePessoaFisica> _baseClientePessoaFisicaService;
        private IClientePessoaFisicaServices _clientePessoaFisicaService;

        public static int _totalPessoaFisica = 1;

        public ClientePessoaFisicaController(IBaseService<ClientePessoaFisica> baseClientePessoaFisicaService, IClientePessoaFisicaServices clientePessoaFisicaService)
        {
            _baseClientePessoaFisicaService = baseClientePessoaFisicaService;
            _clientePessoaFisicaService = clientePessoaFisicaService;
        }

        /// <summary>
        /// Cria um novo Cliente Pessoa Fisica.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Cria um novo Cliente Pessoa Fisica.
        ///     POST /api/ClientePessoaFisica
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "example",
        ///        "cpf": "00000000000",
        ///        "nascimento": "2023-03-13",
        ///        "ocupacao": "test",
        ///        "email": "test@test.com",
        ///        "telefone": "00000000000",
        ///        "enderecoId": 5,
        ///        "descricao": "very good example"
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Um novo item foi criado.</response>
        /// <response code="400">A requisição possui um ou mais erros de validação.</response> 
        [HttpPost]
        [ProducesResponseType(typeof(IdResponseDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] ClientePessoaFisicaRequestDTO client)
        {
            if (client == null)
                return NotFound();
            else
                _totalPessoaFisica++;

            return await ExecuteAsync(async () => await _baseClientePessoaFisicaService
                .AddAsync<ClientePessoaFisicaRequestDTO, IdResponseDTO, ClientePessoaFisicaValidator>(client));
        }

        /// <summary>
        /// Atualiza os dados de um Cliente Pessoa Fisica.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Atualiza os dados de um Cliente Pessoa Fisica.
        ///     PUT /api/ClientePessoaFisica/{id}
        ///     
        /// id
        /// 
        ///     2
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "example",
        ///        "cpf": "00000000000",
        ///        "nascimento": "2023-03-13",
        ///        "ocupacao": "test",
        ///        "email": "test@test.com",
        ///        "telefone": "00000000000",
        ///        "enderecoId": 5,
        ///        "descricao": "very good example"
        ///     }
        ///     
        /// </remarks>
        /// <returns>O item foi atualizado.</returns>
        /// <response code="200">O item foi atualizado.</response>
        /// <response code="400">A requisição possui um ou mais erros de validação.</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IdResponseDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(long id, [FromBody] ClientePessoaFisicaRequestDTO client)
        {
            if (id <= 0 || client == null)
                return NotFound();

            return await ExecuteAsync(async () => await _baseClientePessoaFisicaService
                .UpdateAsync<ClientePessoaFisicaRequestDTO, IdResponseDTO, ClientePessoaFisicaValidator>(id, client));
        }

        /// <summary>
        /// Deleta um Cliente Pessoa Fisica.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Deleta um Cliente Pessoa Fisica.
        ///     DELETE /api/ClientePessoaFisica/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// </remarks>
        /// <response code="204">Remoção realizada</response>
        /// <response code="404">Cliente não existe</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0)
                return NotFound();
            else
                _totalPessoaFisica--;

            await ExecuteAsync(async () =>
            {
                await _baseClientePessoaFisicaService.DeleteAsync(id);
                return true;
            });

            return new NoContentResult();
        }

        /// <summary>
        /// Retorna uma lista com todos os Clientes Pessoas Físicas.
        /// </summary>
        /// <remarks>
        /// Descrição:
        ///
        ///     GET /api/ClientePessoaFisica
        ///     Retorna uma lista com todos os Clientes Pessoas Físicas.
        ///
        /// </remarks>
        /// <response code="200">Retorna uma lista com todos os Clientes Pessoas Físicas.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ClientePessoaFisicaGetResponseDTO), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAsync(async () => await _baseClientePessoaFisicaService.GetAsync<ClientePessoaFisicaGetResponseDTO>());
        }

        /// <summary>
        /// Retorna um Cliente correspondente ao id passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/ClientePessoaFisica/{id}
        ///     Retorna um Cliente Pessoa Fisica correspondente ao id passado como parâmetro
        /// 
        /// Id Exemplo:
        ///
        ///     1
        ///
        /// </remarks>
        /// <response code="200">Retorna o Cliente correspondente ao id pesquisado</response>
        /// <response code="204">Se o valor pesquisado não for encontrado</response>
        /// <response code="404">Se o valor pesquisado não for válido</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientePessoaFisicaGetByIdResponseDTO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
                return NotFound();

            return await ExecuteAsync(async () => await _clientePessoaFisicaService.GetByIdAsync<ClientePessoaFisicaGetByIdResponseDTO>(id));
        }

        //APENAS PARA A CADEIRA DE POO
        /// <summary>
        /// Retorna o número total de Cliente Pessoa Fisica criados.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/Endereco/totalPessoaFisica
        ///     Retorna o número total de Cliente Pessoa Fisica criados
        /// 
        ///
        /// </remarks>
        /// <response code="200">Retorna o valor correspondente</response>
        [HttpGet("totalPessoaFisica")]
        public IActionResult ObterTotalPessoaFisica()
        {
            var totalEntidades = GetTotalPessoaFisica();
            return new JsonResult(totalEntidades);
        }

        //METODO ESTATICO APENAS PARA A CADEIRA DE POO
        private static int GetTotalPessoaFisica()
        {
            int totalEntidades = _totalPessoaFisica;
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
