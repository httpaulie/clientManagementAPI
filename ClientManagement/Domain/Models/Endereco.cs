using Domain.Base;

namespace Domain.Models
{
    public class Endereco : BaseEntity
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public virtual IEnumerable<ClientePessoaFisica> ClientesPessoasFisicas { get; set; }
        public virtual IEnumerable<ClientePessoaJuridica> ClientesPessoasJuridicas { get; set; }
    }
}
