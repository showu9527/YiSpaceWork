using TicketSystem.DataAccess.Model;

namespace TicketSystem.DataAccess.Interface
{
    public interface IUserRepository
    {
        UserModel GetUser(int id);

        UserModel GetUser(string account, string password);
    }
}