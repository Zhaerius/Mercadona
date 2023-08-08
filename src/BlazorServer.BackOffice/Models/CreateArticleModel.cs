using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.BackOffice.Models
{
    public class CreateArticleModel
    {
        public CreateArticleModel()
        {
            
        }
        public CreateArticleModel(Guid id, string name, string? description, string? image, double basePrice)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            BasePrice = basePrice;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double BasePrice { get; set; }
    }
}
