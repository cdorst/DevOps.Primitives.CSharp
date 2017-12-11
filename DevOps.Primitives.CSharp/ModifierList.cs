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
        public ModifierList(List<ModifierListAssociation> modifierListAssociations, AsciiStringReference listIdentifier = null)
        {
            ModifierListAssociations = modifierListAssociations;
            ListIdentifier = listIdentifier;
        }
        public ModifierList(ModifierListAssociation modifierListAssociation, AsciiStringReference listIdentifier = null)
            : this(new List<ModifierListAssociation> { modifierListAssociation }, listIdentifier)
        {
        }
        public ModifierList(SyntaxToken syntaxToken, AsciiStringReference listIdentifier = null)
            : this(new ModifierListAssociation(syntaxToken), listIdentifier)
        {
        }
        public ModifierList(SyntaxKind syntaxKind, AsciiStringReference listIdentifier = null)
            : this(new SyntaxToken(syntaxKind), listIdentifier)
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

        public static ModifierList Private => new ModifierList(SyntaxKind.PrivateKeyword);
        public static ModifierList PrivateAbstract => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static ModifierList PrivateAbstractAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PrivateOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PrivateStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList PrivateStaticAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateStaticReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PrivateVirtual => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static ModifierList PrivateVirtualAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList Public => new ModifierList(SyntaxKind.PublicKeyword);
        public static ModifierList PublicAbstract => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static ModifierList PublicAbstractAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PublicOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PublicStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList PublicStaticAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicStaticReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PublicVirtual => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static ModifierList PublicVirtualAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });

        public SyntaxTokenList GetSyntaxTokenList(DocumentationCommentList documentationCommentList = null)
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

        public void SetRecords(List<SyntaxToken> records)
        {
            ModifierListAssociations = UniqueListAssociationsFactory<SyntaxToken, ModifierListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<SyntaxToken>.Create(records, r => r.SyntaxTokenId));
        }

        private static int Rank(SyntaxKind modifier)
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
