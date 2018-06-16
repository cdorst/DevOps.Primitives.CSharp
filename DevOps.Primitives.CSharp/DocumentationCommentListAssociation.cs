using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("DocumentationCommentListAssociations", Schema = nameof(CSharp))]
    public class DocumentationCommentListAssociation : IUniqueListAssociation<DocumentationComment>
    {
        public DocumentationCommentListAssociation() { }
        public DocumentationCommentListAssociation(in DocumentationComment documentationComment, in DocumentationCommentList documentationCommentList = default)
        {
            DocumentationComment = documentationComment;
            DocumentationCommentList = documentationCommentList;
        }
        public DocumentationCommentListAssociation(in Identifier identifier, in AsciiMaxStringReference text, in bool includeNewLine = false, in byte indentLevel = byte.MinValue, in DocumentationCommentList documentationCommentList = default)
            : this(new DocumentationComment(in identifier, in text, in includeNewLine, in indentLevel), in documentationCommentList)
        {
        }
        public DocumentationCommentListAssociation(in string identifier, in string text, in bool includeNewLine = false, in byte indentLevel = byte.MinValue, in DocumentationCommentList documentationCommentList = default)
            : this(new Identifier(in identifier), new AsciiMaxStringReference(in text), in includeNewLine, in indentLevel, in documentationCommentList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentListAssociationId { get; set; }

        [ProtoMember(2)]
        public DocumentationComment DocumentationComment { get; set; }
        [ProtoMember(3)]
        public int DocumentationCommentId { get; set; }

        [ProtoMember(4)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(5)]
        public int DocumentationCommentListId { get; set; }

        public DocumentationComment GetRecord() => DocumentationComment;

        public void SetRecord(in DocumentationComment record)
        {
            DocumentationComment = record;
            DocumentationCommentId = DocumentationComment.DocumentationCommentId;
        }
    }
}
