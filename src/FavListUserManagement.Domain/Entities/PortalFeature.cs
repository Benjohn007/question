namespace FavListUserManagement.Domain.Entities
{
    public class PortalFeature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Screen_Path { get; set; }
        public bool Active_status { get; set; }
        public Catergory? Catergory_Id { get; set; }
        public string? Icon { get; set; }
    }
}