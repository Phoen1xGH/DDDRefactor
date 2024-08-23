using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Validation.Extensions
{
    public static class ValidationResultExtensions
    {
        public static string[] GetValidationErrors(this ValidationResult result)
            => result.Errors
                .Select(e => e.ErrorMessage)
                .ToArray();
        
    }
}
