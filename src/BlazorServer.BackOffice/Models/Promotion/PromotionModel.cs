namespace BlazorServer.BackOffice.Models.Promotion
{
    public class PromotionModel
    {
        public Guid Id { get; set; }    
        public required string Name { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
    }
}
