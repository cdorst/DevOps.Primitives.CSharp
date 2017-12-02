using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ArgumentListAssociations", Schema = nameof(CSharp))]
    public class ArgumentListAssociation : IUniqueListAssociation<Argument>
    {
        [Key]
        [ProtoMember(1)]
        public int ArgumentListAssociationId { get; set; }

        [ProtoMember(2)]
        public Argument Argument { get; set; }
        [ProtoMember(3)]
        public int ArgumentId { get; set; }

        [ProtoMember(4)]
        public ArgumentList ArgumentList { get; set; }
        [ProtoMember(5)]
        public int ArgumentListId { get; set; }

        public Argument GetRecord() => Argument;

        public void SetRecord(Argument record)
        {
            Argument = record;
            ArgumentId = Argument.ArgumentId;
        }
    }
}
