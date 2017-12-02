using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ConstraintListAssociations", Schema = nameof(CSharp))]
    public class ConstraintListAssociation : IUniqueListAssociation<Constraint>
    {
        [Key]
        [ProtoMember(1)]
        public int ConstraintListAssociationId { get; set; }

        [ProtoMember(2)]
        public Constraint Constraint { get; set; }
        [ProtoMember(3)]
        public int ConstraintId { get; set; }

        [ProtoMember(4)]
        public ConstraintList ConstraintList { get; set; }
        [ProtoMember(5)]
        public int ConstraintListId { get; set; }

        public Constraint GetRecord() => Constraint;

        public void SetRecord(Constraint record)
        {
            Constraint = record;
            ConstraintId = Constraint.ConstraintId;
        }
    }
}
