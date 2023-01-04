using Microsoft.Extensions.DependencyInjection;

namespace CoTools.Common.DependencyInjection.Impl
{
    public class ControlDependencyInjectionContext : IControlDependencyInjectionContext
    {
        private readonly IServiceScope _scope;

        public IServiceProvider ServiceProvider => _scope.ServiceProvider;

        public ControlDependencyInjectionContext(IServiceProvider parentProvider)
        {
            _scope = parentProvider.CreateScope();
        }

        public IControlDependencyInjectionContext CreateChild()
        {
            return new ControlDependencyInjectionContext(_scope.ServiceProvider);
        }

        public T? Create<T>()
            where T : class
        {
            return CreateInternal(typeof(T)) as T;
        }

        public bool CanCreate(Type controlType)
        {
            return HasFittingConstructor(controlType);
        }

        public object? Create(Type controlType)
        {
            return CreateInternal(controlType);
        }

        public void Dispose()
        {
            _scope.Dispose();
        }

        private object? CreateInternal(Type t)
        {
            if (!HasFittingConstructor(t))
            {
                return null;
            }

            return Activator.CreateInstance(t, CreateChild());
        }

        private bool HasFittingConstructor(Type t)
        {
            var constructors = t.GetConstructors();
            return constructors
                .Where(c =>
                {
                    var parameters = c.GetParameters();
                    return parameters.Length == 1 && typeof(IControlDependencyInjectionContext).IsAssignableFrom(parameters[0].ParameterType);
                })
                .Any();
        }
    }
}
