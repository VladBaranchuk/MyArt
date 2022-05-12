using Microsoft.AspNetCore.SignalR;

namespace MyArt.API.Infrastructure.Configurations
{
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name;
        }
    }
}
