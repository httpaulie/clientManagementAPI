using AutoMapper;
using Infra.Data.Repository.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ClientePessoaFisicaServices : IClientePessoaFisicaServices
    {
        IClientePessoaFisicaRepository _clientePessoaFisicaRepository;
        IMapper _mapper;

        public ClientePessoaFisicaServices(IClientePessoaFisicaRepository clientePessoaFisicaRepository, IMapper mapper)
        {
            _clientePessoaFisicaRepository = clientePessoaFisicaRepository;
            _mapper = mapper;
        }

        public async Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class
        {
            var entity = await _clientePessoaFisicaRepository.GetByIdAsync(id);

            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
    }
}
