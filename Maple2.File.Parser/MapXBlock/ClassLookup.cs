using System.Reflection;
using System.Text.RegularExpressions;
using Maple2.File.Flat;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock;

public abstract class ClassLookup {
    private static readonly Dictionary<string, Type> typeIndex = new Dictionary<string, Type>();

    private readonly Dictionary<(string, string), MethodInfo> methodCache =
        new Dictionary<(string, string), MethodInfo>();
    private readonly Dictionary<(string, string), FieldInfo> fieldCache =
        new Dictionary<(string, string), FieldInfo>();
    private readonly Dictionary<string, Type> mixinTypeCache = new Dictionary<string, Type>();
    protected readonly FlatTypeIndex index;

    static ClassLookup() {
        foreach (Type type in Assembly.GetAssembly(typeof(IMapEntity)).GetTypes()) {
            typeIndex[type.Name] = type;
        }
    }

    protected ClassLookup(FlatTypeIndex index) {
        this.index = index;

        foreach (Type type in Assembly.GetAssembly(typeof(IMapEntity)).GetTypes()) {
            foreach (MethodInfo method in type.GetMethods()) {
                methodCache[(type.Name, method.Name)] = method;
            }
            foreach (Type @interface in type.GetInterfaces()) {
                foreach (MethodInfo method in @interface.GetMethods()) {
                    methodCache[(type.Name, method.Name)] = method;
                }
            }
        }
    }

    public Type GetMixinType(string modelName) {
        if (mixinTypeCache.TryGetValue(modelName, out Type mixinType)) {
            return mixinType;
        }

        FlatType entityType = index.GetType(modelName);
        if (entityType == null) {
            throw new UnknownModelTypeException(modelName);
        }
        // First try to directly lookup type as a library type
        mixinType = GetType($"I{modelName}");
        if (mixinType != null) {
            mixinTypeCache[modelName] = mixinType;
            return mixinType;
        }

        List<FlatType> requiredMixins = entityType.RequiredMixin().ToList();
        if (requiredMixins.Count != 1) {
            throw new InvalidOperationException($"Cannot find single mixin for: {entityType}");
        }

        FlatType requiredMixin = requiredMixins.First();
        mixinType = GetType($"I{requiredMixin.Name}");
        if (mixinType == null) {
            throw new UnknownModelTypeException($"I{requiredMixin.Name}");
        }

        mixinTypeCache[modelName] = mixinType;
        return mixinType;
    }

    public abstract Type GetClass(string modelName);

    public static Type GetType(string name) => typeIndex.GetValueOrDefault(name);

    public MethodInfo GetMethod(Type type, string name) => methodCache.GetValueOrDefault((type.Name, name));

    public FieldInfo GetField(Type type, string name) => fieldCache.GetValueOrDefault((type.Name, name));

    protected void IndexType(Type type) {
        foreach (MethodInfo method in type.GetMethods()) {
            if (!method.Name.StartsWith("get_")) {
                continue;
            }
            methodCache[(type.Name, method.Name)] = method;
        }
        foreach (FieldInfo field in type.GetFields()) {
            fieldCache[(type.Name, field.Name)] = field;
        }
    }

    public static string NormalizeClass(string className) {
        className = className.Replace("(", "").Replace(")", "").Replace(" ", "");
        if (Regex.IsMatch(className, @"^\d")) {
            className = $"_{className}";
        }

        return className;
    }
}
