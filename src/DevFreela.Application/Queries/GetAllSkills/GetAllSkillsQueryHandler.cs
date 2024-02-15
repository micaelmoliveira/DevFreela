using DevFreela.Core.Repositories;
using MediatR;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewRecord>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillViewRecord>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();

            return skills
                .Select(s => new SkillViewRecord(s.Id, s.Description))
                .ToList();
        }
    }
}
