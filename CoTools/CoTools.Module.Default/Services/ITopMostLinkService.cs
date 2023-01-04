namespace CoTools.Module.Default.Services
{
    public interface ITopMostLinkService : IDisposable
    {
        bool IsLinked { get; }

        event Action<IntPtr>? Unlinked;
        event Action? IsLinkedChanged;
        event Action<IntPtr> WindowLinkRequested;

        void Toggle();

        void UnlinkAfterClose(IntPtr hWnd);
    }
}
