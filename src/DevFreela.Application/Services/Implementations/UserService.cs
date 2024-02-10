using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static DevFreela.Application.InputDTO.Inputs;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputRecord input)
        {
            var user = new User(input.FullName, input.Email, input.BirthDate);

            _dbContext.Add(user);

            _dbContext.SaveChanges();

            return user.Id; 
        }

        public UserViewRecord? GetUser(int id)
        {
            var user = _dbContext.Users.AsNoTracking().SingleOrDefault(u => u.Id == id);

            if (user is null) return null;

            return new UserViewRecord(user.FullName, user.Email);

        }
    }
}
