using CoTools.Modularization.Models;

namespace CoTools.Modularization
{
    public interface IToolRegistry
    {
        ICollection<ToolMetadata> Tools { get; }

        void Initialize();
    }
}
