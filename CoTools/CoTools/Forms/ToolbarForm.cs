using CoTools.Common.DependencyInjection;
using CoTools.Modularization;
using CoTools.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Forms
{
    public partial class ToolbarForm : Form
    {
        private const string COLLAPSE_TEXT = "❮";
        private const string EXPAND_TEXT = "❯";
        private readonly IControlDependencyInjectionContext _dependencyInjectionContext;
        private readonly IToolbarService _toolbarService;
        private readonly IToolRegistry _toolRegistry;

        private Point _lastLocation = new Point(0, 0);

        private bool _isInCustomDrag;

        public ToolbarForm(IControlDependencyInjectionContext dependencyInjectionContext)
        {
            InitializeComponent();

            UpdateCollapseButtonText();
            _dependencyInjectionContext = dependencyInjectionContext;

            _toolbarService = _dependencyInjectionContext.ServiceProvider.GetService<IToolbarService>()!;
            _toolbarService.LocationChanged += OnLocationChanged;
            _toolbarService.BecameVisible += OnBecameVisible;
            _toolbarService.BecameInvisible += OnBecameInvisible;

            _toolRegistry = _dependencyInjectionContext.ServiceProvider.GetService<IToolRegistry>()!;

            RefreshTools();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            if (!IsCollapsed())
            {
                flpToolbox.AutoSize = false;
                flpToolbox.Width = 0;
            }
            else
            {
                flpToolbox.AutoSize = true;
            }
        }

        private void pnlPositionManagement_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isInCustomDrag = true;
                _lastLocation = e.Location;
            }
        }

        private void pnlPositionManagement_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isInCustomDrag)
            {
                var deltaX = e.X - _lastLocation.X;
                var deltaY = e.Y - _lastLocation.Y;

                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
                _toolbarService.Drag(deltaX, deltaY);

                Update();
            }
        }

        private void pnlPositionManagement_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _toolbarService.StopDrag();
                _isInCustomDrag = false;
            }
        }

        private void RefreshTools()
        {
            foreach (var tool in _toolRegistry.Tools)
            {
                var toolControl = _dependencyInjectionContext.CanCreate(tool.ToggleControlType)
                    ? _dependencyInjectionContext.Create(tool.ToggleControlType)
                    : Activator.CreateInstance(tool.ToggleControlType);

                flpToolbox.Controls.Add(toolControl as Control);
                flpToolbox.ResumeLayout(false);
            }
        }

        private void OnBecameVisible()
        {
            Show();
        }

        private void OnBecameInvisible()
        {
            Hide();
        }

        private void OnLocationChanged()
        {
            Location = _toolbarService.Location;
        }

        private void UpdateCollapseButtonText()
        {
            btnCollapse.Text = IsCollapsed() ? EXPAND_TEXT : COLLAPSE_TEXT;
        }

        private bool IsCollapsed()
        {
            return !flpToolbox.AutoSize;
        }
    }
}
