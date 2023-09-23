using Application.Core.Entities;
using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateArticleCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleToUpdate = await _dbContext
                .Articles
                .Include(c => c.Promotions)
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken) ?? throw new NotFoundException();

            // Null Propagation, syntaxe c#6, si promotion est null, le clear sera ignoré.
            articleToUpdate.Promotions?.Clear();

            if (request.PromotionsIds is not null && request.PromotionsIds.Any())
            {
                var promotions = await _dbContext.Promotions
                    .Where(p => request.PromotionsIds.Contains(p.Id))
                    .ToListAsync(cancellationToken);

                articleToUpdate.Promotions = promotions;
            }

            articleToUpdate.Name = request.Name;
            articleToUpdate.Description = request.Description;
            articleToUpdate.Image = request.Image;
            articleToUpdate.BasePrice = request.BasePrice;
            articleToUpdate.CategoryId = request.CategoryId;
            articleToUpdate.Publish = request.Publish;

            _dbContext.Articles.Update(articleToUpdate);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
