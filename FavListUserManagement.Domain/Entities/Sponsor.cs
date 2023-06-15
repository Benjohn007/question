namespace FavListUserManagement.Domain.Entities
{
    public class Sponsor : BaseEntity
    {
        public string Name { get; set; }
        public string? Logo_S3_Url { get; set; }
        public string? Ad_S3_Url { get; set; }

    }
}