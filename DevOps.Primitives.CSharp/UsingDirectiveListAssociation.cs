using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("UsingDirectiveListAssociations", Schema = nameof(CSharp))]
    public class UsingDirectiveListAssociation : IUniqueListAssociation<UsingDirective>
    {
        public UsingDirectiveListAssociation() { }
        public UsingDirectiveListAssociation(in UsingDirective usingDirective, in UsingDirectiveList usingDirectiveList = default)
        {
            UsingDirective = usingDirective;
            UsingDirectiveList = usingDirectiveList;
        }
        public UsingDirectiveListAssociation(in Identifier usingDirective, in UsingDirectiveList usingDirectiveList = default)
            : this(new UsingDirective(in usingDirective), in usingDirectiveList)
        {
        }
        public UsingDirectiveListAssociation(in string usingDirective, in UsingDirectiveList usingDirectiveList = default)
            : this(new Identifier(in usingDirective), in usingDirectiveList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int UsingDirectiveListAssociationId { get; set; }

        [ProtoMember(2)]
        public UsingDirective UsingDirective { get; set; }
        [ProtoMember(3)]
        public int UsingDirectiveId { get; set; }

        [ProtoMember(4)]
        public UsingDirectiveList UsingDirectiveList { get; set; }
        [ProtoMember(5)]
        public int UsingDirectiveListId { get; set; }

        public UsingDirective GetRecord() => UsingDirective;

        public void SetRecord(in UsingDirective record)
        {
            UsingDirective = record;
            UsingDirectiveId = record.UsingDirectiveId;
        }
    }
}
