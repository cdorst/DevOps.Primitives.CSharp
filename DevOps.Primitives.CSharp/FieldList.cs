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
    [Table("FieldLists", Schema = nameof(CSharp))]
    public class FieldList : IUniqueList<Field, FieldListAssociation>
    {
        public FieldList() { }
        public FieldList(in List<FieldListAssociation> fieldListAssociations, in AsciiStringReference listIdentifier = default)
        {
            FieldListAssociations = fieldListAssociations;
            ListIdentifier = listIdentifier;
        }
        public FieldList(in FieldListAssociation fieldListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<FieldListAssociation> { fieldListAssociation }, in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int FieldListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<FieldListAssociation> FieldListAssociations { get; set; }

        public IEnumerable<MemberDeclarationSyntax> GetMemberDeclarationSyntax()
            => MemberDeclarationSorter.Sort(FieldListAssociations.Select(f => f.Field));

        public List<FieldListAssociation> GetAssociations() => FieldListAssociations;

        public void SetRecords(in List<Field> records)
        {
            FieldListAssociations = UniqueListAssociationsFactory<Field, FieldListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Field>.Create(in records, r => r.FieldId));
        }
    }
}
