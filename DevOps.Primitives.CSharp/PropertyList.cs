using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("PropertyLists", Schema = nameof(CSharp))]
    public class PropertyList : IUniqueList<Property, PropertyListAssociation>
    {
        public PropertyList() { }
        public PropertyList(List<PropertyListAssociation> propertyListAssociations, AsciiStringReference listIdentifier = null)
        {
            PropertyListAssociations = propertyListAssociations;
            ListIdentifier = listIdentifier;
        }
        public PropertyList(PropertyListAssociation propertyListAssociation, AsciiStringReference listIdentifier = null)
            : this(new List<PropertyListAssociation> { propertyListAssociation }, listIdentifier)
        {
        }
        public PropertyList(
            Identifier identifier,
            Identifier type,
            AccessorList accessorList,
            ModifierList modifierList = null,
            DocumentationCommentList documentationCommentList = null,
            AttributeListCollection attributeListCollection = null,
            AsciiStringReference listIdentifier = null)
            : this(new PropertyListAssociation(identifier, type, accessorList, modifierList, documentationCommentList, attributeListCollection), listIdentifier)
        {
        }
        public PropertyList(
            string identifier,
            string type,
            AccessorList accessorList,
            ModifierList modifierList = null,
            DocumentationCommentList documentationCommentList = null,
            AttributeListCollection attributeListCollection = null,
            AsciiStringReference listIdentifier = null)
            : this(new Identifier(identifier), new Identifier(type), accessorList, modifierList, documentationCommentList, attributeListCollection, listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int PropertyListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<PropertyListAssociation> PropertyListAssociations { get; set; }

        public IEnumerable<MemberDeclarationSyntax> GetMemberDeclarationSyntax()
            => MemberDeclarationSorter.Sort(PropertyListAssociations.Select(p => p.Property));

        public List<PropertyListAssociation> GetAssociations() => PropertyListAssociations;

        public void SetRecords(List<Property> records)
        {
            PropertyListAssociations = UniqueListAssociationsFactory<Property, PropertyListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Property>.Create(records, r => r.PropertyId));
        }
    }
}
