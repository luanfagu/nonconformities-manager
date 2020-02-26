using FluentValidation;

namespace TesteQualyteam.Application.Actions.Commands.CreateAction
{
    public class CreateActionCommandValidator : AbstractValidator<CreateActionCommand>
    {
        public CreateActionCommandValidator()
        {
            RuleFor(v => v.Description)
                .NotEmpty();
        }
    }
}
