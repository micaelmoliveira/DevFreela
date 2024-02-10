﻿namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity 
    {
        public ProjectComment(string content, int projectId, int userId)
        {
            Content = content;
            IdProject = projectId;
            IdUser = userId;
            CreatedAt = DateTime.UtcNow;
        }

        public string Content { get; private set; }
        public Project Project { get; set; }
        public int IdProject { get; private set; }
        public User User { get; set; }
        public int IdUser { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
