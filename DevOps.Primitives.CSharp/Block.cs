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
        public Block() { }
        public Block(in StatementList statementList) { StatementList = statementList; }

        [Key]
        [ProtoMember(1)]
        public int BlockId { get; set; }

        [ProtoMember(2)]
        public StatementList StatementList { get; set; }
        [ProtoMember(3)]
        public int? StatementListId { get; set; }

        public BlockSyntax GetBlockSyntax()
            => StatementList == null
            ? Block()
            : Block().WithStatements(StatementList.GetStatementListSyntax());
    }
}
