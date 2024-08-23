using CSharpFunctionalExtensions;
using DDDRefactor.Validation.Extensions;
using DDDRefactor.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DDDRefactor.Models.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        private Email(string address) => Address = address;

        private Email()
        {
            
        }
        public static Result<Email, string[]> Create(string address)
        {
            /*//if (string.IsNullOrWhiteSpace(address))
            //    return Result.Failure<Email>("Адрес эл. почты не должен быть пустым!");

            //if (!Regex.IsMatch(address, _emailPattern))
            //    return Result.Failure<Email>("Неверный формат адреса эл. почты");

            //return new Email(address);*/

            var emailInstance = new Email(address);

            var validationResult = new EmailValidator().Validate(emailInstance);

            if (!validationResult.IsValid)
                return validationResult.GetValidationErrors();

            return emailInstance;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}
