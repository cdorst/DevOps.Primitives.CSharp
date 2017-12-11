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
    [Table("Accessors", Schema = nameof(CSharp))]
    public class Accessor : IUniqueListRecord
    {
        public Accessor() { }
        public Accessor(SyntaxToken syntaxToken, Block block = null)
        {
            SyntaxToken = syntaxToken;
            Body = block;
        }
        public Accessor(SyntaxKind syntaxKind, Block block = null)
            : this(new SyntaxToken(syntaxKind), block)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int AccessorId { get; set; }

        [ProtoMember(2)]
        public Block Body { get; set; }
        [ProtoMember(3)]
        public int? BodyId { get; set; }

        [ProtoMember(4)]
        public SyntaxToken SyntaxToken { get; set; }
        [ProtoMember(5)]
        public short SyntaxTokenId { get; set; }

        public AccessorDeclarationSyntax GetAccessorDeclarationSyntax()
        {
            var accessor = AccessorDeclaration(
                SyntaxToken.SyntaxKind);
            return (Body == null)
                ? accessor.WithSemicolonToken(Token(SyntaxKind.SemicolonToken))
                : accessor.WithBody(Body.GetBlockSyntax());
        }
    }
}
