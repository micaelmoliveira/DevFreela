namespace DevFreela.Application.ViewDTO
{
    public class Views
    {
        public record ProjectViewRecord(int Id, string Title, DateTime CreatedAt);
        public record ProjectDetailsViewRecord(
            int id, 
            string Title, 
            string Description, 
            decimal TotalCost, 
            DateTime? StartedAt, 
            DateTime? FinishedAt, 
            string clientFullName, 
            string freelancerFullName);

        public record SkillViewRecord(int Id, string Description);
        public record UserViewRecord(string FullName, string Email);
        public record LoginUserRecord(string email, string token);
    }
}


