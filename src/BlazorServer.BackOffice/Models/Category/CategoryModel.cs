using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Models.Category
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int NumberArticles { get; set; }
    }
}
