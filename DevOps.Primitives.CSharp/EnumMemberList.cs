using Common.EntityFrameworkServices;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("EnumMemberLists", Schema = nameof(CSharp))]
    public class EnumMemberList : IUniqueList<EnumMember, EnumMemberListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int EnumMemberListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<EnumMemberListAssociation> EnumMemberListAssociations { get; set; }

        public SeparatedSyntaxList<EnumMemberDeclarationSyntax> GetEnumMembers()
        {
            if (EnumMemberListAssociations.Count == 1)
            {
                return SingletonSeparatedList(
                    EnumMemberListAssociations
                        .First()
                        .EnumMember
                        .GetEnumMemberDeclaration());
            }
            var last = EnumMemberListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    EnumMemberListAssociations[i]
                        .EnumMember
                        .GetEnumMemberDeclaration());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return SeparatedList<EnumMemberDeclarationSyntax>(list);
        }

        public List<EnumMemberListAssociation> GetAssociations() => EnumMemberListAssociations;

        public void SetRecords(List<EnumMember> records)
        {
            for (int i = 0; i < EnumMemberListAssociations.Count; i++)
            {
                EnumMemberListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.EnumMemberId)));
        }
    }
}
