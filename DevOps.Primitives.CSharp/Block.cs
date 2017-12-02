using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Blocks", Schema = nameof(CSharp))]
    public class Block
    {
        [Key]
        [ProtoMember(1)]
        public int BlockId { get; set; }

        [ProtoMember(2)]
        public StatementList StatementList { get; set; }
        [ProtoMember(3)]
        public int StatementListId { get; set; }

        public BlockSyntax GetBlockSyntax()
            => Block(
                StatementList.GetStatementListSyntax());
    }
}
