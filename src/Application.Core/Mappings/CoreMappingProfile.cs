using Application.Core.Dtos;
using Application.Core.Entities;
using Application.Core.Features.Article.Commands.UpdateArticle;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<ArticleEntity, ArticleDto>();

            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<PromotionEntity, PromotionDto>();

            CreateMap<ArticleEntity, UpdateArticleCommand>().ReverseMap();
        }
    }
}
