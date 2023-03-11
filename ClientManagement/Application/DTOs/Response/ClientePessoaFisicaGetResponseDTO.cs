using Domain.Base;

namespace Application.DTOs.Response
{
    public class ClientePessoaFisicaGetResponseDTO : BaseEntity
    {
        public string Nome { get; set; }
        public string Ocupacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
    }
}
