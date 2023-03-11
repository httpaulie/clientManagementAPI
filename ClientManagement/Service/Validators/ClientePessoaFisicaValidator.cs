using Domain.Models;
using FluentValidation;

namespace Service.Validators
{
    public class ClientePessoaFisicaValidator : AbstractValidator<ClientePessoaFisica>
    {
        public ClientePessoaFisicaValidator()
        {
            //RuleFor(c => c.Id).GreaterThan(0);

            RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Campo obrigatório.")
            .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Campo obrigatório.")
            .NotNull().WithMessage("Campo obrigatório.")
            .EmailAddress().WithMessage("Insira um email válido.");

            RuleFor(c => c.CPF)
            .NotEmpty().WithMessage("Campo obrigatório.")
            .NotNull().WithMessage("Campo obrigatório.")
            .Length(11).WithMessage("Insira um CPF válido.");

            RuleFor(c => c.Nascimento)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.")
                .LessThan(p => DateTime.Now).WithMessage("Insira uma Data de Nascimento válida.");

            RuleFor(c => c.EnderecoId).GreaterThan(0);

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigátório.")
                .MinimumLength(10).WithMessage("Insira um telefone válido")
                .MaximumLength(11).WithMessage("Insira um telefone válido.");
        }
    }
}
