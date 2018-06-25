using System.Threading.Tasks;

namespace MultiTenantApp
{
    public interface IMessageProvider
    {
        Task<string> GetMessageAsync();
    }
}