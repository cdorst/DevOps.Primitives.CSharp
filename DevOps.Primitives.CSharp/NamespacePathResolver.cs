using System.IO;
using System.Linq;

namespace DevOps.Primitives.CSharp
{
    public static class NamespacePathResolver
    {
        public static string GetPath(string projectNamespace, string typeDeclarationNamespace)
            => Path.Combine(typeDeclarationNamespace.Split('.')
                .Skip(projectNamespace.Split('.').Count())
                .ToArray());
    }
}
