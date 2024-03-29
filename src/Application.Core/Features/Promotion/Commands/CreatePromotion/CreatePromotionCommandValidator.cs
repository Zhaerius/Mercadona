﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Commands.CreatePromotion
{
    public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
    {
        private readonly DateOnly _today = DateOnly.FromDateTime(DateTime.Now);

        public CreatePromotionCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2);

            RuleFor(p => p.End)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(_today)
                .GreaterThanOrEqualTo(p => p.Start);

            RuleFor(p => p.Discount)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);             
        }
    }
}
