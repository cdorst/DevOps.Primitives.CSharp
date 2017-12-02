using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DevOps.Primitives.CSharp
{
    public interface ISortableMemberDeclaration
    {
        ModifierList ModifierList { get; set; }
        Identifier Identifier { get; set; }
        MemberDeclarationSyntax GetMemberDeclarationSyntax();
    }
}
