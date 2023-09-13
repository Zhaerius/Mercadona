using Application.Core.Entities;
using Application.Core.Features.Article.Commands.CreateArticle;
using Application.Core.Features.Article.Queries.GetArticle;
using Application.Core.Features.Article.Queries.SearchArticles;
using Application.Core.Features.Category.Queries.GetCategorie;
using Application.Core.Features.Category.Queries.GetCategories;
using Application.Core.Features.Promotion.Commands.CreatePromotion;
using AutoMapper;

namespace Application.Core.Mappings
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<ArticleEntity, GetArticleQueryResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ArticleEntity, SearchArticlesQueryResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateArticleCommand, ArticleEntity>();


            CreateMap<CategoryEntity, GetCategoriesQueryResponse>();
            CreateMap<CategoryEntity, GetCategorieQueryResponse>();

            CreateMap<CreatePromotionCommand, PromotionEntity>();

            //CreateMap<ArticleEntity, UpdateArticleCommand>().ReverseMap();
        }
    }
}
