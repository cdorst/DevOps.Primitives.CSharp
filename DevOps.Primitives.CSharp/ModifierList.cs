using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ModifierLists", Schema = nameof(CSharp))]
    public class ModifierList : IUniqueList<SyntaxToken, ModifierListAssociation>
    {
        public ModifierList() { }
        public ModifierList(in List<ModifierListAssociation> modifierListAssociations, in AsciiStringReference listIdentifier = default)
        {
            ModifierListAssociations = modifierListAssociations;
            ListIdentifier = listIdentifier;
        }
        public ModifierList(in ModifierListAssociation modifierListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<ModifierListAssociation> { modifierListAssociation }, in listIdentifier)
        {
        }
        public ModifierList(in SyntaxToken syntaxToken, in AsciiStringReference listIdentifier = default)
            : this(new ModifierListAssociation(in syntaxToken), in listIdentifier)
        {
        }
        public ModifierList(in SyntaxKind syntaxKind, in AsciiStringReference listIdentifier = default)
            : this(new SyntaxToken(in syntaxKind), in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public byte ModifierListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<ModifierListAssociation> ModifierListAssociations { get; set; }

        public SyntaxTokenList GetSyntaxTokenList(in DocumentationCommentList documentationCommentList = default)
        {
            if (documentationCommentList == null)
            {
                return TokenList(
                    GetSyntaxTokensSorted().Select(s => s.GetToken()));
            }
            var sorted = GetSyntaxTokensSorted();
            var count = sorted.Count();
            var list = new List<Microsoft.CodeAnalysis.SyntaxToken>();
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    list.Add(sorted[i].GetToken(documentationCommentList));
                    continue;
                }
                list.Add(sorted[i].GetToken());
            }
            return TokenList(list);
        }

        public List<SyntaxToken> GetSyntaxTokensSorted()
            => ModifierListAssociations
                .Select(m => m.SyntaxToken)
                .OrderBy(m => Rank(m.SyntaxKind))
                .ToList();

        public List<ModifierListAssociation> GetAssociations() => ModifierListAssociations;

        public void SetRecords(in List<SyntaxToken> records)
        {
            ModifierListAssociations = UniqueListAssociationsFactory<SyntaxToken, ModifierListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<SyntaxToken>.Create(in records, r => r.SyntaxTokenId));
        }

        private static int Rank(in SyntaxKind modifier)
            => modifier == SyntaxKind.PublicKeyword ? 0
            : modifier == SyntaxKind.ProtectedKeyword ? 1
            : modifier == SyntaxKind.InternalKeyword ? 2
            : modifier == SyntaxKind.PrivateKeyword ? 3
            : modifier == SyntaxKind.NewKeyword ? 4
            : modifier == SyntaxKind.AbstractKeyword ? 5
            : modifier == SyntaxKind.VirtualKeyword ? 6
            : modifier == SyntaxKind.OverrideKeyword ? 7
            : modifier == SyntaxKind.SealedKeyword ? 8
            : modifier == SyntaxKind.StaticKeyword ? 9
            : modifier == SyntaxKind.ReadOnlyKeyword ? 10
            : modifier == SyntaxKind.ExternKeyword ? 11
            : modifier == SyntaxKind.UnsafeKeyword ? 12
            : modifier == SyntaxKind.VolatileKeyword ? 13
            : modifier == SyntaxKind.AsyncKeyword ? 14
            : 15;
    }
}
