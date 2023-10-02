namespace BlazorServer.BackOffice.Models.Article
{
    public class SearchArticlesResponse
    {
        public SearchArticlesResponse(Guid id, string name, string categoryName, decimal basePrice)
        {
            Id = id;
            Name = name;
            CategoryName = categoryName;
            BasePrice = basePrice;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal BasePrice { get; set; }
    }
}
