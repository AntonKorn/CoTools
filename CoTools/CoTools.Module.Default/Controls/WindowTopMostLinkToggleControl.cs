using CoTools.Common.DependencyInjection.Impl;
using CoTools.Module.Default.Forms;
using CoTools.Module.Default.Models;
using CoTools.Module.Default.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Module.Default.Controls
{
    public partial class WindowTopMostLinkToggleControl : UserControl
    {
        private const string LINK = "Link";
        private const string UNLINK = "Unlink";

        private readonly ControlDependencyInjectionContext _context;
        private readonly ITopMostLinkService _topMostLinkService;

        public WindowTopMostLinkToggleControl(ControlDependencyInjectionContext context)
        {
            InitializeComponent();

            _context = context;
            _topMostLinkService = _context.ServiceProvider.GetRequiredService<ITopMostLinkService>();

            UpdateButtonEnabled();

            _topMostLinkService.IsLinkedChanged += OnIsLinkedChanged;
            _topMostLinkService.WindowLinkRequested += OnWindowLinkRequested;
        }

        private void OnWindowLinkRequested(IntPtr hWnd)
        {
            var form = _context.Create<TopMostLinkForm>()!;
            form.Initialize(hWnd);
            form.Show();
        }

        private void OnIsLinkedChanged()
        {
            UpdateButtonEnabled();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            _topMostLinkService.Toggle();
        }

        private void UpdateButtonEnabled()
        {
            var isChecked = _topMostLinkService.IsLinked;

            btnToggle.Text = !isChecked ? LINK : UNLINK;
        }
    }
}
