namespace Service.Services.Interfaces
{
    public interface IClientePessoaJuridicaServices
    {
        Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class;
    }
}
