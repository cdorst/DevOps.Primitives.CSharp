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
    }
}
