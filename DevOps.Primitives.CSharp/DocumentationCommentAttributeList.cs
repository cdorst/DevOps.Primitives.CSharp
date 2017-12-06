using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("DocumentationCommentAttributeLists", Schema = nameof(CSharp))]
    public class DocumentationCommentAttributeList : IUniqueList<DocumentationCommentAttribute, DocumentationCommentAttributeListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int DocumentationCommentAttributeListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<DocumentationCommentAttributeListAssociation> DocumentationCommentAttributeListAssociations { get; set; }

        public static DocumentationCommentAttributeList FromXmlAttributeSyntaxList(IEnumerable<XmlAttributeSyntax> list)
            => new DocumentationCommentAttributeList
            {
                DocumentationCommentAttributeListAssociations = list
                    .Select(attribute => new DocumentationCommentAttributeListAssociation { DocumentationCommentAttribute = DocumentationCommentAttribute.FromXmlAttributeSyntax(attribute) })
                    .ToList()
            };

        public IEnumerable<XmlAttributeSyntax> GetXmlAttributeSyntaxList()
            => (DocumentationCommentAttributeListAssociations.Count == 1)
            ? (IEnumerable<XmlAttributeSyntax>)SingletonList(
                    DocumentationCommentAttributeListAssociations.First()
                        .DocumentationCommentAttribute.GetXmlAttributeSyntax())
            : DocumentationCommentAttributeListAssociations
                .Select(association => association.DocumentationCommentAttribute.GetXmlAttributeSyntax())
                .ToList();

        public List<DocumentationCommentAttributeListAssociation> GetAssociations() => DocumentationCommentAttributeListAssociations;

        public void SetRecords(List<DocumentationCommentAttribute> records)
        {
            DocumentationCommentAttributeListAssociations = UniqueListAssociationsFactory<DocumentationCommentAttribute, DocumentationCommentAttributeListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<DocumentationCommentAttribute>.Create(records, r => r.DocumentationCommentAttributeId));
        }
    }
}
