using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Commands.DeleteArticle
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteArticleCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var articleToDelete = await _dbContext.Articles.FindAsync(request.Id);
            _dbContext.Articles.Remove(articleToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
