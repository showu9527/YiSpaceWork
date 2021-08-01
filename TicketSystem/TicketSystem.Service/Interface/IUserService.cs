using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.Service.Models;

namespace TicketSystem.Service.Interface
{
    public interface IUserService
    {
        LoginResponse UserLogin(LoginRequest request);
    }
}
