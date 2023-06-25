namespace FavListUserManagement.Domain.Entities
{
    public class Category : BaseEntity
    {
        public String? Name { get; set; }       
        public string? Colour { get; set; }
        public ICollection<Question>? Question { get; set; }
    }
}