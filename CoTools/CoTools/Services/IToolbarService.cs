namespace CoTools.Services
{
    public interface IToolbarService : IDisposable
    {
        event Action? LocationChanged;
        event Action? BecameVisible;
        event Action? BecameInvisible;

        Point Location { get; }

        void Drag(int deltaX, int deltaY);

        void StopDrag();

        void Show();

        void Hide();
    }
}
