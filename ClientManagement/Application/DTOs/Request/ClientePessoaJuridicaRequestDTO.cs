namespace Application.DTOs.Request
{
    public class ClientePessoaJuridicaRequestDTO
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public DateTime Fundacao { get; set; }
        public string ContatoNome { get; set; }
        public string Telefone { get; set; }
        public long EnderecoId { get; set; }
        public string Descricao { get; set; }
    }
}
