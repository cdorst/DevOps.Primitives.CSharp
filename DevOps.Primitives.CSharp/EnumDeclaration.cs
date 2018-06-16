using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    public class EnumDeclaration : TypeDeclaration
    {
        public EnumDeclaration() { }
        public EnumDeclaration(
            in Identifier identifier,
            in Namespace @namespace,
            in ModifierList modifierList = default,
            in UsingDirectiveList usingDirectiveList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in TypeParameterList typeParameterList = default,
            in ConstraintClauseList constraintClauseList = default,
            in BaseList baseList = default,
            in ConstructorList constructorList = default,
            in FieldList fieldList = default,
            in MethodList methodList = default,
            in PropertyList propertyList = default,
            in EnumMemberList enumMemberList = default)
            : base(
                  in identifier,
                  in @namespace,
                  in modifierList,
                  in usingDirectiveList,
                  in documentationCommentList,
                  in attributeListCollection,
                  in typeParameterList,
                  in constraintClauseList,
                  in baseList,
                  in constructorList,
                  in fieldList,
                  in methodList,
                  in propertyList)
        {
            EnumMemberList = enumMemberList;
        }
        public EnumDeclaration(
            in string identifier,
            in string @namespace,
            in ModifierList modifierList = default,
            in UsingDirectiveList usingDirectiveList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in TypeParameterList typeParameterList = default,
            in ConstraintClauseList constraintClauseList = default,
            in BaseList baseList = default,
            in ConstructorList constructorList = default,
            in FieldList fieldList = default,
            in MethodList methodList = default,
            in PropertyList propertyList = default,
            in EnumMemberList enumMemberList = default)
            : this(
                  new Identifier(in identifier),
                  new Namespace(in @namespace),
                  in modifierList,
                  in usingDirectiveList,
                  in documentationCommentList,
                  in attributeListCollection,
                  in typeParameterList,
                  in constraintClauseList,
                  in baseList,
                  in constructorList,
                  in fieldList,
                  in methodList,
                  in propertyList,
                  in enumMemberList)
        {
        }

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
