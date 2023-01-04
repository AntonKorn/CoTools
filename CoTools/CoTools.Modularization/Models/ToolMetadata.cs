using CoTools.Common;

namespace CoTools.Modularization.Models
{
    public class ToolMetadata
    {
        public string Id { get; }

        public string Name { get; }

        public string Description { get; }

        public Type ToggleControlType { get; }

        public MenuItemDescriptor[] MenuItems { get; }

        public ITool Declaration { get; }

        public string SourceAssembly { get; }

        public ToolMetadata(string id, string name, string description,  Type toggleControlType, MenuItemDescriptor[] menuItems, ITool declaration, string sourceAssembly)
        {
            Id = id;
            ToggleControlType = toggleControlType;
            MenuItems = menuItems;
            Declaration = declaration;
            SourceAssembly = sourceAssembly;
            Name = name;
            Description = description;
        }
    }
}
