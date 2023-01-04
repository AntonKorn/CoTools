using CoTools.Native.User32;
using CoTools.Forms;
using System.Collections;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using CoTools.Common.Extensions;
using CoTools.Extensions;
using CoTools.Native.Extensions;
using CoTools.Modularization;
using CoTools.Common;
using CoTools.Common.DependencyInjection.Impl;
using CoTools.Modularization.Models;
using CoTools.Services;

namespace CoTools
{
    internal static class Program
    {
        private static NotifyIcon? _notifyIcon;
        private static ContextMenuStrip _trayMenu = new ContextMenuStrip();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "CoTools";
            _notifyIcon.Visible = true;
            _notifyIcon.Icon = new Icon("co_tools.ico");

            _notifyIcon.ContextMenuStrip = _trayMenu;

            Application.ApplicationExit += OnApplicationExit;

            LibUser32.EnumedWindow callBackPtr = GetWindowHandle;
            var windowHandles = new ArrayList();
            var processes = Process.GetProcesses();

            var services = new ServiceCollection();
            RegisterServices(services);

            var tools = InitializeTools(services);

            var provider = services.BuildServiceProvider();
            var context = new ControlDependencyInjectionContext(provider);

            ConfigureDefaultMenuOptions(provider);

            foreach (var tool in tools)
            {
                ConfigureToolMenuOptions(tool.Declaration, context);
            }

            var rootWindow = new RootForm(context);
            rootWindow.Hide();
            Application.Run(rootWindow);
        }

        private static void ConfigureDefaultMenuOptions(IServiceProvider provider)
        {
            _trayMenu.Items.Clear();

            _trayMenu.Items.Add("Exit", null, new EventHandler((object? sender, EventArgs e) =>
            {
                _trayMenu.Dispose();
                Application.Exit();
            }));

            var hideText = "Hide toolbar";
            var showText = "Show toolbar";
            var isHidden = false;

            _trayMenu.Items.Add("Hide toolbar", null, new EventHandler((object? sender, EventArgs e) =>
            {
                var item = sender as ToolStripItem;

                isHidden = !isHidden;
                if (item != null)
                {
                    item.Text = isHidden ? showText : hideText;

                    var toolbarService = provider.GetService<IToolbarService>()!;
                    if (isHidden)
                    {
                        toolbarService.Hide();
                    }
                    else
                    {
                        toolbarService.Show();
                    }
                }
            }));
        }

        private static void OnApplicationExit(object? sender, EventArgs e)
        {
            _notifyIcon?.Dispose();
        }

        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
        {
            windowHandles.Add(windowHandle);
            return true;
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddCommon();
            services.AddClient();
            services.AddNativeTestableWrappers();
        }

        private static ICollection<ToolMetadata> InitializeTools(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            var registry = provider.GetService<IToolRegistry>()!;
            registry.Initialize();

            foreach (var tool in registry.Tools)
            {
                tool.Declaration.RegisterServices(services);
            }

            return registry.Tools;
        }


        private static void ConfigureToolMenuOptions(ITool tool, ControlDependencyInjectionContext context)
        {
            if (!tool.MenuItems.Any())
            {
                return;
            }

            AddMenuSeparator();

            foreach (var menuItem in tool.MenuItems)
            {
                _trayMenu.Items.Add(menuItem.Name, null, new EventHandler((object? sender, EventArgs e) =>
                {
                    menuItem.Action(context);
                }));
            }
        }

        private static void AddMenuSeparator()
        {
            _trayMenu.Items.Add("-");
        }
    }
}
