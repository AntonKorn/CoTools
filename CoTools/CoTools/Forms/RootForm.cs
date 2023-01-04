using CoTools.Common.DependencyInjection;
using CoTools.Common.Models.Events;
using CoTools.Common.Services;
using CoTools.Modularization;
using CoTools.Native.User32;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace CoTools.Forms
{
    public partial class RootForm : Form
    {
        private readonly IControlDependencyInjectionContext _dependencyInjectionContext;
        private ToolbarForm _toolbarForm;
        private IntPtr? _activeWindow;
        private IEventService _eventService;

        public RootForm(IControlDependencyInjectionContext dependencyInjectionContext)
        {
            InitializeComponent();
            HideForm();

            _dependencyInjectionContext = dependencyInjectionContext;
            _toolbarForm = dependencyInjectionContext.Create<ToolbarForm>()!;
            _eventService = _dependencyInjectionContext.ServiceProvider.GetService<IEventService>()!;
        }

        private void tmrActiveWindowUpdate_Tick(object sender, EventArgs e)
        {
            var hWnd = LibUser32.GetForegroundWindow();
            if (hWnd != Handle && hWnd != _activeWindow && hWnd != _toolbarForm.Handle)
            {
                LibUser32.GetWindowThreadProcessId(hWnd, out var processId);

                if (processId != Process.GetCurrentProcess().Id)
                {
                    _activeWindow = hWnd;
                    _eventService.RaiseWindowSelected(new WindowSelectedEvent(hWnd, processId));
                }
            }
        }

        private void HideForm()
        {
            Opacity = 0;
        }
    }
}
