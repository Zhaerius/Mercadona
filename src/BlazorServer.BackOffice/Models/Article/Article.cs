using BlazorServer.BackOffice.Models.Category;

namespace BlazorServer.BackOffice.Models.Article
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double BasePrice { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool Publish { get; set; }
        public double DiscountPrice { get; set; }

    }
}
