using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Common
{
    public interface ITool
    {
        MenuItemDescriptor[] MenuItems { get; }

        void RegisterServices(IServiceCollection services);
    }
}
