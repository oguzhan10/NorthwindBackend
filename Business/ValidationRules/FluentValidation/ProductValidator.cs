﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 30);
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThanOrEqualTo(1).When( p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartsWithA);

        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
