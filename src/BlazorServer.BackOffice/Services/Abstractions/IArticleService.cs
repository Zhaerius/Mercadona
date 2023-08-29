﻿using BlazorServer.BackOffice.Models.Article;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface IArticleService
    {
        Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name);
        Task<CreateArticleModel> GetDetailsArticle(Guid id);
        Task<bool> DeleteArticle(Guid id);
        Task<HttpResponseMessage> UploadImage(MultipartFormDataContent content);
    }
}