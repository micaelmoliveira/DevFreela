using DevFreela.Application.Commands.ProjectCommand.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Título é obrigatório")
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de Título é de 30 caracteres");
                

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Descrição é obrigatória")
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Título é de 30 caracteres");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0)
                .WithMessage("Custo total deve ser maior que zero");
        }
    }
}
