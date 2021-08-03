using System;
using TicketSystem.Common.Enum;
using TicketSystem.DataAccess.Interface;
using TicketSystem.DataAccess.Model;
using TicketSystem.Service.Interface;
using TicketSystem.Service.Models;

namespace TicketSystem.Service.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public UserService(IUserRepository userRepository,
            JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
        }

        public LoginResponse UserLogin(LoginRequest request)
        {
            var result = new LoginResponse();
            var user = _userRepository.GetUser(request.Account, request.Account);
            if (user == null)
            {
                //TEST CODE
                user = new UserModel
                {
                    Id = 1,
                    Account = "test",
                    Name = "testName",
                    Role = RoleEnum.QA
                };
                //throw new Exception("No user");
            }

            var jwtToken = _jwtSettings.CreateToken(user);

            result.UserName = user.Name;
            result.JwtToken = jwtToken.Token;

            return result;
        }
    }
}