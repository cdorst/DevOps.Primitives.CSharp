using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp
{
    public static class AccessorLists
    {
        public static AccessorList AutoGet => new AccessorList(SyntaxKind.GetAccessorDeclaration);
        public static AccessorList AutoGetSet => new AccessorList(new List<AccessorListAssociation>
        {
            new AccessorListAssociation(SyntaxKind.GetAccessorDeclaration),
            new AccessorListAssociation(SyntaxKind.SetAccessorDeclaration)
        });
        public static AccessorList GetPrivateSet(Block getBlock, Block setBlock) => new AccessorList(new List<AccessorListAssociation>
        {
            new AccessorListAssociation(new Accessor(SyntaxKind.GetAccessorDeclaration, getBlock)),
            new AccessorListAssociation(new Accessor(SyntaxKind.SetAccessorDeclaration, setBlock, ModifierLists.Private))
        });
        public static AccessorList GetPrivateSet(Block getBlock, Expression setExpression) => new AccessorList(new List<AccessorListAssociation>
        {
            new AccessorListAssociation(new Accessor(SyntaxKind.GetAccessorDeclaration, getBlock)),
            new AccessorListAssociation(new Accessor(SyntaxKind.SetAccessorDeclaration, setExpression, ModifierLists.Private))
        });
        public static AccessorList GetPrivateSet(Expression getExpression, Expression setExpression) => new AccessorList(new List<AccessorListAssociation>
        {
            new AccessorListAssociation(new Accessor(SyntaxKind.GetAccessorDeclaration, getExpression)),
            new AccessorListAssociation(new Accessor(SyntaxKind.SetAccessorDeclaration, setExpression, ModifierLists.Private))
        });
    }
}
