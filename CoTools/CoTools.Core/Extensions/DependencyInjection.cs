using CoTools.Native.User32.Wrappers;
using CoTools.Native.User32.Wrappers.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Native.Extensions
{
    public static class DependencyInjection
    {
        public static void AddNativeTestableWrappers(this IServiceCollection services)
        {
            services.AddSingleton<ILibUser32, LibUser32Wrapper>();
        }
    }
}
