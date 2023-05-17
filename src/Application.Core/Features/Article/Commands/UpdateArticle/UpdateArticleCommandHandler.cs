using Application.Core.Entities;
using Application.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var articleToUpdate = _mapper.Map<ArticleEntity>(request);
            _dbContext.Articles.Update(articleToUpdate);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
