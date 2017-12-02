using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("AttributeListCollectionAssociations", Schema = nameof(CSharp))]
    public class AttributeListCollectionAssociation : IUniqueListAssociation<Attribute>
    {
        [Key]
        [ProtoMember(1)]
        public int AttributeListCollectionAssociationId { get; set; }

        [ProtoMember(2)]
        public Attribute Attribute { get; set; }
        [ProtoMember(3)]
        public int AttributeId { get; set; }

        [ProtoMember(4)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(5)]
        public int AttributeListCollectionId { get; set; }

        public Attribute GetRecord() => Attribute;

        public void SetRecord(Attribute record)
        {
            Attribute = record;
            AttributeId = Attribute.AttributeId;
        }
    }
}
