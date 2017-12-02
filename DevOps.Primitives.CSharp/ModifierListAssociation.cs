using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ModifierListAssociations", Schema = nameof(CSharp))]
    public class ModifierListAssociation : IUniqueListAssociation<SyntaxToken>
    {
        [Key]
        [ProtoMember(1)]
        public int ModifierListAssociationId { get; set; }

        [ProtoMember(2)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(3)]
        public int ModifierListId { get; set; }

        [ProtoMember(4)]
        public SyntaxToken SyntaxToken { get; set; }
        [ProtoMember(5)]
        public int SyntaxTokenId { get; set; }

        public SyntaxToken GetRecord() => SyntaxToken;

        public void SetRecord(SyntaxToken record)
        {
            SyntaxToken = record;
            SyntaxTokenId = SyntaxToken.SyntaxTokenId;
        }
    }
}
