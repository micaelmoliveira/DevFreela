using MediatR;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewRecord?>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
