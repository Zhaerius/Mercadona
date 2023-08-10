namespace BlazorServer.BackOffice.Models
{
    public class CategoryModel
    {
        public CategoryModel(Guid id, string name, int numberArticles)
        {
            Id = id;
            Name = name;
            NumberArticles = numberArticles;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberArticles { get; set; }
    }
}
