namespace CoTools.Common.DependencyInjection
{
    public interface IControlDependencyInjectionContext : IDisposable
    {
        IServiceProvider ServiceProvider { get; }

        IControlDependencyInjectionContext CreateChild();

        bool CanCreate(Type controlType);

        object? Create(Type controlType);

        T? Create<T>()
            where T : class;
    }
}
