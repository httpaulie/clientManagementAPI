using Domain.Base;

namespace Application.DTOs.Response
{
    public class EnderecoGetByIdResponseDTO : BaseEntity
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public List<ClientePessoaFisicaGetResponseDTO> ClientesPessoasFisicas { get; set; }
        public List<ClientePessoaJuridicaGetResponseDTO> ClientesPessoasJuridicas { get; set; }
    }
}
