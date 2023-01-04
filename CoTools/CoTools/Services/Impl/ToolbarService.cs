using CoTools.Common.Models.Events;
using CoTools.Common.Services;
using CoTools.Native.User32;
using CoTools.Native.User32.Constants;
using CoTools.Native.User32.Wrappers;

namespace CoTools.Services.Impl
{
    public class ToolbarService : IToolbarService
    {
        private readonly IEventService _eventService;
        private readonly IWindowStateService _windowStateService;
        private readonly ILibUser32 _libUser32;
        private readonly LibUser32.WinEventDelegate _eventDelegate;

        private IntPtr? _windowHook;
        private IntPtr _chasedWindow;

        private Point _offset;

        public Point Location { get; private set; }

        public event Action? LocationChanged;
        public event Action? BecameVisible;
        public event Action? BecameInvisible;

        private bool _isForcedInvisible;

        public ToolbarService(
            IEventService eventService,
            IWindowStateService windowStateService,
            ILibUser32 libUser32)
        {
            _eventService = eventService;
            _windowStateService = windowStateService;
            _libUser32 = libUser32;

            _eventDelegate = new LibUser32.WinEventDelegate(ProcessWindowEvent);

            _eventService.WindowSelected += OnWindowSelected;
        }

        private void OnWindowSelected(WindowSelectedEvent e)
        {
            if (_windowHook.HasValue)
            {
                _libUser32.UnhookWinEvent(_windowHook.Value);
            }
            else if (!_isForcedInvisible)
            {
                BecameVisible?.Invoke();
            }

            _chasedWindow = e.Handle;

            if (!_windowStateService.TryRead(e.Handle, StateEntryKinds.ToolbarOffset, out _offset))
            {
                _offset = new Point(10, 10);
            }

            UpdatePosition();

            _windowHook = _libUser32.SetWinEventHook(
                Event.MIN,
                Event.MAX,
                IntPtr.Zero,
                _eventDelegate,
                e.ProcessId,
                0,
                WinEvent.OUTOFCONTEXT | WinEvent.SKIPOWNPROCESS);
        }

        public void Drag(int deltaX, int deltaY)
        {
            _offset = new Point(_offset.X + deltaX, _offset.Y + deltaY);
        }

        public void StopDrag()
        {
            _windowStateService.Update(_chasedWindow, StateEntryKinds.ToolbarOffset, _offset);
        }

        public void Show()
        {
            _isForcedInvisible = false;

            var isListeningForWindow = _windowHook.HasValue;
            if (isListeningForWindow)
            {
                BecameVisible?.Invoke();
            }
        }

        public void Hide()
        {
            _isForcedInvisible = true;
            BecameInvisible?.Invoke();
        }

        public void Dispose()
        {
            _eventService.WindowSelected -= OnWindowSelected;
        }

        private void ProcessWindowEvent(
            IntPtr hWinEventHook,
            uint eventType,
            IntPtr hwnd,
            int idObject,
            int idChild,
            uint dwEventThread,
            uint dwmsEventTime)
        {
            if (eventType == Event.OBJECT_LOCATIONCHANGE
                && hwnd == _chasedWindow)
            {
                UpdatePosition();
            }
        }

        private void UpdatePosition()
        {
            _libUser32.GetWindowRect(_chasedWindow, out var rect);

            Location = new Point(rect.X + _offset.X, rect.Y + _offset.Y);
            LocationChanged?.Invoke();
        }
    }
}
