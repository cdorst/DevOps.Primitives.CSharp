using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    public class EnumDeclaration : TypeDeclaration
    {
        [ProtoMember(28)]
        public EnumMemberList EnumMemberList { get; set; }
        [ProtoMember(29)]
        public int EnumMemberListId { get; set; }

        protected override BaseTypeDeclarationSyntax GetTypeDeclarationSyntax()
        {
            var hasAttributes = AttributeListCollection != null;
            var hasModifiers = ModifierList != null;
            var declaration = EnumDeclaration(
                Identifier.GetSyntaxToken((!hasAttributes && !hasModifiers) ? DocumentationCommentList : null));
            if (hasAttributes)
            {
                declaration = declaration.WithAttributeLists(
                    AttributeListCollection.GetAttributeListSyntaxList(DocumentationCommentList));
            }
            if (hasModifiers)
            {
                declaration = declaration.WithModifiers(
                    ModifierList.GetSyntaxTokenList(hasAttributes ? null : DocumentationCommentList));
            }
            if (BaseList != null)
            {
                declaration = declaration.WithBaseList(
                    BaseList.GetBaseListSyntax());
            }
            return declaration.WithMembers(
                EnumMemberList.GetEnumMembers());
        }
    }
}
