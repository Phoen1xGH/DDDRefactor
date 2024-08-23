using CSharpFunctionalExtensions;
using DDDRefactor.Models.ValueObjects;
using DDDRefactor.Validation.Extensions;
using DDDRefactor.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Models
{
    public class Contact : BaseEntity
    {
        public LegalPerson Person { get; private set; }

        public bool IsNotify { get; private set; }

        public Email Email { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        private Contact(LegalPerson person, bool isNotify, Email email, PhoneNumber number)
        {
            Person = person;
            IsNotify = isNotify;
            Email = email;
            PhoneNumber = number;
        }


        private Contact()
        {
            
        }
        public static Result<Contact, string[]> Create(
            LegalPerson person, bool isNotify, 
            Email email, PhoneNumber number)
        {

            var notifyInstance = new Contact(person, isNotify, email, number);

            var validationResult = new NotifyValidator().Validate(notifyInstance);

            if (!validationResult.IsValid)
                return validationResult.GetValidationErrors();

            return notifyInstance;
        }
    }
}
