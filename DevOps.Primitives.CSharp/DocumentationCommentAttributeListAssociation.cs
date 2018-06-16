using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("DocumentationCommentAttributeListAssociations", Schema = nameof(CSharp))]
    public class DocumentationCommentAttributeListAssociation : IUniqueListAssociation<DocumentationCommentAttribute>
    {
        public DocumentationCommentAttributeListAssociation() { }
        public DocumentationCommentAttributeListAssociation(in DocumentationCommentAttribute documentationCommentAttribute, in DocumentationCommentAttributeList documentationCommentAttributeList = default)
        {
            DocumentationCommentAttribute = documentationCommentAttribute;
            DocumentationCommentAttributeList = documentationCommentAttributeList;
        }
        public DocumentationCommentAttributeListAssociation(in Identifier attribute, in Identifier value, in DocumentationCommentAttributeList documentationCommentAttributeList = default)
            : this(new DocumentationCommentAttribute(in attribute, in value), in documentationCommentAttributeList)
        {
        }
        public DocumentationCommentAttributeListAssociation(in string attribute, in string value, in DocumentationCommentAttributeList documentationCommentAttributeList = default)
            : this(new Identifier(in attribute), new Identifier(in value), in documentationCommentAttributeList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentAttributeListAssociationId { get; set; }

        [ProtoMember(2)]
        public DocumentationCommentAttribute DocumentationCommentAttribute { get; set; }
        [ProtoMember(3)]
        public int DocumentationCommentAttributeId { get; set; }

        [ProtoMember(4)]
        public DocumentationCommentAttributeList DocumentationCommentAttributeList { get; set; }
        [ProtoMember(5)]
        public int DocumentationCommentAttributeListId { get; set; }

        public DocumentationCommentAttribute GetRecord() => DocumentationCommentAttribute;

        public void SetRecord(in DocumentationCommentAttribute record)
        {
            DocumentationCommentAttribute = record;
            DocumentationCommentAttributeId = DocumentationCommentAttribute.DocumentationCommentAttributeId;
        }
    }
}
