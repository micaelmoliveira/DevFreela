﻿namespace DevFreela.Application.InputDTO
{
    public class Inputs
    {
        public record NewProjectInputRecord(string Title, string Description, int IdClient, int IdFreelancer, decimal TotalCost);
        public record UpdateProjectInputRecord(int Id, string Title, string Description, decimal TotalCost);
        public record CreateCommentInputRecord(string Content, int ProjectId, int IdUser);
        public record CreateUserInputRecord(string FullName, string Password, string Email, DateTime BirthDate);
    }
}




