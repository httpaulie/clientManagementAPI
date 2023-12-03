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
    public class ClientePessoaJuridicaController : ControllerBase
    {
        private IBaseService<ClientePessoaJuridica> _baseClientePessoaJuridicaService;
        private IClientePessoaJuridicaServices _clientePessoaJuridicaService;

        public static int _totalPessoaJuridica = 1;

        public ClientePessoaJuridicaController(IBaseService<ClientePessoaJuridica> baseClientePessoaJuridicaService, IClientePessoaJuridicaServices clientePessoaJuridicaService)
        {
            _baseClientePessoaJuridicaService = baseClientePessoaJuridicaService;
            _clientePessoaJuridicaService = clientePessoaJuridicaService;
        }

        /// <summary>
        /// Cria um novo Cliente Pessoa Juridica.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Cria um novo Cliente Pessoa Juridica.
        ///     POST /api/ClientePessoaJuridica
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "razaoSocial": "string",
        ///        "nomeFantasia": "string",
        ///        "cnpj": "string",
        ///        "fundacao": "2023-03-10T21:22:21.842Z",
        ///        "contatoNome": "string",
        ///        "telefone": "string",
        ///        "enderecoId": 0,
        ///        "descricao": "string"
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Um novo item foi criado.</response>
        /// <response code="400">A requisição possui um ou mais erros de validação.</response> 
        [HttpPost]
        [ProducesResponseType(typeof(IdResponseDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] ClientePessoaJuridicaRequestDTO client)
        {
            if (client == null)
                return NotFound();
            else
                _totalPessoaJuridica++;

            return await ExecuteAsync(async () => await _baseClientePessoaJuridicaService
                .AddAsync<ClientePessoaJuridicaRequestDTO, IdResponseDTO, ClientePessoaJuridicaValidator>(client));
        }

        /// <summary>
        /// Atualiza os dados de um Cliente Pessoa Juridica.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Atualiza os dados de um Cliente Pessoa Juridica.
        ///     PUT /api/ClientePessoaJuridica/{id}
        ///     
        /// id
        /// 
        ///     2
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "razaoSocial": "string",
        ///        "nomeFantasia": "string",
        ///        "cnpj": "string",
        ///        "fundacao": "2023-03-10T21:22:21.842Z",
        ///        "contatoNome": "string",
        ///        "telefone": "string",
        ///        "enderecoId": 0,
        ///        "descricao": "string"
        ///     }
        ///     
        /// </remarks>
        /// <returns>O item foi atualizado.</returns>
        /// <response code="200">O item foi atualizado.</response>
        /// <response code="400">A requisição possui um ou mais erros de validação.</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IdResponseDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(long id, [FromBody] ClientePessoaJuridicaRequestDTO client)
        {
            if (id <= 0 || client == null)
                return NotFound();

            return await ExecuteAsync(async () => await _baseClientePessoaJuridicaService
                .UpdateAsync<ClientePessoaJuridicaRequestDTO, IdResponseDTO, ClientePessoaJuridicaValidator>(id, client));
        }

        /// <summary>
        /// Deleta um Cliente Pessoa Juridica.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Deleta um Cliente Pessoa Juridica.
        ///     DELETE /api/ClientePessoaJuridica/{id}
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
                _totalPessoaJuridica--;

            await ExecuteAsync(async () =>
            {
                await _baseClientePessoaJuridicaService.DeleteAsync(id);
                return true;
            });

            return new NoContentResult();
        }

        /// <summary>
        /// Retorna uma lista com todos os Clientes Pessoas Juridicas.
        /// </summary>
        /// <remarks>
        /// Descrição:
        ///
        ///     GET /api/ClientePessoaJuridica
        ///     Retorna uma lista com todos os Clientes Pessoas Juridicas.
        ///
        /// </remarks>
        /// <response code="200">Retorna uma lista com todos os Clientes Pessoas Juridicas.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ClientePessoaJuridicaGetResponseDTO), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAsync(async () => await _baseClientePessoaJuridicaService.GetAsync<ClientePessoaJuridicaGetResponseDTO>());
        }
        
        /// <summary>
        /// Retorna um Cliente correspondente ao id passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/ClientePessoaJuridica/{id}
        ///     Retorna um Cliente Pessoa Juridica correspondente ao id passado como parâmetro
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
        [ProducesResponseType(typeof(ClientePessoaJuridicaGetByIdResponseDTO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
                return NotFound();

            return await ExecuteAsync(async () => await _clientePessoaJuridicaService.GetByIdAsync<ClientePessoaJuridicaGetByIdResponseDTO>(id));
        }

        //APENAS PARA A CADEIRA DE POO
        /// <summary>
        /// Retorna o número total de Cliente Pessoa Jurídica criados.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/Endereco/totalPessoaJuridica
        ///     Retorna o número total de Cliente Pessoa Jurídica criados
        /// 
        ///
        /// </remarks>
        /// <response code="200">Retorna o valor correspondente</response>
        [HttpGet("totalPessoaJuridica")]
        public IActionResult ObterTotalPessoaJuridica()
        {
            var totalEntidades = GetTotalPessoaJuridica();
            return new JsonResult(totalEntidades);
        }

        //METODO ESTATICO APENAS PARA A CADEIRA DE POO
        private static int GetTotalPessoaJuridica()
        {
            int totalEntidades = _totalPessoaJuridica;
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
