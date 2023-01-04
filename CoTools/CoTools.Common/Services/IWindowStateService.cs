using CoTools.Common.Models;

namespace CoTools.Common.Services
{
    public interface IWindowStateService
    {
        bool TryRead<T>(IntPtr handle, StateEntryKind<T> entryKind, out T? value);

        T? Read<T>(IntPtr handle, StateEntryKind<T> entryKind);

        void Update<T>(IntPtr handle, StateEntryKind<T> entryKind, T? value);
    }
}
