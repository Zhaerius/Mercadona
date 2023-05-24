using Application.Core.Dtos;
using Application.Core.Entities;
using Application.Core.Features.Article.Commands.UpdateArticle;
using Application.Core.Features.Article.Queries.GetArticle;
using Application.Core.Features.Article.Queries.SearchArticles;
using AutoMapper;

namespace Application.Core.Mappings
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<ArticleEntity, ArticleDto>();
            //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ArticleEntity, SearchArticlesQueryResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<PromotionEntity, PromotionDto>();

            CreateMap<ArticleEntity, UpdateArticleCommand>().ReverseMap();
        }
    }
}
