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
        public AttributeListCollectionAssociation() { }
        public AttributeListCollectionAssociation(in Attribute attribute, in AttributeListCollection attributeListCollection = default)
        {
            Attribute = attribute;
            AttributeListCollection = attributeListCollection;
        }
        public AttributeListCollectionAssociation(in Identifier attribute, in AttributeListCollection attributeListCollection = default)
            : this(new Attribute(in attribute), in attributeListCollection)
        {
        }
        public AttributeListCollectionAssociation(in string attribute, in AttributeListCollection attributeListCollection = default)
            : this(new Identifier(in attribute), in attributeListCollection)
        {
        }

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

        public void SetRecord(in Attribute record)
        {
            Attribute = record;
            AttributeId = Attribute.AttributeId;
        }
    }
}
