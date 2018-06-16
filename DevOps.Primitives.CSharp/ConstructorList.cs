using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static DevOps.Primitives.CSharp.MemberDeclarationSorter;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ConstructorLists", Schema = nameof(CSharp))]
    public class ConstructorList : IUniqueList<Constructor, ConstructorListAssociation>
    {
        public ConstructorList() { }
        public ConstructorList(in List<ConstructorListAssociation> constructorListAssociations, in AsciiStringReference listIdentifier = default)
        {
            ConstructorListAssociations = constructorListAssociations;
            ListIdentifier = listIdentifier;
        }
        public ConstructorList(in ConstructorListAssociation constructorListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<ConstructorListAssociation> { constructorListAssociation }, in listIdentifier)
        {
        }
        public ConstructorList(in Constructor constructor, in AsciiStringReference listIdentifier = default)
            : this(new ConstructorListAssociation(constructor), in listIdentifier)
        {
        }

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
            => Sort(ConstructorListAssociations.Select(c => c.Constructor));

        public List<ConstructorListAssociation> GetAssociations() => ConstructorListAssociations;

        public void SetRecords(in List<Constructor> records)
        {
            ConstructorListAssociations = UniqueListAssociationsFactory<Constructor, ConstructorListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Constructor>.Create(in records, r => r.ConstructorId));
        }
    }
}
