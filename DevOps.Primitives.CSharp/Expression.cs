using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Expressions", Schema = nameof(CSharp))]
    public class Expression
    {
        [Key]
        [ProtoMember(1)]
        public int ExpressionId { get; set; }

        [ProtoMember(2)]
        public AsciiMaxStringReference Text { get; set; }
        [ProtoMember(3)]
        public int TextId { get; set; }

        public ExpressionSyntax GetExpressionSyntax()
            => ParseExpression(
                Text.Value);
    }
}
