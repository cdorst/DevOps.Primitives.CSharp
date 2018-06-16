using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static System.Environment;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("DocumentationComments", Schema = nameof(CSharp))]
    public class DocumentationComment : IUniqueListRecord
    {
        public const string SummaryElement = "summary";

        public DocumentationComment() { }
        public DocumentationComment(in Identifier identifier, in AsciiMaxStringReference text, in bool includeNewLine = false, in byte indentLevel = byte.MinValue)
        {
            Identifier = identifier;
            Text = text;
            IncludeNewLine = includeNewLine;
            IndentLevel = indentLevel;
        }
        public DocumentationComment(in string text, in string identifier = SummaryElement, in bool includeNewLine = false, in byte indentLevel = byte.MinValue)
            : this(new Identifier(in identifier), new AsciiMaxStringReference(in text), in includeNewLine, in indentLevel)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentId { get; set; }

        [ProtoMember(2)]
        public bool IncludeNewLine { get; set; }

        [ProtoMember(3)]
        public byte IndentLevel { get; set; }

        [ProtoMember(4)]
        public Identifier Identifier { get; set; }
        [ProtoMember(5)]
        public int IdentifierId { get; set; }

        [ProtoMember(6)]
        public AsciiMaxStringReference Text { get; set; }
        [ProtoMember(7)]
        public int TextId { get; set; }

        public IEnumerable<XmlNodeSyntax> GetXmlNodeSyntaxList()
            => new XmlNodeSyntax[]
            {
                XmlText().WithTextTokens(GetTextTokens()),
                XmlExampleElement(
                    SingletonList<XmlNodeSyntax>(
                        XmlText()
                        .WithTextTokens(
                            TokenList(
                                XmlTextLiteral(
                                    TriviaList(),
                                    Text.Value,
                                    Text.Value,
                                    TriviaList())))))
                    .WithStartTag(
                        XmlElementStartTag(
                            XmlName(
                                Identifier.GetSyntaxToken())))
                    .WithEndTag(
                        XmlElementEndTag(
                            XmlName(
                                Identifier.GetSyntaxToken())))
            };

        private SyntaxTokenList GetTextTokens()
            => IncludeNewLine
                ? TokenList(
                    new[]
                    {
                        GetNewLine(),
                        GetDocumentationCommentExterior()
                    })
            : TokenList(
                GetDocumentationCommentExterior());

        private Microsoft.CodeAnalysis.SyntaxToken GetNewLine()
            => XmlTextNewLine(
                TriviaList(),
                NewLine,
                NewLine,
                TriviaList());

        private Microsoft.CodeAnalysis.SyntaxToken GetDocumentationCommentExterior()
            => XmlTextLiteral(
                TriviaList(
                    DocumentationCommentExterior($"{Indent()}///")),
                " ",
                " ",
                TriviaList());

        private string Indent()
            => new String(' ', 4 * IndentLevel);
    }
}
