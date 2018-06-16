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
        public PropertyList(in List<PropertyListAssociation> propertyListAssociations, in AsciiStringReference listIdentifier = default)
        {
            PropertyListAssociations = propertyListAssociations;
            ListIdentifier = listIdentifier;
        }
        public PropertyList(in PropertyListAssociation propertyListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<PropertyListAssociation> { propertyListAssociation }, in listIdentifier)
        {
        }
        public PropertyList(
            in Identifier identifier,
            in Identifier type,
            in AccessorList accessorList,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in AsciiStringReference listIdentifier = default)
            : this(new PropertyListAssociation(in identifier, in type, in accessorList, in modifierList, in documentationCommentList, in attributeListCollection), in listIdentifier)
        {
        }
        public PropertyList(
            in string identifier,
            in string type,
            in AccessorList accessorList,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in identifier), new Identifier(in type), in accessorList, in modifierList, in documentationCommentList, in attributeListCollection, in listIdentifier)
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

        public void SetRecords(in List<Property> records)
        {
            PropertyListAssociations = UniqueListAssociationsFactory<Property, PropertyListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Property>.Create(in records, r => r.PropertyId));
        }
    }
}
