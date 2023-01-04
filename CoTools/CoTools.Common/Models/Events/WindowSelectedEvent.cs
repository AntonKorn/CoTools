namespace CoTools.Common.Models.Events
{
    public class WindowSelectedEvent
    {
        public WindowSelectedEvent(IntPtr handle, uint processId)
        {
            Handle = handle;
            ProcessId = processId;
        }

        public IntPtr Handle { get; }
        public uint ProcessId { get; }
    }
}
