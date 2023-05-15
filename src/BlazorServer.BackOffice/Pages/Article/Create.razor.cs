using Application.Core.Dtos;
using Application.Core.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateBase : ComponentBase
    {
        [Inject]
        private IArticleService articleService { get; set; }
        [Inject]
        private IMapper mapper { get; set; }
        protected ArticleModel article { get; set; } = new();

        protected void HandleSubmit()
        {
            var articleDto = mapper.Map<ArticleDto>(article);
            articleService.AddArticle(articleDto);
        }



    }
}
