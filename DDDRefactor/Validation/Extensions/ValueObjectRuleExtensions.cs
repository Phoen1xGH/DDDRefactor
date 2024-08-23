using CSharpFunctionalExtensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Validation.Extensions
{
    public static class ValueObjectRuleExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeValueObject<T, TValueObject>(
            this IRuleBuilder<T, string> ruleBuilder, 
            Func<string, Result<TValueObject>> factoryMethod) 
            where TValueObject : ValueObject
        {
            return (IRuleBuilderOptions<T, string>)ruleBuilder.Custom((value, context) => 
            {
                Result<TValueObject> result = factoryMethod(value);

                if (result.IsFailure)
                {
                    context.AddFailure(result.Error);
                }
            });
        }
    }
}
