using Application.Core.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<GetCategoriesQueryResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
