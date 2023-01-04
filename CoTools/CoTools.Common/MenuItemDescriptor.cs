using CoTools.Common.DependencyInjection;

namespace CoTools.Common
{
    public class MenuItemDescriptor
    {
        public string Name { get; }

        public Action<IControlDependencyInjectionContext> Action { get; }

        public MenuItemDescriptor(string name, Action<IControlDependencyInjectionContext> action)
        {
            Name = name;
            Action = action;
        }
    }
}
