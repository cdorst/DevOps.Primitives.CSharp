using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static System.Environment;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("DocumentationCommentLists", Schema = nameof(CSharp))]
    public class DocumentationCommentList : IUniqueList<DocumentationComment, DocumentationCommentListAssociation>
    {
        public DocumentationCommentList() { }
        public DocumentationCommentList(in List<DocumentationCommentListAssociation> documentationCommentListAssociations, in bool includeNewLine = false, in AsciiStringReference listIdentifier = default)
        {
            DocumentationComments = documentationCommentListAssociations;
            IncludeNewLine = includeNewLine;
            ListIdentifier = listIdentifier;
        }
        public DocumentationCommentList(in DocumentationCommentListAssociation documentationCommentListAssociations, in bool includeNewLine = false, in AsciiStringReference listIdentifier = default)
            : this(new List<DocumentationCommentListAssociation> { documentationCommentListAssociations }, in includeNewLine, in listIdentifier)
        {
        }
        public DocumentationCommentList(in DocumentationComment documentationComment, in bool includeNewLine = false, in AsciiStringReference listIdentifier = default)
            : this(new DocumentationCommentListAssociation(in documentationComment), in includeNewLine, in listIdentifier)
        {
        }
        public DocumentationCommentList(in Identifier identifier, in AsciiMaxStringReference text, in bool includeNewLine = false, in byte indentLevel = byte.MinValue, in bool includeNewLineAtListLevel = false, in AsciiStringReference listIdentifier = default)
            : this(new DocumentationComment(in identifier, in text, in includeNewLine, in indentLevel), in includeNewLineAtListLevel, in listIdentifier)
        {
        }
        public DocumentationCommentList(in string identifier, in string text, in bool includeNewLine = false, in byte indentLevel = byte.MinValue, in bool includeNewLineAtListLevel = false, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in identifier), new AsciiMaxStringReference(in text), in includeNewLine, in indentLevel, in includeNewLineAtListLevel, in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentListId { get; set; }

        [ProtoMember(2)]
        public bool IncludeNewLine { get; set; }

        [ProtoMember(3)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(4)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(5)]
        public List<DocumentationCommentListAssociation> DocumentationComments { get; set; }

        public DocumentationCommentTriviaSyntax GetDocumentationCommentTriviaSyntax()
            => DocumentationCommentTrivia(
                SyntaxKind.SingleLineDocumentationCommentTrivia,
                List(GetXmlNodeSyntaxList()));

        private IEnumerable<XmlNodeSyntax> GetXmlNodeSyntaxList()
        {
            var enumeration = DocumentationComments.SelectMany(c => c.DocumentationComment.GetXmlNodeSyntaxList());
            if (!IncludeNewLine) return enumeration;
            var list = enumeration.ToList();
            list.Add(GetNewLine());
            return list;
        }

        private static XmlTextSyntax GetNewLine()
            => XmlText()
                .WithTextTokens(
                    TokenList(
                        XmlTextNewLine(
                            TriviaList(),
                            NewLine,
                            NewLine,
                            TriviaList())));

        public List<DocumentationCommentListAssociation> GetAssociations() => DocumentationComments;

        public void SetRecords(in List<DocumentationComment> records)
        {
            DocumentationComments = UniqueListAssociationsFactory<DocumentationComment, DocumentationCommentListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<DocumentationComment>.Create(in records, r => r.DocumentationCommentId));
        }
    }
}
