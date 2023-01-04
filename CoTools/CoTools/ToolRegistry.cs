using CoTools.Modularization;

namespace CoTools
{
    public class ToolRegistry : ToolRegistryBase
    {
        public override void Initialize()
        {
            DiscoverAssembliesInLocalFolder();
        }
    }
}
