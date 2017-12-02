using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Finalizers", Schema = nameof(CSharp))]
    public class Finalizer
    {
        [Key]
        [ProtoMember(1)]
        public int FinalizerId { get; set; }

        [ProtoMember(2)]
        public Block Block { get; set; }
        [ProtoMember(3)]
        public int BlockId { get; set; }

        [ProtoMember(4)]
        public Identifier Identifier { get; set; }
        [ProtoMember(5)]
        public int IdentifierId { get; set; }

        public DestructorDeclarationSyntax GetDestructorDeclarationSyntax()
            => DestructorDeclaration(Identifier.GetSyntaxToken())
                .WithBody(Block.GetBlockSyntax());
    }
}
