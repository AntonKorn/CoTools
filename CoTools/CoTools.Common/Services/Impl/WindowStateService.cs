using CoTools.Common.Models;

namespace CoTools.Common.Services.Impl
{
    internal class WindowStateService : IWindowStateService
    {
        private readonly Dictionary<IntPtr, Dictionary<string, object>> _windowStates = new();

        public bool TryRead<T>(IntPtr handle, StateEntryKind<T> entryKind, out T? value)
        {
            value = default(T);

            if (_windowStates.TryGetValue(handle, out var state))
            {
                if (state.TryGetValue(entryKind.Id, out var stateValue))
                {
                    value = (T)stateValue;
                    return true;
                }
            }

            return false;
        }

        public T? Read<T>(IntPtr handle, StateEntryKind<T> entryKind)
        {
            if (_windowStates.TryGetValue(handle, out var state))
            {
                if (state.TryGetValue(entryKind.Id, out var stateValue))
                {
                    return (T)stateValue;
                }
            }

            return default(T);
        }

        public void Update<T>(IntPtr handle, StateEntryKind<T> entryKind, T? value)
        {
            if (!_windowStates.TryGetValue(handle, out var state))
            {
                state = new Dictionary<string, object>();
                _windowStates[handle] = state;
            }

            state[entryKind.Id] = value!;
        }
    }
}
