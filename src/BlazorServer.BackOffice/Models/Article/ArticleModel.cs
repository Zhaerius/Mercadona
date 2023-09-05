namespace BlazorServer.BackOffice.Models.Article
{
    public class ArticleModel
    {
        public ArticleModel(Guid id, string name, string description, string image, double basePrice, double discountPrice, string categoryName, bool publish)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            BasePrice = basePrice;
            DiscountPrice = discountPrice;
            CategoryName = categoryName;
            Publish = publish;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double BasePrice { get; set; }
        public double DiscountPrice { get; set; }
        public string CategoryName { get; set; }
        public bool Publish { get; set; }

    }
}
