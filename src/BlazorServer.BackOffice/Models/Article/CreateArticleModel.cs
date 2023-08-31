using Application.Core.Entities;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.BackOffice.Models.Article
{
    public class CreateArticleModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        public string? Image { get; set; }
        [Required]
        public double? BasePrice { get; set; }
        public bool Publish { get; set; }
    }
}
