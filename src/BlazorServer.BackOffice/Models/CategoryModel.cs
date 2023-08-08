namespace BlazorServer.BackOffice.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }  
        public int NumberArticles { get; set; }
    }
}
