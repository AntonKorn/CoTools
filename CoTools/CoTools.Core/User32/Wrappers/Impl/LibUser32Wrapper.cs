using CoTools.Native.User32.Types;

namespace CoTools.Native.User32.Wrappers.Impl
{
    public class LibUser32Wrapper : ILibUser32
    {
        public bool GetWindowRect(IntPtr hWnd, out Rect lpRect)
        {
            return LibUser32.GetWindowRect(hWnd, out lpRect);
        }

        public IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, User32.LibUser32.WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags)
        {
            return LibUser32.SetWinEventHook(eventMin, eventMax, hmodWinEventProc, lpfnWinEventProc, idProcess, idThread, dwFlags);
        }

        public bool UnhookWinEvent(IntPtr hWinEventHook)
        {
            return LibUser32.UnhookWinEvent(hWinEventHook);
        }
    }
}
