using TicketSystem.DataAccess.Interface;
using TicketSystem.DataAccess.Model;

namespace TicketSystem.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserModel GetUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserModel GetUser(string account, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}