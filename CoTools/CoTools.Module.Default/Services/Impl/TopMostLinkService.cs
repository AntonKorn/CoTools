using CoTools.Common.Models.Events;
using CoTools.Common.Services;
using CoTools.Module.Default.Models;

namespace CoTools.Module.Default.Services.Impl
{
    public class TopMostLinkService : ITopMostLinkService
    {
        private readonly IWindowStateService _windowStateService;
        private readonly IEventService _eventService;

        private TopMostLinkState? _state;
        private IntPtr _hWnd;

        public bool IsLinked { get; private set; }

        public event Action<IntPtr>? Unlinked;
        public event Action? IsLinkedChanged;
        public event Action<IntPtr>? WindowLinkRequested;

        public TopMostLinkService(
            IWindowStateService windowStateService,
            IEventService eventService)
        {
            _windowStateService = windowStateService;
            _eventService = eventService;

            _eventService.WindowSelected += OnWindowSelected;
        }

        private void OnWindowSelected(WindowSelectedEvent e)
        {
            _hWnd = e.Handle;

            _state = _windowStateService.Read(_hWnd, StateEntryKinds.TopMostLinkState);
            UpdateProperties();
        }

        public void Toggle()
        {
            if (_state == null)
            {
                _state = new TopMostLinkState();
            }

            _state.Enabled = !_state.Enabled;
            SaveState();

            UpdateProperties();

            if (_state.Enabled)
            {
                WindowLinkRequested?.Invoke(_hWnd);
            }
            else
            {
                Unlinked?.Invoke(_hWnd);
            }
        }

        public void UnlinkAfterClose(IntPtr hWnd)
        {
            if (_state == null)
            {
                return;
            }

            _state.Enabled = false;
            SaveState();

            UpdateProperties();
        }

        public void Dispose()
        {
            _eventService.WindowSelected -= OnWindowSelected;
        }

        private void SaveState()
        {
            _windowStateService.Update(_hWnd, StateEntryKinds.TopMostLinkState, _state);
        }

        private void UpdateProperties()
        {
            var isLinked = _state?.Enabled ?? false;
            var hasChanged = isLinked != IsLinked;

            if (hasChanged)
            {
                IsLinked = isLinked;
                IsLinkedChanged?.Invoke();
            }
        }
    }
}
