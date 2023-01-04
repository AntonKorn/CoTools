using CoTools.Common.DependencyInjection.Impl;
using CoTools.Module.Default.Services;
using CoTools.Native.User32;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace CoTools.Module.Default.Forms
{
    public partial class TopMostLinkForm : Form
    {
        private readonly ControlDependencyInjectionContext _context;
        private readonly ITopMostLinkService _service;

        private Bitmap? _image;
        private IntPtr _hWnd;

        public TopMostLinkForm(ControlDependencyInjectionContext context)
        {
            InitializeComponent();
            _context = context;

            _service = _context.ServiceProvider.GetService<ITopMostLinkService>()!;
            _service.Unlinked += OnUnlinked;
        }

        private void OnUnlinked(IntPtr hWnd)
        {
            if (_hWnd == hWnd)
            {
                Close();
            }
        }

        public void Initialize(IntPtr hWnd)
        {
            _hWnd = hWnd;
            tmrRefreshImage.Enabled = true;
        }

        private void tmrRefreshImage_Tick(object sender, EventArgs e)
        {
            EnsureImageSized();

            using (var graphics = Graphics.FromImage(_image!))
            {
                var hDc = graphics.GetHdc();

                LibUser32.PrintWindow(new HandleRef(graphics, _hWnd), hDc, 1 | 0x00000002);

                graphics.ReleaseHdc(hDc);
            }

            pbCanvas.Invalidate();
        }

        private void pbCanvas_DoubleClick(object sender, EventArgs e)
        {
            LibUser32.SetForegroundWindow(_hWnd);
        }

        private void EnsureImageSized()
        {
            LibUser32.GetWindowRect(_hWnd, out var rect);

            if (_image == null
                || _image.Width != rect.Width
                || _image.Height != rect.Height)
            {
                _image?.Dispose();

                _image = new Bitmap(rect.Width, rect.Height);
                pbCanvas.Image = _image;
            }
        }
    }
}
