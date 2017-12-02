using Common.EntityFrameworkServices;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("DocumentationComments", Schema = nameof(CSharp))]
    public class DocumentationComment : IUniqueListRecord
    {
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
                Environment.NewLine,
                Environment.NewLine,
                TriviaList());

        private Microsoft.CodeAnalysis.SyntaxToken GetDocumentationCommentExterior()
            => XmlTextLiteral(
                TriviaList(
                    DocumentationCommentExterior($"{Indent()}///")),
                " ",
                " ",
                TriviaList());

        private string Indent()
            => string.Join(string.Empty, indent());

        private IEnumerable<string> indent()
        {
            for (int i = 0; i < IndentLevel; i++)
            {
                yield return "    ";
            }
        }
    }
}
