using Application.Core.Entities;
using Application.Core.Features.Article.Commands.CreateArticle;
using Application.Core.Features.Article.Queries.GetArticle;
using Application.Core.Features.Article.Queries.GetArticleWithPromotions;
using Application.Core.Features.Article.Queries.SearchArticles;
using Application.Core.Features.Category.Queries.GetCategorie;
using Application.Core.Features.Category.Queries.GetCategories;
using Application.Core.Features.Promotion.Commands.CreatePromotion;
using Application.Core.Features.Promotion.Queries.GetPromotion;
using Application.Core.Features.Promotion.Queries.GetPromotionsByStatus;
using AutoMapper;

namespace Application.Core.Common.Mappings
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<ArticleEntity, GetArticleQueryResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ArticleEntity, SearchArticlesQueryResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ArticleEntity, GetArticleWithPromotionsQueryResponse>();

            CreateMap<CreateArticleCommand, ArticleEntity>();


            CreateMap<CategoryEntity, GetCategoriesQueryResponse>();
            CreateMap<CategoryEntity, GetCategorieQueryResponse>();

            CreateMap<CreatePromotionCommand, PromotionEntity>();
            CreateMap<PromotionEntity, GetPromotionsByStatusQueryResponse>();
            CreateMap<PromotionEntity, GetPromotionQueryResponse>();
        }
    }
}
