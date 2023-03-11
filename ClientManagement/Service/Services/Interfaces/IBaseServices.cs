using Domain.Base;
using FluentValidation;

namespace Service.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TOutputModel> AddAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
                    where TValidator : AbstractValidator<TEntity>
                    where TInputModel : class
                    where TOutputModel : class;

        Task DeleteAsync(long id);

        Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class;

        Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class;

        Task<TOutputModel> UpdateAsync<TInputModel, TOutputModel, TValidator>(long id, TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
