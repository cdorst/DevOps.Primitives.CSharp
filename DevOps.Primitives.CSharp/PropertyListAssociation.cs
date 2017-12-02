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

        public void SetRecord(Property record)
        {
            Property = record;
            PropertyId = Property.PropertyId;
        }
    }
}
