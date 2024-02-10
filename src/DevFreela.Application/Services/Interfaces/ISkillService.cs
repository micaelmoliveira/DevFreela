using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewRecord> GetAll();
    }
}
