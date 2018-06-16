using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ConstructorListAssociations", Schema = nameof(CSharp))]
    public class ConstructorListAssociation : IUniqueListAssociation<Constructor>
    {
        public ConstructorListAssociation() { }
        public ConstructorListAssociation(in Constructor constructor, in ConstructorList constructorList = default)
        {
            Constructor = constructor;
            ConstructorList = constructorList;
        }

        [Key]
        [ProtoMember(1)]
        public int ConstructorListAssociationId { get; set; }

        [ProtoMember(2)]
        public Constructor Constructor { get; set; }
        [ProtoMember(3)]
        public int ConstructorId { get; set; }

        [ProtoMember(4)]
        public ConstructorList ConstructorList { get; set; }
        [ProtoMember(5)]
        public int ConstructorListId { get; set; }

        public Constructor GetRecord() => Constructor;

        public void SetRecord(in Constructor record)
        {
            Constructor = record;
            ConstructorId = Constructor.ConstructorId;
        }
    }
}
