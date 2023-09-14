using Dapper;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly string _connectionString;

        public GetAllSkillsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs")!;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM skills";

                var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);

                return skills.ToList();
            }

            /* COM EF CORE
                var skills = await _dbContext.Skills;

                var skillsViewModel = skills
                    .Select(s => new SkillViewModel(s.Id, s.Description))
                    .ToList();

                return skillsViewModel;
            */
        }
    }
}
