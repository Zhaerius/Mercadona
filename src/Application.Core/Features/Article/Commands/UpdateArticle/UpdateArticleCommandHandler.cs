using Application.Core.Entities;
using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Article.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateArticleCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleToUpdate = await _dbContext
                .Articles
                .Include(c => c.Promotions)
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken) ?? throw new NotFoundException();

            if (request.PromotionsIds is null || !request.PromotionsIds.Any())
            {
                articleToUpdate.Promotions = null;
            }


            if (request.PromotionsIds is not null && request.PromotionsIds.Any())
            {
                var promotions = await _dbContext.Promotion
                    .Where(p => request.PromotionsIds.Contains(p.Id))
                    .ToListAsync();

                articleToUpdate.Promotions = promotions;
            }

            articleToUpdate.Name = request.Name;
            articleToUpdate.Description = request.Description;
            articleToUpdate.Image = request.Image;
            articleToUpdate.BasePrice = request.BasePrice;
            articleToUpdate.CategoryId = request.CategoryId;


            _dbContext.Articles.Update(articleToUpdate);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
