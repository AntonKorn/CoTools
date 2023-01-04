namespace CoTools.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ToolAttribute : Attribute
    {
        public string ToolId { get; }

        public string Name { get; }

        public string Description { get; }

        public Type ToggleComponentType { get; }

        public ToolAttribute(string toolId, string name, string description, Type toggleComponentType)
        {
            ToolId = toolId;
            ToggleComponentType = toggleComponentType;
            Name = name;
            Description = description;
        }
    }
}
