using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Statements", Schema = nameof(CSharp))]
    public class Statement : IUniqueListRecord
    {
        public Statement() { }
        public Statement(AsciiMaxStringReference text) { Text = text; }
        public Statement(string text) : this(new AsciiMaxStringReference(text)) { }

        [Key]
        [ProtoMember(1)]
        public int StatementId { get; set; }

        [ProtoMember(2)]
        public AsciiMaxStringReference Text { get; set; }
        [ProtoMember(3)]
        public int TextId { get; set; }

        public StatementSyntax GetStatementSyntax()
            => ParseStatement(
                Text.Value);
    }
}
