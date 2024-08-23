using DDDRefactor.Models.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Validation.Validators
{
    public class PhoneNumberValidator : AbstractValidator<PhoneNumber>
    {
        /* Пояснение
           ^ - начало строки.
           (\+?\d{1,3})? - опциональная группа для международного кода, который может начинаться с +, за которым следуют от 1 до 3 цифр.
           [-.\s]? - опциональный разделитель (дефис, точка, пробел).
           (\(?\d{3}\)?) - группа для кода региона или оператора. Это может быть набор из 3 цифр, которые могут быть заключены в скобки.
           [-.\s]? - опциональный разделитель.
           (\d{3}) - следующая группа из 3 цифр.
           [-.\s]? - опциональный разделитель.
           (\d{2,4}) - группа из 2-4 цифр (первая часть номера).
           [-.\s]? - опциональный разделитель.
           (\d{2,4}) - группа из 2-4 цифр (вторая часть номера).
           $ - конец строки.
        */
        private const string _phoneNumberPattern = @"^(\+?\d{1,3})?[-.\s]?(\(?\d{3}\)?)[-.\s]?(\d{3})[-.\s]?(\d{2,4})[-.\s]?(\d{2,4})$";

        public PhoneNumberValidator() 
        {
            RuleFor(number => number.Number)
                .NotEmpty().WithMessage("Номер телефона не должен быть пустым")
                .Matches(_phoneNumberPattern).WithMessage("Неверный формат номера телефона");
        }
    }
}

