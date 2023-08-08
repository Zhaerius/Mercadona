﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    public record CreateArticleCommand(
        string Name,
        string Description,
        double BasePrice,
        string Image,
        Guid CategoryId,
        IEnumerable<Guid>? PromotionsIds,
        bool Publish) : IRequest{}
}
