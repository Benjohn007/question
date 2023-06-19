namespace FavListUserManagement.Domain.Entities
{
    public class PortalFeature : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Screen_Path { get; set; }
        public Category? Catergory_Id { get; set; }
        public string? Icon { get; set; }
    }
}