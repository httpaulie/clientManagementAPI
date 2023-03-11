using Domain.Base;

namespace Application.DTOs.Response
{
    public class ClientePessoaFisicaGetByIdResponseDTO : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Ocupacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoGetResponseDTO Endereco { get; set; }
        public string Descricao { get; set; }
    }
}
