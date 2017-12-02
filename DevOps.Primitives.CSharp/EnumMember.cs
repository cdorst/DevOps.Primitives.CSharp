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

        public EnumMemberDeclarationSyntax GetEnumMemberDeclaration()
            => EqualsValue == null
            ? EnumMemberDeclaration(Identifier.GetSyntaxToken(DocumentationCommentList))
            : EnumMemberDeclaration(Identifier.GetSyntaxToken(DocumentationCommentList))
                .WithEqualsValue(
                    EqualsValueClause(
                        LiteralExpression(
                            SyntaxKind.NumericLiteralExpression,
                            Literal(EqualsValue.Value))));
    }
}
