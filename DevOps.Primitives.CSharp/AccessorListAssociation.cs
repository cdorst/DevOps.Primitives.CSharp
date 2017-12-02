using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("AccessorListAssociations", Schema = nameof(CSharp))]
    public class AccessorListAssociation : IUniqueListAssociation<Accessor>
    {
        [Key]
        [ProtoMember(1)]
        public int AccessorListAssociationId { get; set; }

        [ProtoMember(2)]
        public Accessor Accessor { get; set; }
        [ProtoMember(3)]
        public int AccessorId { get; set; }

        [ProtoMember(4)]
        public AccessorList AccessorList { get; set; }
        [ProtoMember(5)]
        public int AccessorListId { get; set; }

        public Accessor GetRecord() => Accessor;

        public void SetRecord(Accessor record)
        {
            Accessor = record;
            AccessorId = Accessor.AccessorId;
        }
    }
}
