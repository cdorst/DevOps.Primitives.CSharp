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
            Identifier identifier,
            Namespace @namespace,
            ModifierList modifierList = null,
            UsingDirectiveList usingDirectiveList = null,
            DocumentationCommentList documentationCommentList = null,
            AttributeListCollection attributeListCollection = null,
            TypeParameterList typeParameterList = null,
            ConstraintClauseList constraintClauseList = null,
            BaseList baseList = null,
            ConstructorList constructorList = null,
            FieldList fieldList = null,
            MethodList methodList = null,
            PropertyList propertyList = null,
            EnumMemberList enumMemberList = null)
            : base(
                  identifier,
                  @namespace,
                  modifierList,
                  usingDirectiveList,
                  documentationCommentList,
                  attributeListCollection,
                  typeParameterList,
                  constraintClauseList,
                  baseList,
                  constructorList,
                  fieldList,
                  methodList,
                  propertyList)
        {
            EnumMemberList = enumMemberList;
        }
        public EnumDeclaration(
            string identifier,
            string @namespace,
            ModifierList modifierList = null,
            UsingDirectiveList usingDirectiveList = null,
            DocumentationCommentList documentationCommentList = null,
            AttributeListCollection attributeListCollection = null,
            TypeParameterList typeParameterList = null,
            ConstraintClauseList constraintClauseList = null,
            BaseList baseList = null,
            ConstructorList constructorList = null,
            FieldList fieldList = null,
            MethodList methodList = null,
            PropertyList propertyList = null,
            EnumMemberList enumMemberList = null)
            : this(
                  new Identifier(identifier),
                  new Namespace(@namespace),
                  modifierList,
                  usingDirectiveList,
                  documentationCommentList,
                  attributeListCollection,
                  typeParameterList,
                  constraintClauseList,
                  baseList,
                  constructorList,
                  fieldList,
                  methodList,
                  propertyList,
                  enumMemberList)
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
