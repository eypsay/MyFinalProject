using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ProductValidator :AbstractValidator<Product>
    {
        //bu kurallar constructora yazılır
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2); //prodcut name ismi en az 2 karakter olmalıdır
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);         //iceicek cartegorisdeki içeceklerin unitrpice 10dan buyuk olmalı

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Üünler A ile başlamaı");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
