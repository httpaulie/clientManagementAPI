using AutoMapper;
using Infra.Data.Repository.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ClientePessoaJuridicaServices : IClientePessoaJuridicaServices
    {
        IClientePessoaJuridicaRepository _clientePessoaJuridicaRepository;
        IMapper _mapper;

        public ClientePessoaJuridicaServices(IClientePessoaJuridicaRepository clientePessoaJuridicaRepository, IMapper mapper)
        {
            _clientePessoaJuridicaRepository = clientePessoaJuridicaRepository;
            _mapper = mapper;
        }

        public async Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class
        {
            var entity = await _clientePessoaJuridicaRepository.GetByIdAsync(id);

            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
    }
}
