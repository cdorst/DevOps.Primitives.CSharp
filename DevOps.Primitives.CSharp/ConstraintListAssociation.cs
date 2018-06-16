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
        public ConstraintListAssociation() { }
        public ConstraintListAssociation(in Constraint constraint, in ConstraintList constraintList = default)
        {
            Constraint = constraint;
            ConstraintList = constraintList;
        }
        public ConstraintListAssociation(in Identifier constraint, in ConstraintList constraintList = default)
            : this(new Constraint(in constraint), in constraintList)
        {
        }
        public ConstraintListAssociation(in string constraint, in ConstraintList constraintList = default)
            : this(new Identifier(in constraint), in constraintList)
        {
        }

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

        public void SetRecord(in Constraint record)
        {
            Constraint = record;
            ConstraintId = record.ConstraintId;
        }
    }
}
