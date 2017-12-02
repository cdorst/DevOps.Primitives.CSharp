using Common.EntityFrameworkServices;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ConstructorLists", Schema = nameof(CSharp))]
    public class ConstructorList : IUniqueList<Constructor, ConstructorListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int ConstructorListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<ConstructorListAssociation> ConstructorListAssociations { get; set; }

        public IEnumerable<MemberDeclarationSyntax> GetMemberDeclarationSyntax()
            => MemberDeclarationSorter.Sort(ConstructorListAssociations.Select(c => c.Constructor));

        public List<ConstructorListAssociation> GetAssociations() => ConstructorListAssociations;

        public void SetRecords(List<Constructor> records)
        {
            for (int i = 0; i < ConstructorListAssociations.Count; i++)
            {
                ConstructorListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.ConstructorId)));
        }
    }
}
