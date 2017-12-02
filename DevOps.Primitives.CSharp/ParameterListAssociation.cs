using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ParameterListAssociations", Schema = nameof(CSharp))]
    public class ParameterListAssociation : IUniqueListAssociation<Parameter>
    {
        [Key]
        [ProtoMember(1)]
        public int ParameterListAssociationId { get; set; }

        [ProtoMember(2)]
        public Parameter Parameter { get; set; }
        [ProtoMember(3)]
        public int ParameterId { get; set; }

        [ProtoMember(4)]
        public ParameterList ParameterList { get; set; }
        [ProtoMember(5)]
        public int ParameterListId { get; set; }

        public Parameter GetRecord() => Parameter;

        public void SetRecord(Parameter record)
        {
            Parameter = record;
            ParameterId = Parameter.ParameterId;
        }
    }
}
