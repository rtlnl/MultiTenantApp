using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MultiTenantApp.Features.RemoteIp
{
    public class RemoteIpMessageProvider : IMessageProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RemoteIpMessageProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<string> GetMessageAsync()
        {
            var remoteIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            return Task.FromResult($"Your IP Address: {remoteIpAddress}");
        }
    }
}