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
    [Table("PropertyLists", Schema = nameof(CSharp))]
    public class PropertyList : IUniqueList<Property, PropertyListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int PropertyListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<PropertyListAssociation> PropertyListAssociations { get; set; }

        public IEnumerable<MemberDeclarationSyntax> GetMemberDeclarationSyntax()
            => MemberDeclarationSorter.Sort(PropertyListAssociations.Select(p => p.Property));

        public List<PropertyListAssociation> GetAssociations() => PropertyListAssociations;

        public void SetRecords(List<Property> records)
        {
            for (int i = 0; i < PropertyListAssociations.Count; i++)
            {
                PropertyListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.PropertyId)));
        }
    }
}
