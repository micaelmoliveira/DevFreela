namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int userId, int skillId)
        {
            IdUser = userId;
            IdSkill = skillId;
        }

        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
        public Skill Skill { get; set; }
    }
}
