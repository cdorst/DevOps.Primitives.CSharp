using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
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
        public MethodList() { }
        public MethodList(in List<MethodListAssociation> methodListAssociations, in AsciiStringReference listIdentifier = default)
        {
            MethodListAssociations = methodListAssociations;
            ListIdentifier = listIdentifier;
        }
        public MethodList(in MethodListAssociation methodListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<MethodListAssociation> { methodListAssociation }, listIdentifier)
        {
        }
        public MethodList(in Method method, in AsciiStringReference listIdentifier = default)
            : this(new MethodListAssociation(method), listIdentifier)
        {
        }

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

        public List<MethodListAssociation> GetAssociations() => MethodListAssociations;

        public void SetRecords(in List<Method> records)
        {
            MethodListAssociations = UniqueListAssociationsFactory<Method, MethodListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Method>.Create(in records, r => r.MethodId));
        }
    }
}
