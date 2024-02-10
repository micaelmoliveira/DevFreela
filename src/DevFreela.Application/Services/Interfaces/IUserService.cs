using static DevFreela.Application.InputDTO.Inputs;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewRecord? GetUser(int id);
        int Create(CreateUserInputRecord input);
    }
}
