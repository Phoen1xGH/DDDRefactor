using DDDRefactor.Models;
using DDDRefactor.Models.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Validation.Validators
{
    public class AccessValidator : AbstractValidator<LegalPerson>
    {
        public AccessValidator() 
        {
            
        }
    }
}
