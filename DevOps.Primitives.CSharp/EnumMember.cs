using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("EnumMembers", Schema = nameof(CSharp))]
    public class EnumMember : IUniqueListRecord
    {
        public EnumMember() { }
        public EnumMember(Identifier identifier, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, int? equalsValue = null)
        {
            Identifier = identifier;
            DocumentationCommentList = documentationCommentList;
            AttributeListCollection = attributeListCollection;
            EqualsValue = equalsValue;
        }
        public EnumMember(string identifier, DocumentationCommentList documentationCommentList = null, AttributeListCollection attributeListCollection = null, int? equalsValue = null)
            : this(new Identifier(identifier), documentationCommentList, attributeListCollection, equalsValue)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int EnumMemberId { get; set; }

        [ProtoMember(2)]
        public int? EqualsValue { get; set; }

        [ProtoMember(3)]
        public Identifier Identifier { get; set; }
        [ProtoMember(4)]
        public int IdentifierId { get; set; }

        [ProtoMember(5)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(6)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(7)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(8)]
        public int? AttributeListCollectionId { get; set; }

        public EnumMemberDeclarationSyntax GetEnumMemberDeclaration()
        {
            var declaration = EqualsValue == null
                ? EnumMemberDeclaration(Identifier.GetSyntaxToken(DocumentationCommentList))
                : EnumMemberDeclaration(Identifier.GetSyntaxToken(DocumentationCommentList))
                    .WithEqualsValue(
                        EqualsValueClause(
                            LiteralExpression(
                                SyntaxKind.NumericLiteralExpression,
                                Literal(EqualsValue.Value))));
            return AttributeListCollection == null
                ? declaration
                : declaration.WithAttributeLists(AttributeListCollection.GetAttributeListSyntaxList());
        }
    }
}
