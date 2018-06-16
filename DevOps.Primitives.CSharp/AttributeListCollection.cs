using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    /// <remarks>Each instance represents a collection of attribute lists. Each attribute list contains a single attribute</remarks>
    [ProtoContract]
    [Table("AttributeListCollections", Schema = nameof(CSharp))]
    public class AttributeListCollection : IUniqueList<Attribute, AttributeListCollectionAssociation>
    {
        public AttributeListCollection() { }
        public AttributeListCollection(in List<AttributeListCollectionAssociation> attributeLists, in AsciiStringReference listIdentifier = default)
        {
            AttributeLists = attributeLists;
            ListIdentifier = listIdentifier;
        }
        public AttributeListCollection(in AttributeListCollectionAssociation attributeList, in AsciiStringReference listIdentifier = default)
            : this(new List<AttributeListCollectionAssociation> { attributeList }, in listIdentifier)
        {
        }
        public AttributeListCollection(in Identifier attribute, in AsciiStringReference listIdentifier = default)
            : this(new AttributeListCollectionAssociation(in attribute), in listIdentifier)
        {
        }
        public AttributeListCollection(in string attribute, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in attribute), in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int AttributeListCollectionId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<AttributeListCollectionAssociation> AttributeLists { get; set; }

        public SyntaxList<AttributeListSyntax> GetAttributeListSyntaxList(DocumentationCommentList documentation = default)
        {
            var attributes = AttributeLists
                .Select(attr => AttributeList(SingletonSeparatedList(attr.Attribute.GetAttributeSyntax())))
                .ToArray();
            return (documentation == null) ? List(attributes)
                : GetListWithDocumentation(in documentation, in attributes);
        }

        public List<AttributeListCollectionAssociation> GetAssociations() => AttributeLists;

        public void SetRecords(in List<Attribute> records)
        {
            AttributeLists = UniqueListAssociationsFactory<Attribute, AttributeListCollectionAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Attribute>.Create(in records, r => r.AttributeId));
        }

        private static SyntaxList<AttributeListSyntax> GetListWithDocumentation(in DocumentationCommentList documentation, in AttributeListSyntax[] attributes)
        {
            var list = new List<AttributeListSyntax>();
            for (int i = 0; i < attributes.Length; i++)
            {
                var attribute = attributes[i];
                if (i == 0)
                {
                    attribute = attribute.WithOpenBracketToken(
                        Token(
                            TriviaList(
                                Trivia(
                                    documentation.GetDocumentationCommentTriviaSyntax())),
                            SyntaxKind.OpenBracketToken,
                            TriviaList()));
                }
                list.Add(attribute);
            }
            return List(list.ToArray());
        }
    }
}
