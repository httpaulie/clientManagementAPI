using Domain.Base;

namespace Application.DTOs.Response
{
    public class ClientePessoaJuridicaGetResponseDTO : BaseEntity
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public DateTime Fundacao { get; set; }
        public string Descricao { get; set; }
    }
}
