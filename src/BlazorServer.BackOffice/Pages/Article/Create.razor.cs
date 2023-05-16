using Application.Core.Dtos;
using Application.Core.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using BlazorServer.BackOffice.Models;
using MediatR;
using Application.Core.Features.Article.Queries;
using Application.Core.Features.Article.Commands.CreateArticle;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateBase : ComponentBase
    {
        [Inject]
        private IMediator mediator { get; set; }
        protected ArticleModel article { get; set; } = new();

        protected async Task HandleSubmit()
        {
            var query = new CreateArticleCommand();
            query.Name = article.Name;

            var articles = await mediator.Send(query);

        }



    }
}
