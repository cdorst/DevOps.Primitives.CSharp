using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    public class InterfaceDeclaration : TypeDeclaration
    {
        public InterfaceDeclaration() { }
        public InterfaceDeclaration(
            string identifier,
            string @namespace,
            ModifierList modifierList = null,
            UsingDirectiveList usingDirectiveList = null,
            DocumentationCommentList documentationCommentList = null,
            AttributeListCollection attributeListCollection = null,
            TypeParameterList typeParameterList = null,
            ConstraintClauseList constraintClauseList = null,
            BaseList baseList = null,
            MethodList methodList = null,
            PropertyList propertyList = null)
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
                  null,
                  null,
                  methodList,
                  propertyList)
        {
        }

        protected override BaseTypeDeclarationSyntax GetTypeDeclarationSyntax()
        {
            var hasAttributes = AttributeListCollection != null;
            var hasModifiers = ModifierList != null;
            var declaration = InterfaceDeclaration(
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
            if (ConstraintClauseList != null)
            {
                declaration = declaration.WithConstraintClauses(
                    ConstraintClauseList.GetConstraintClauses());
            }
            if (TypeParameterList != null)
            {
                declaration = declaration.WithTypeParameterList(
                    TypeParameterList.GetTypeParameterListSyntax());
            }
            // Get members
            var memberList = new List<MemberDeclarationSyntax>();
            if (PropertyList != null)
            {
                memberList.AddRange(PropertyList.GetMemberDeclarationSyntax());
            }
            if (MethodList != null)
            {
                memberList.AddRange(MethodList.GetMemberDeclarationSyntax());
            }
            return memberList.Count == 1
                ? declaration.WithMembers(
                    SingletonList(memberList.First()))
                : declaration.WithMembers(
                    List(memberList));
        }
    }
}
