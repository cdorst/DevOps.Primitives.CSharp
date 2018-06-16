using Microsoft.CodeAnalysis.CSharp;
using static DevOps.Primitives.CSharp.ModifierLists;

namespace DevOps.Primitives.CSharp
{
    public static class AccessorLists
    {
        private static readonly SyntaxKind _get = SyntaxKind.GetAccessorDeclaration;
        private static readonly SyntaxKind _set = SyntaxKind.SetAccessorDeclaration;

        public static readonly AccessorList AutoGet = new AccessorList(in _get);

        public static readonly AccessorList AutoGetSet = new AccessorList(
            new AccessorListAssociation(in _get),
            new AccessorListAssociation(in _set));

        public static AccessorList GetPrivateSet(in Block getBlock, in Block setBlock)
            => new AccessorList(
                new AccessorListAssociation(new Accessor(in _get, in getBlock)),
                new AccessorListAssociation(new Accessor(in _set, in setBlock, Private)));

        public static AccessorList GetPrivateSet(in Block getBlock, in Expression setExpression)
            => new AccessorList(
                new AccessorListAssociation(new Accessor(in _get, in getBlock)),
                new AccessorListAssociation(new Accessor(in _set, in setExpression, Private)));

        public static AccessorList GetPrivateSet(in Expression getExpression, in Expression setExpression)
            => new AccessorList(
                new AccessorListAssociation(new Accessor(in _get, in getExpression)),
                new AccessorListAssociation(new Accessor(in _set, in setExpression, Private)));
    }
}
