﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    public class StructDeclaration : TypeDeclaration
    {
        public StructDeclaration() { }
        public StructDeclaration(
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
            in PropertyList propertyList = default)
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
        }
        public StructDeclaration(
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
            in PropertyList propertyList = default)
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
                  in propertyList)
        {
        }

        protected override BaseTypeDeclarationSyntax GetTypeDeclarationSyntax()
        {
            var hasAttributes = AttributeListCollection != null;
            var hasModifiers = ModifierList != null;
            var declaration = StructDeclaration(
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
            if (FieldList != null)
            {
                memberList.AddRange(FieldList.GetMemberDeclarationSyntax());
            }
            if (ConstructorList != null)
            {
                memberList.AddRange(ConstructorList.GetMemberDeclarationSyntax());
            }
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
