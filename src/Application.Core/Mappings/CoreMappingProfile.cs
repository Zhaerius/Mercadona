using Application.Core.Entities;
using Application.Core.Features.Article.Queries.GetArticle;
using Application.Core.Features.Article.Queries.SearchArticles;
using Application.Core.Features.Category.Queries.GetCategories;
using Application.Core.Features.Promotion.Commands.CreatePromotion;
using AutoMapper;

namespace Application.Core.Mappings
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<ArticleEntity, GetArticleQueryResponse>();
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ArticleEntity, SearchArticlesQueryResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CategoryEntity, GetCategoriesQueryResponse>();

            CreateMap<CreatePromotionCommand, PromotionEntity>();

            //CreateMap<ArticleEntity, UpdateArticleCommand>().ReverseMap();
        }
    }
}
