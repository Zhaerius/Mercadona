using Application.Core.Entities;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.BackOffice.Models.Article
{
    public class CreateArticleModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Image { get; set; }
        public double BasePrice { get; set; }
        public bool Publish { get; set; }
    }
}
