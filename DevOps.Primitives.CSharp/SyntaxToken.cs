using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("SyntaxTokens", Schema = nameof(CSharp))]
    public class SyntaxToken : IUniqueListRecord
    {
        public SyntaxToken() { }
        public SyntaxToken(in SyntaxKind syntaxKind) { SyntaxKind = syntaxKind; }

        [Key]
        [ProtoMember(1)]
        public short SyntaxTokenId { get; set; }

        [ProtoMember(2)]
        public SyntaxKind SyntaxKind { get; set; }

        public Microsoft.CodeAnalysis.SyntaxToken GetToken(DocumentationCommentList documentationCommentList = null)
            => documentationCommentList == null
            ? Token(SyntaxKind)
            : Token(
                TriviaList(
                    Trivia(
                        documentationCommentList.GetDocumentationCommentTriviaSyntax())),
                SyntaxKind,
                TriviaList());
    }
}
