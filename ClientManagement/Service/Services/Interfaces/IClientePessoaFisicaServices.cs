namespace Service.Services.Interfaces
{
    public interface IClientePessoaFisicaServices
    {
        Task<TOutputModel> GetByIdAsync<TOutputModel>(long id) where TOutputModel : class;
    }
}
