using Common.EntityFrameworkServices;
using DevOps.Abstractions.UniqueStrings;
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
        [Key]
        [ProtoMember(1)]
        public int AttributeListCollectionId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<AttributeListCollectionAssociation> AttributeLists { get; set; }

        public SyntaxList<AttributeListSyntax> GetAttributeListSyntaxList(DocumentationCommentList documentation = null)
        {
            var attributes = AttributeLists
                .Select(attr => AttributeList(SingletonSeparatedList(attr.Attribute.GetAttributeSyntax())))
                .ToArray();
            return (documentation == null) ? List(attributes)
                : GetListWithDocumentation(documentation, attributes);
        }

        public List<AttributeListCollectionAssociation> GetAssociations() => AttributeLists;

        public void SetRecords(List<Attribute> records)
        {
            for (int i = 0; i < AttributeLists.Count; i++)
            {
                AttributeLists[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.AttributeId)));
        }

        private static SyntaxList<AttributeListSyntax> GetListWithDocumentation(DocumentationCommentList documentation, AttributeListSyntax[] attributes)
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
