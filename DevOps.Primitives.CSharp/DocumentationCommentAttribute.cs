using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("DocumentationCommentAttributes", Schema = nameof(CSharp))]
    public class DocumentationCommentAttribute : IUniqueListRecord
    {
        public DocumentationCommentAttribute() { }
        public DocumentationCommentAttribute(in Identifier identifier, in Identifier value)
        {
            Identifier = identifier;
            Value = value;
        }
        public DocumentationCommentAttribute(in string identifier, in string value)
            : this(new Identifier(in identifier), new Identifier(in value))
        {
        }

        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentAttributeId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        [ProtoMember(4)]
        public Identifier Value { get; set; }
        [ProtoMember(5)]
        public int ValueId { get; set; }

        public static DocumentationCommentAttribute FromXmlAttributeSyntax(in XmlAttributeSyntax syntax)
        {
            if (syntax is XmlCrefAttributeSyntax) return FromXmlCref(in syntax);
            if (syntax is XmlNameAttributeSyntax) return FromXmlName(in syntax);
            return FromXmlText(syntax as XmlTextAttributeSyntax);
        }

        private static DocumentationCommentAttribute FromXmlCref(in XmlAttributeSyntax syntax)
            => new DocumentationCommentAttribute("cref", (syntax as XmlCrefAttributeSyntax).Cref.ToString());

        private static DocumentationCommentAttribute FromXmlName(in XmlAttributeSyntax syntax)
            => new DocumentationCommentAttribute("name", (syntax as XmlNameAttributeSyntax).Identifier.ToString());

        private static DocumentationCommentAttribute FromXmlText(in XmlTextAttributeSyntax syntax)
            => new DocumentationCommentAttribute(syntax.Name.ToString(), syntax.TextTokens.ToString());

        public XmlAttributeSyntax GetXmlAttributeSyntax()
            => string.Equals(Identifier.Name.Value, "cref", StringComparison.OrdinalIgnoreCase)
            ? GetXmlCrefAttributeSyntax()
            : string.Equals(Identifier.Name.Value, "name", StringComparison.OrdinalIgnoreCase)
            ? GetXmlNameAttributeSyntax()
            : GetXmlTextAttributeSyntax();

        private XmlAttributeSyntax GetXmlCrefAttributeSyntax()
            => XmlCrefAttribute(
                NameMemberCref(
                    ParseName(Value.Name.Value)));

        private XmlAttributeSyntax GetXmlNameAttributeSyntax()
            => XmlNameAttribute(
                XmlName(
                    Identifier.GetSyntaxToken()),
                Token(SyntaxKind.DoubleQuoteToken),
                Value.GetIdentifierNameSyntax(),
                Token(SyntaxKind.DoubleQuoteToken));

        private XmlAttributeSyntax GetXmlTextAttributeSyntax()
            => XmlTextAttribute(
                XmlName(
                    Identifier.GetSyntaxToken()),
                Token(SyntaxKind.DoubleQuoteToken),
                Token(SyntaxKind.DoubleQuoteToken))
            .WithTextTokens(
                TokenList(
                    XmlTextLiteral(
                        TriviaList(),
                        Value.Name.Value,
                        Value.Name.Value,
                        TriviaList())));
    }
}
