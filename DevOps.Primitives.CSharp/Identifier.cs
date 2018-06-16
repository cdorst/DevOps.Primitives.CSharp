using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Identifiers", Schema = nameof(CSharp))]
    public class Identifier
    {
        public Identifier() { }
        public Identifier(in AsciiStringReference name) { Name = name; }
        public Identifier(in string name) : this(new AsciiStringReference(name)) { }

        [Key]
        [ProtoMember(1)]
        public int IdentifierId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(3)]
        public int NameId { get; set; }

        public IdentifierNameSyntax GetIdentifierNameSyntax()
            => IdentifierName(Name.Value);

        public NameSyntax GetNameSyntax()
            => ParseName(Name.Value);

        public Microsoft.CodeAnalysis.SyntaxToken GetSyntaxToken(in DocumentationCommentList documentationCommentList = default)
            => documentationCommentList == null
            ? Identifier(Name.Value)
            : Identifier(
                TriviaList(
                    Trivia(
                        documentationCommentList.GetDocumentationCommentTriviaSyntax())),
                Name.Value,
                TriviaList());

        public TypeSyntax GetTypeSyntax()
            => ParseTypeName(Name.Value);

        public override string ToString()
            => Name.Value;
    }
}
