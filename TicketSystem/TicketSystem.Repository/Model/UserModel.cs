
using TicketSystem.Common.Enum;

namespace TicketSystem.DataAccess.Model
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public RoleEnum Role { get; set; }
    }
}