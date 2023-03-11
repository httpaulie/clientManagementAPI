using AutoMapper;
using Infra.Data.Repository.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        IEnderecoRepository _enderecoRepository;
        IMapper _mapper;
        public EnderecoServices(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class
        {
            var entity = await _enderecoRepository.GetByIdAsync(id);

            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
    }
}
