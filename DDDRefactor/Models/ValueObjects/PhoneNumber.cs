using CSharpFunctionalExtensions;
using DDDRefactor.Validation.Extensions;
using DDDRefactor.Validation.Validators;
using System.Text.RegularExpressions;

namespace DDDRefactor.Models.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; private set; }

        private PhoneNumber(string number) => Number = number;

        private PhoneNumber()
        {
            
        }
        public static Result<PhoneNumber, string[]> Create(string number)
        {
            /*//if (string.IsNullOrWhiteSpace(number))
            //    return Result.Failure<PhoneNumber>("Номер телефона не должен быть пустым");

            //if (!Regex.IsMatch(number, _phoneNumberPattern))
            //    return Result.Failure<PhoneNumber>("Неверный формат номера телефона");

            //return new PhoneNumber(number);*/

            var numberInstance = new PhoneNumber(number);

            var validationResult = new PhoneNumberValidator().Validate(numberInstance);

            if(!validationResult.IsValid)
                return validationResult.GetValidationErrors();

            return numberInstance;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}