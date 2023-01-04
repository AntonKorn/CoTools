using CoTools.Common;
using CoTools.Common.Attributes;
using CoTools.Common.Exceptions;
using CoTools.Modularization.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace CoTools.Modularization
{
    public abstract class ToolRegistryBase : IToolRegistry
    {
        private IList<ToolMetadata> _tools = new List<ToolMetadata>();

        public ICollection<ToolMetadata> Tools => _tools;

        public abstract void Initialize();

        protected void DiscoverAssembliesInLocalFolder()
        {
            var loadedAssemblies = GetLoadedModuleAssemblies();
            var toolTypes = loadedAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(ITool).IsAssignableFrom(t))
                .ToList();

            foreach (var toolType in toolTypes)
            {
                var hasParameterlessPublicCtor = toolType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, Type.EmptyTypes) != null;
                if (!hasParameterlessPublicCtor)
                {
                    ThrowToolModuleValidationException(toolType, "Must have default parameterless constructor");
                }

                var tool = Activator.CreateInstance(toolType);
                AddInternal((ITool)tool!);
            }
        }

        protected void Add(ITool tool)
        {
            AddInternal(tool);
        }

        private IEnumerable<Assembly> GetLoadedModuleAssemblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            EnsureAllModuleAssembliesLoaded(loadedAssemblies);
            return loadedAssemblies.Where(a => a.FullName?.StartsWith("CoTools.Module") ?? false);
        }

        private void EnsureAllModuleAssembliesLoaded(List<Assembly> loadedAssemblies)
        {
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();
            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "CoTools.Module.*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        }

        private void AddInternal(ITool tool)
        {
            var attribute = GetAttribute(tool);

            if (attribute == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(attribute.ToolId)
                || attribute.ToggleComponentType == null)
            {
                ThrowToolModuleValidationException(tool.GetType(), "Id and toggle type are required to register the tool");
            }

            if (_tools.Where(t => t.GetType() == tool.GetType()).Any())
            {
                ThrowToolModuleValidationException(tool.GetType(), $"Can't register tool with duplicate type");
            }

            if (_tools.Where(t => t.Id == attribute.ToolId).Any())
            {
                ThrowToolModuleValidationException(tool.GetType(), $"Can't register tool with duplicate id: {attribute.ToolId}");
            }

            var metadata = new ToolMetadata(
                attribute.ToolId,
                attribute.Name,
                attribute.Description,
                attribute.ToggleComponentType,
                tool.MenuItems ?? new MenuItemDescriptor[0],
                tool,
                tool.GetType().Assembly.FullName!);

            _tools.Add(metadata);
        }

        private ToolAttribute? GetAttribute(ITool tool)
        {
            var type = tool.GetType();
            return type.GetCustomAttribute<ToolAttribute>();
        }

        [DoesNotReturn]
        private void ThrowToolModuleValidationException(Type toolType, string reason)
        {
            var assemblyName = toolType.Assembly.FullName;
            throw new CoToolsException($"Unable to register tool of type {toolType.FullName}, {assemblyName}, {reason}");
        }
    }
}
