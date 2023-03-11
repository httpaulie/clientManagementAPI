using AutoMapper;
using Domain.Base;
using FluentValidation;
using Infra.Data.Repository.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<TOutputModel> AddAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            await _baseRepository.InsertAsync(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public async Task DeleteAsync(long id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class
        {
            var entities = await _baseRepository.SelectAsync();

            var outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));

            return outputModels;
        }

        public async Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class
        {
            var entity = await _baseRepository.SelectAsync(id);

            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public async Task<TOutputModel> UpdateAsync<TInputModel, TOutputModel, TValidator>(long id, TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);
            entity.Id = id;
            Validate(entity, Activator.CreateInstance<TValidator>());
            await _baseRepository.UpdateAsync(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
