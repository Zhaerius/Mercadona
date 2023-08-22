namespace BlazorServer.BackOffice.Models.Article
{
    public class FakePlaceholderArticle
    {
        public FakePlaceholderArticle(string name, string description, string categoryName, double basePrice, bool publish)
        {
            Name = name;
            Description = description;
            CategoryName = categoryName;
            BasePrice = basePrice;
            Publish = publish;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public double BasePrice { get; set; }
        public bool Publish { get; set; }
    }
}
