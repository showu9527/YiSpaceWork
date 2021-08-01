namespace TicketSystem.Service.Models
{
    public class JwtToken
    {
        public JwtToken(string sessionId, string token)
        {
            SessionId = sessionId;
            Token = token;
        }

        public string SessionId { get; }

        public string Token { get; }
    }
}