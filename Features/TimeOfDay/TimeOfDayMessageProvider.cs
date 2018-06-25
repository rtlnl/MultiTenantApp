using System.Threading.Tasks;
using OrchardCore.Modules;

namespace MultiTenantApp.Features.TimeOfDay
{
    public class TimeOfDayMessageProvider : IMessageProvider
    {
        private readonly IClock _clock;

        public TimeOfDayMessageProvider(IClock clock)
        {
            _clock = clock;
        }

        public Task<string> GetMessageAsync()
        {
            return Task.FromResult($"The current time is: {_clock.UtcNow.ToLocalTime().TimeOfDay}");
        }
    }
}
