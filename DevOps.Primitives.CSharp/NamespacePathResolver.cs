using System.Linq;
using static System.IO.Path;

namespace DevOps.Primitives.CSharp
{
    public static class NamespacePathResolver
    {
        private const char Dot = '.';

        public static string GetPath(in string projectNamespace, in string typeDeclarationNamespace)
            => Combine(typeDeclarationNamespace.Split(Dot)
                .Skip(projectNamespace.Split(Dot).Count())
                .ToArray());
    }
}
