using CoTools.Common;
using CoTools.Common.Attributes;
using CoTools.Module.Default.Controls;
using CoTools.Module.Default.Services;
using CoTools.Module.Default.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Module.Default.Tools
{
    [Tool(
        "0066419c-5002-4637-b314-c040132e5d7d",
        "Window Top Most link",
        "Makes top most window shortcut",
        typeof(WindowTopMostLinkToggleControl))]
    public class WindowTopMostLinkTool : ITool
    {
        public MenuItemDescriptor[] MenuItems => new MenuItemDescriptor[0];

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ITopMostLinkService, TopMostLinkService>();
        }
    }
}
