namespace BlazorServer.BackOffice.Models.Article
{
    public class ArticleModel
    {
        public ArticleModel(string name, string description, string image, double basePrice, double discountPrice, string categoryName)
        {
            Name = name;
            Description = description;
            Image = image;
            BasePrice = basePrice;
            DiscountPrice = discountPrice;
            CategoryName = categoryName;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double BasePrice { get; set; }
        public double DiscountPrice { get; set; }
        public string CategoryName { get; set; }

    }
}
