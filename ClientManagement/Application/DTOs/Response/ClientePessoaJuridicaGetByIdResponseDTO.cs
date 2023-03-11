using Domain.Base;

namespace Application.DTOs.Response
{
    public class ClientePessoaJuridicaGetByIdResponseDTO : BaseEntity
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public DateTime Fundacao { get; set; }
        public string ContatoNome { get; set; }
        public string Telefone { get; set; }
        public EnderecoGetResponseDTO Endereco { get; set; }
        public string Descricao { get; set; }
    }
}
