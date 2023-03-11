namespace Service.Services.Interfaces
{
    public interface IEnderecoServices
    {
        Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class;
    }
}
