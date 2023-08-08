
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;


namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateArticleBase : ComponentBase
    {
        //[Inject]
        //private IMediator mediator { get; set; }
        //protected ArticleModel article { get; set; } = new();

        //protected async Task HandleSubmit()
        //{
        //    //var query = new CreateArticleCommand();
        //    //query.Name = article.Name;

        //    //var articles = await mediator.Send(query);

        public CreateArticleModel ArticleToCreate { get; set; } = new();

        protected async Task OnValidSubmit()
        {

        }

    }
}
