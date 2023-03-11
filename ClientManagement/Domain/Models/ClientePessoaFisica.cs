using Domain.Base;

namespace Domain.Models
{
    public class ClientePessoaFisica : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Ocupacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Descricao { get; set; }
    }
}
