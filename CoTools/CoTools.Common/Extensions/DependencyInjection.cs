using CoTools.Common.Services;
using CoTools.Common.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Common.Extensions
{
    public static class DependencyInjection
    {
        public static void AddCommon(this IServiceCollection services)
        {
            services.AddSingleton<IEventService, EventService>();
            services.AddSingleton<IWindowStateService, WindowStateService>();
        }
    }
}
