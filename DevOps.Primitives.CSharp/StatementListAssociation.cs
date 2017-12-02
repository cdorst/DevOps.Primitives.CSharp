using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("StatementListAssociations", Schema = nameof(CSharp))]
    public class StatementListAssociation : IUniqueListAssociation<Statement>
    {
        [Key]
        [ProtoMember(1)]
        public int StatementListAssociationId { get; set; }

        [ProtoMember(2)]
        public Statement Statement { get; set; }
        [ProtoMember(3)]
        public int StatementId { get; set; }

        [ProtoMember(4)]
        public StatementList StatementList { get; set; }
        [ProtoMember(5)]
        public int StatementListId { get; set; }

        public Statement GetRecord() => Statement;

        public void SetRecord(Statement record)
        {
            Statement = record;
            StatementId = Statement.StatementId;
        }
    }
}
