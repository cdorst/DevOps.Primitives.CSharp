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
    [Table("MethodLists", Schema = nameof(CSharp))]
    public class MethodList : IUniqueList<Method, MethodListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int MethodListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<MethodListAssociation> MethodListAssociations { get; set; }

        public IEnumerable<MemberDeclarationSyntax> GetMemberDeclarationSyntax()
            => MemberDeclarationSorter.Sort(MethodListAssociations.Select(m => m.Method));
    }
}
