using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Promotion.Commands.UpdatePromotion
{
    public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
    {
        private readonly DateOnly _today = DateOnly.FromDateTime(DateTime.Now);
        public UpdatePromotionCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2);

            RuleFor(p => p.Start)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(_today);

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
