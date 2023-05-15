using Application.Core.Entities;
using Application.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }

    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new ArticleEntity
            {
                Name = request.Name,
                Description = request.Description
            };

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();

            return article.Id;

        }
    }
}
