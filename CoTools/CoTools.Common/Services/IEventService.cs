using CoTools.Common.Models.Events;

namespace CoTools.Common.Services
{
    public interface IEventService
    {
        public event Action<WindowSelectedEvent>? WindowSelected;

        public void RaiseWindowSelected(WindowSelectedEvent e);
    }
}
