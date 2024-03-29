﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Commands.UpdateArticle
{
    public record UpdateArticleCommand(
        Guid Id,
        string Name,
        string Description,
        decimal BasePrice,
        string Image,
        Guid CategoryId,
        bool Publish,
        IEnumerable<Guid>? PromotionsIds) : IRequest{}
}
