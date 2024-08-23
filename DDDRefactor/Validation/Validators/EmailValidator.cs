using DDDRefactor.Models.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Validation.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        private const string _emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public EmailValidator()
        {
            RuleFor(number => number.Address)
                .NotEmpty().WithMessage("Адрес эл. почты не должен быть пустым!")
                .Matches(_emailPattern).WithMessage("Неверный формат адреса эл. почты");
        }
    }
}
