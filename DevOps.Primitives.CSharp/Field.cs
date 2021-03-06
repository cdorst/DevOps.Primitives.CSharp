﻿using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Fields", Schema = nameof(CSharp))]
    public class Field : ISortableMemberDeclaration, IUniqueListRecord
    {
        public Field() { }
        public Field(
            in Identifier identifier,
            in Identifier type,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in Expression initializer = default,
            in AttributeListCollection attributeListCollection = default)
        {
            Identifier = identifier;
            Type = type;
            ModifierList = modifierList;
            DocumentationCommentList = documentationCommentList;
            Initializer = initializer;
            AttributeListCollection = attributeListCollection;
        }
        public Field(
            in string identifier,
            in string type,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in Expression initializer = default,
            in AttributeListCollection attributeListCollection = default)
            : this(new Identifier(in identifier), new Identifier(in type), in modifierList, in documentationCommentList, in initializer, in attributeListCollection)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int FieldId { get; set; }

        [ProtoMember(2)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(3)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(4)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(5)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(6)]
        public Identifier Identifier { get; set; }
        [ProtoMember(7)]
        public int IdentifierId { get; set; }

        [ProtoMember(8)]
        public Expression Initializer { get; set; }
        [ProtoMember(9)]
        public int? InitializerId { get; set; }

        [ProtoMember(10)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(11)]
        public byte? ModifierListId { get; set; }

        [ProtoMember(12)]
        public Identifier Type { get; set; }
        [ProtoMember(13)]
        public int TypeId { get; set; }

        public MemberDeclarationSyntax GetMemberDeclarationSyntax()
        {

            var hasAttributes = AttributeListCollection != null;
            var hasModifiers = ModifierList != null;
            var declarator = VariableDeclarator(
                Identifier.GetSyntaxToken());
            if (Initializer != null)
            {
                declarator = declarator.WithInitializer(
                    EqualsValueClause(
                        Initializer.GetExpressionSyntax()));
            }
            var declaration = FieldDeclaration(
                VariableDeclaration(
                    IdentifierName(
                        Type.GetSyntaxToken((!hasAttributes && !hasModifiers) ? DocumentationCommentList : null)))
                    .WithVariables(
                        SingletonSeparatedList(declarator)));
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
            return declaration;
        }
    }
}
