using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("AccessorListAssociations", Schema = nameof(CSharp))]
    public class AccessorListAssociation : IUniqueListAssociation<Accessor>
    {
        public AccessorListAssociation() { }
        public AccessorListAssociation(in Accessor accessor, in AccessorList accessorList = default)
        {
            Accessor = accessor;
            AccessorList = accessorList;
        }
        public AccessorListAssociation(in SyntaxToken syntaxToken, in AccessorList accessorList = default)
            : this(new Accessor(in syntaxToken), in accessorList)
        {
        }
        public AccessorListAssociation(in SyntaxKind syntaxKind, in AccessorList accessorList = default)
            : this(new SyntaxToken(in syntaxKind), in accessorList)
        {
        }

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

        public void SetRecord(in Accessor record)
        {
            Accessor = record;
            AccessorId = record.AccessorId;
        }
    }
}
