using FluentValidation;
using slack.Domain.Commands;

namespace slack.Domain.Validations
{
    public class SlackValidator : AbstractValidator<SlackCommand>
    {
        public SlackValidator()
        {
            RuleFor(command => command.Mensagem)
                .NotEmpty();

        }
    }
}
