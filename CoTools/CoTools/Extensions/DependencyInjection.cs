using CoTools.Modularization;
using CoTools.Services;
using CoTools.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Extensions
{
    public static class DependencyInjection
    {
        public static void AddClient(this IServiceCollection services)
        {
            services.AddScoped<IToolbarService, ToolbarService>();
            services.AddSingleton<IToolRegistry>(new ToolRegistry());
        }
    }
}
