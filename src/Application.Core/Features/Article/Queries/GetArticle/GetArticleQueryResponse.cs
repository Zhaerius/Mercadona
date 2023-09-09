using Application.Core.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Article.Queries.GetArticle
{
    public class GetArticleQueryResponse
    {
        public GetArticleQueryResponse(Guid id, string name, string description, string image, double basePrice, double discountPrice, Guid categoryId, string categoryName, bool publish)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            BasePrice = basePrice;
            DiscountPrice = discountPrice;
            CategoryId = categoryId;
            CategoryName = categoryName;
            Publish = publish;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Publish { get; set; }
        public double DiscountPrice { get; set; }
    }
}
