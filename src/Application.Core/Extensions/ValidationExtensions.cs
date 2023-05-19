using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Extensions
{
    public static class ValidationExtensions
    {
        public static void ValidateBasic<T>(this IValidator<T> validator, T instance)
        {
            var result = validator.Validate(instance);

            if (!result.IsValid) 
            {
                throw new ValidationException(result.Errors.ToString());
            }
        }
    }
}
