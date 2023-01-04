using CoTools.Native.User32.Types;
using static CoTools.Native.User32.LibUser32;

namespace CoTools.Native.User32.Wrappers
{
    public interface ILibUser32
    {
        IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        bool UnhookWinEvent(IntPtr hWinEventHook);

        bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
    }
}
