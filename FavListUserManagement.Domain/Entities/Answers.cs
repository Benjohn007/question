namespace FavListUserManagement.Domain.Entities
{
    public class Answers : BaseEntity
    {
        public Question? Question { get; set; }
        public string? QuestionID { get; set; }
        public string? Text { get; set; }
        public int Vote_Count { get; set; }
        public int Weight { get; set; }
    }
}