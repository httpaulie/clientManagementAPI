using Domain.Models;
using FluentValidation;

namespace Service.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            /*RuleFor(c => c.Id)
                .GreaterThan(0)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");*/

            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.")
                .Length(8).WithMessage("Insira um CNPJ válido.");

            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.");

            RuleFor(c => c.UF)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .NotNull().WithMessage("Campo obrigatório.")
                .Length(2).WithMessage("Insira uma UF válido.");
        }
    }
}
