namespace CoTools.Services
{
    public interface IToolbarService : IDisposable
    {
        public event Action? LocationChanged;
        event Action? BecameVisible;

        public Point Location { get; }

        public void Drag(int deltaX, int deltaY);

        public void StopDrag();
    }
}
