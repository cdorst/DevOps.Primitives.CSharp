using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ModifierListAssociations", Schema = nameof(CSharp))]
    public class ModifierListAssociation : IUniqueListAssociation<SyntaxToken>
    {
        public ModifierListAssociation() { }
        public ModifierListAssociation(in SyntaxToken syntaxToken, in ModifierList modifierList = default)
        {
            SyntaxToken = syntaxToken;
            ModifierList = modifierList;
        }
        public ModifierListAssociation(in SyntaxKind syntaxKind, in ModifierList modifierList = default)
            : this(new SyntaxToken(syntaxKind), modifierList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public short ModifierListAssociationId { get; set; }

        [ProtoMember(2)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(3)]
        public byte ModifierListId { get; set; }

        [ProtoMember(4)]
        public SyntaxToken SyntaxToken { get; set; }
        [ProtoMember(5)]
        public short SyntaxTokenId { get; set; }

        public SyntaxToken GetRecord() => SyntaxToken;

        public void SetRecord(in SyntaxToken record)
        {
            SyntaxToken = record;
            SyntaxTokenId = record.SyntaxTokenId;
        }
    }
}
