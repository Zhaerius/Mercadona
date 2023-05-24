using BlazorServer.BackOffice.ApiServices;
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class SearchBase : ComponentBase
    {
        [Inject]
        private ArticleApiService ApiService { get; set; }

        protected IEnumerable<SearchArticlesModel> Articles { get; set; } = new List<SearchArticlesModel>();

        protected SearchInputModel Input { get; set; } = new SearchInputModel();


        protected async Task SearchArticles()
        {
            Articles = await ApiService.SearchArticles(Input.Name);
        }
        
    }
}
