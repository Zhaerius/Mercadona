﻿using Application.Core.Abstractions;
using Application.Core.Exceptions;
using Application.Core.Features.Article.Queries.GetArticle;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Features.Category.Queries.GetCategorie
{
    public class GetCategorieQueryHandler : IRequestHandler<GetCategorieQuery, GetCategorieQueryResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategorieQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetCategorieQueryResponse> Handle(GetCategorieQuery request, CancellationToken cancellationToken)
        {
            var categorie = await _dbContext
                .Categories
                .FindAsync(request.Id, cancellationToken) ?? throw new NotFoundException();

            return _mapper.Map<GetCategorieQueryResponse>(categorie);
        }
    }
}
