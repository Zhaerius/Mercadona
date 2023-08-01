namespace BlazorWasm.BackOffice.Models
{
    public class SearchArticlesResponse
    {
        public SearchArticlesResponse(Guid id, string name, string categoryName, double basePrice)
        {
            Id = id;
            Name = name;
            CategoryName = categoryName;
            BasePrice = basePrice;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public double BasePrice { get; set; }
    }
}
