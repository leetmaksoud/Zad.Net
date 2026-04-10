using FluentValidation;
using Zad.Application.DTOs;

namespace Zad.Application.Validators;

public class CreateChatSessionRequestValidator : AbstractValidator<CreateChatSessionRequest>
{
    public CreateChatSessionRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.Name));
    }
}
