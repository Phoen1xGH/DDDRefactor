using DDDRefactor.Models;
using FluentValidation;

namespace DDDRefactor.Validation.Validators
{
    public class NotifyValidator : AbstractValidator<Contact>
    {
        public NotifyValidator()
        {
            RuleFor(notify => notify.Person).NotNull();
        }
    }
}
