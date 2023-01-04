using CoTools.Common.Models.Events;

namespace CoTools.Common.Services.Impl
{
    internal class EventService : IEventService
    {
        public event Action<WindowSelectedEvent>? WindowSelected;

        public void RaiseWindowSelected(WindowSelectedEvent e)
        {
            WindowSelected?.Invoke(e);
        }
    }
}
