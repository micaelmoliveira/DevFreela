using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using static DevFreela.Application.InputDTO.Inputs;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        public int Create(CreateUserInputRecord input)
        {
            var user = new User(input.FullName, input.Email, input.BirthDate);

            return user.Id; 
        }

        public UserViewRecord? GetUser(int id)
        {
            var data = new DateTime(1992, 10, 20);
            var user = new User("Teste", "teste", data);

            if (user is null) return null;

            return new UserViewRecord(user.FullName, user.Email);

        }
    }
}
