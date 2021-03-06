﻿using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Properties", Schema = nameof(CSharp))]
    public class Property : ISortableMemberDeclaration, IUniqueListRecord
    {
        public Property() { }
        public Property(
            in Identifier identifier,
            in Identifier type,
            in AccessorList accessorList,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default)
        {
            AccessorList = accessorList;
            AttributeListCollection = attributeListCollection;
            DocumentationCommentList = documentationCommentList;
            Identifier = identifier;
            ModifierList = modifierList;
            Type = type;
        }
        public Property(
            in string identifier,
            in string type,
            in AccessorList accessorList,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default)
            : this(new Identifier(in identifier), new Identifier(in type), in accessorList, in modifierList, in documentationCommentList, in attributeListCollection)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int PropertyId { get; set; }

        [ProtoMember(2)]
        public AccessorList AccessorList { get; set; }
        [ProtoMember(3)]
        public int AccessorListId { get; set; }

        [ProtoMember(4)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(5)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(6)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(7)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(8)]
        public Identifier Identifier { get; set; }
        [ProtoMember(9)]
        public int IdentifierId { get; set; }

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
            var declaration = PropertyDeclaration(
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
            return declaration.WithAccessorList(
                AccessorList.GetAccessorListSyntax());
        }
    }
}
