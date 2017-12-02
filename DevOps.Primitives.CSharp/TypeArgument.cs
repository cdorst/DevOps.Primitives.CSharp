using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("TypeArguments", Schema = nameof(CSharp))]
    public class TypeArgument : IUniqueListRecord
    {
        [Key]
        [ProtoMember(1)]
        public int TypeArgumentId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }
    }
}
