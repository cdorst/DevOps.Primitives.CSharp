﻿using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Methods", Schema = nameof(CSharp))]
    public class Method : ISortableMemberDeclaration, IUniqueListRecord
    {
        public Method() { }
        public Method(
            in Identifier identifier,
            in Identifier type,
            in ParameterList parameterList = default,
            in Expression arrowClauseExpression = default,
            in Block block = default,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributes = default)
        {
            ArrowClauseExpressionValue = arrowClauseExpression;
            AttributeListCollection = attributes;
            Block = block;
            DocumentationCommentList = documentationCommentList;
            Identifier = identifier;
            ModifierList = modifierList;
            ParameterList = parameterList;
            Type = type;
        }
        public Method(
            in string identifier,
            in string type,
            in ParameterList parameterList = default,
            in Expression arrowClauseExpression = default,
            in Block block = default,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributes = default)
            : this(
                  new Identifier(in identifier),
                  new Identifier(in type),
                  in parameterList,
                  in arrowClauseExpression,
                  in block,
                  in modifierList,
                  in documentationCommentList,
                  in attributes)
        {
        }
        public Method(
            in string identifier,
            in string type,
            in ParameterList parameterList = default,
            in Block block = default,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributes = default)
            : this(
                  new Identifier(in identifier),
                  new Identifier(in type),
                  in parameterList,
                  arrowClauseExpression: null,
                  in block,
                  in modifierList,
                  in documentationCommentList,
                  in attributes)
        {
        }
        public Method(
            in string identifier,
            in string type,
            in string arrowClauseExpression,
            in ParameterList parameterList = default,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributes = default)
            : this(
                  new Identifier(in identifier),
                  new Identifier(in type),
                  in parameterList,
                  new Expression(in arrowClauseExpression),
                  block: null,
                  in modifierList,
                  in documentationCommentList,
                  in attributes)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int MethodId { get; set; }

        [ProtoMember(2)]
        public Expression ArrowClauseExpressionValue { get; set; }
        [ProtoMember(3)]
        public int? ArrowClauseExpressionValueId { get; set; }

        [ProtoMember(4)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(5)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(6)]
        public Block Block { get; set; }
        [ProtoMember(7)]
        public int? BlockId { get; set; }

        [ProtoMember(8)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(9)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(10)]
        public Identifier Identifier { get; set; }
        [ProtoMember(11)]
        public int IdentifierId { get; set; }

        [ProtoMember(12)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(13)]
        public byte? ModifierListId { get; set; }

        [ProtoMember(14)]
        public ParameterList ParameterList { get; set; }
        [ProtoMember(15)]
        public int? ParameterListId { get; set; }

        [ProtoMember(16)]
        public Identifier Type { get; set; }
        [ProtoMember(17)]
        public int TypeId { get; set; }

        [ProtoMember(18)]
        public TypeParameterList TypeParameterList { get; set; }
        [ProtoMember(19)]
        public int? TypeParameterListId { get; set; }

        [ProtoMember(20)]
        public ConstraintClauseList ConstraintClauseList { get; set; }
        [ProtoMember(21)]
        public int? ConstraintClauseListId { get; set; }

        public MemberDeclarationSyntax GetMemberDeclarationSyntax()
        {
            var hasAttributes = AttributeListCollection != null;
            var hasModifiers = ModifierList != null;
            var declaration = MethodDeclaration(
                IdentifierName(
                    Type.GetSyntaxToken((!hasAttributes && !hasModifiers) ? DocumentationCommentList : null)),
                Identifier.GetSyntaxToken());
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
            if (ParameterList != null)
            {
                declaration = declaration.WithParameterList(
                    ParameterList.GetParameterListSyntax());
            }
            if (TypeParameterList != null)
            {
                declaration = declaration.WithTypeParameterList(
                    TypeParameterList.GetTypeParameterListSyntax());
            }
            if (ConstraintClauseList != null)
            {
                declaration = declaration.WithConstraintClauses(
                    ConstraintClauseList.GetConstraintClauses());
            }
            return (ArrowClauseExpressionValue != null)
                ? declaration
                    .WithExpressionBody(
                        ArrowClauseExpressionValue.GetArrowExpressionClauseSyntax())
                    .WithSemicolonToken(
                        Token(SyntaxKind.SemicolonToken))
                : (Block != null)
                ? declaration.WithBody(
                    Block.GetBlockSyntax())
                : declaration.WithSemicolonToken(
                    Token(SyntaxKind.SemicolonToken));
        }
    }
}
