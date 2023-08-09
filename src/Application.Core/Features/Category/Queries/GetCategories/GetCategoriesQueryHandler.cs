using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<GetCategoriesQueryResponse>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetCategoriesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetCategoriesQueryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _dbContext
                .Categories
                .Include(r => r.Articles)
                .ToListAsync(cancellationToken);

            var categoriesDto = new List<GetCategoriesQueryResponse>();

            foreach (var category in categories)
            {
                var artToAdd = new GetCategoriesQueryResponse(category.Id, category.Name, category.Articles.Count());
                categoriesDto.Add(artToAdd);
            }

            return categoriesDto.OrderByDescending(o => o.NumberArticles);
        }
    }
}
