using Domain.Models;
using FluentValidation;

namespace Service.Validators
{
    public class ClientePessoaJuridicaValidator : AbstractValidator<ClientePessoaJuridica>
    {
        public ClientePessoaJuridicaValidator()
        {
            /*RuleFor(c => c.Id)
                .GreaterThan(0)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");*/

            RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.NomeFantasia)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.CNPJ)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.")
                .Length(14).WithMessage("Insira um CNPJ válido.");

            RuleFor(c => c.Fundacao)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.")
                .LessThan(p => DateTime.Now).WithMessage("Insira uma Data de Fundação válida.");

            RuleFor(c => c.EnderecoId)
                .GreaterThan(0)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigátório.")
                .MinimumLength(10).WithMessage("Insira um telefone válido")
                .MaximumLength(11).WithMessage("Insira um telefone válido.");
        }
    }
}
