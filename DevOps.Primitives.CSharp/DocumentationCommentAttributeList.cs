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
        public DocumentationCommentAttributeList() { }
        public DocumentationCommentAttributeList(in List<DocumentationCommentAttributeListAssociation> documentationCommentAttributeListAssociations, in AsciiStringReference listIdentifier = default)
        {
            DocumentationCommentAttributeListAssociations = documentationCommentAttributeListAssociations;
            ListIdentifier = listIdentifier;
        }
        public DocumentationCommentAttributeList(in DocumentationCommentAttributeListAssociation argumentListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<DocumentationCommentAttributeListAssociation> { argumentListAssociation }, in listIdentifier)
        {
        }
        public DocumentationCommentAttributeList(in DocumentationCommentAttribute attribute, in AsciiStringReference listIdentifier = default)
            : this(new DocumentationCommentAttributeListAssociation(in attribute), in listIdentifier)
        {
        }
        public DocumentationCommentAttributeList(in Identifier attribute, in Identifier value, in AsciiStringReference listIdentifier = default)
            : this(new DocumentationCommentAttribute(in attribute, in value), in listIdentifier)
        {
        }
        public DocumentationCommentAttributeList(in string attribute, in string value, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in attribute), new Identifier(in value), in listIdentifier)
        {
        }

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

        public void SetRecords(in List<DocumentationCommentAttribute> records)
        {
            DocumentationCommentAttributeListAssociations = UniqueListAssociationsFactory<DocumentationCommentAttribute, DocumentationCommentAttributeListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<DocumentationCommentAttribute>.Create(in records, r => r.DocumentationCommentAttributeId));
        }
    }
}
