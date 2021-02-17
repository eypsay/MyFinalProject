using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
  public static  class ValidationTool
    {
        public static void Validate(IValidator validator ,object entity )
        {
            //commentli satırları refactor ederek tekrar yazdık
            //var context = new ValidationContext<Product>(product);
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator();
            // var result = productValidator.Validate(context);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
