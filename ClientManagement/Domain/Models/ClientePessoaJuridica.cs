using Domain.Base;

namespace Domain.Models
{
    public class ClientePessoaJuridica : BaseEntity
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public DateTime Fundacao { get; set; }
        public string ContatoNome { get; set; }
        public string Telefone { get; set; }
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Descricao { get; set; }
    }
}
