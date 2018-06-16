using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("PropertyListAssociations", Schema = nameof(CSharp))]
    public class PropertyListAssociation : IUniqueListAssociation<Property>
    {
        public PropertyListAssociation() { }
        public PropertyListAssociation(in Property property, in PropertyList propertyList = default)
        {
            Property = property;
            PropertyList = propertyList;
        }
        public PropertyListAssociation(
            in Identifier identifier,
            in Identifier type,
            in AccessorList accessorList,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in PropertyList propertyList = default)
            : this(new Property(in identifier, in type, in accessorList, in modifierList, in documentationCommentList, in attributeListCollection), in propertyList)
        {
        }
        public PropertyListAssociation(
            in string identifier,
            in string type,
            in AccessorList accessorList,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            PropertyList propertyList = default)
            : this(new Identifier(in identifier), new Identifier(in type), in accessorList, in modifierList, in documentationCommentList, in attributeListCollection, in propertyList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int PropertyListAssociationId { get; set; }

        [ProtoMember(2)]
        public Property Property { get; set; }
        [ProtoMember(3)]
        public int PropertyId { get; set; }

        [ProtoMember(4)]
        public PropertyList PropertyList { get; set; }
        [ProtoMember(5)]
        public int PropertyListId { get; set; }

        public Property GetRecord() => Property;

        public void SetRecord(in Property record)
        {
            Property = record;
            PropertyId = record.PropertyId;
        }
    }
}
