using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("MethodListAssociations", Schema = nameof(CSharp))]
    public class MethodListAssociation : IUniqueListAssociation<Method>
    {
        [Key]
        [ProtoMember(1)]
        public int MethodListAssociationId { get; set; }

        [ProtoMember(2)]
        public Method Method { get; set; }
        [ProtoMember(3)]
        public int MethodId { get; set; }

        [ProtoMember(4)]
        public MethodList MethodList { get; set; }
        [ProtoMember(5)]
        public int MethodListId { get; set; }

        public Method GetRecord() => Method;

        public void SetRecord(Method record)
        {
            Method = record;
            MethodId = Method.MethodId;
        }
    }
}
