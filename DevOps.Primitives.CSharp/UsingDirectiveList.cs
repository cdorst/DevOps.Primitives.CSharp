using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis;
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
    [Table("UsingDirectiveLists", Schema = nameof(CSharp))]
    public class UsingDirectiveList : IUniqueList<UsingDirective, UsingDirectiveListAssociation>
    {
        public UsingDirectiveList() { }
        public UsingDirectiveList(in List<UsingDirectiveListAssociation> usingDirectiveListAssociations, in AsciiStringReference listIdentifier = default)
        {
            UsingDirectiveListAssociations = usingDirectiveListAssociations;
            ListIdentifier = listIdentifier;
        }
        public UsingDirectiveList(in UsingDirectiveListAssociation usingDirectiveListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<UsingDirectiveListAssociation> { usingDirectiveListAssociation }, in listIdentifier)
        {
        }
        public UsingDirectiveList(in Identifier usingDirective, in AsciiStringReference listIdentifier = default)
            : this(new UsingDirectiveListAssociation(in usingDirective), in listIdentifier)
        {
        }
        public UsingDirectiveList(in string usingDirective, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in usingDirective), in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int UsingDirectiveListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<UsingDirectiveListAssociation> UsingDirectiveListAssociations { get; set; }

        public SyntaxList<UsingDirectiveSyntax> GetUsingDirectiveListSyntax()
            => UsingDirectiveListAssociations.Count == 1
            ? SingletonList(
                UsingDirectiveListAssociations
                    .First()
                    .UsingDirective
                    .GetUsingDirectiveSyntax())
            : List(
                UsingDirectiveListAssociations
                    .Select(s => s.UsingDirective)
                    .OrderBy(u => u.UsingStatic)
                    .ThenBy(u => u.Identifier.Name.Value)
                    .Select(u => u.GetUsingDirectiveSyntax()));

        public List<UsingDirectiveListAssociation> GetAssociations() => UsingDirectiveListAssociations;

        public void SetRecords(in List<UsingDirective> records)
        {
            UsingDirectiveListAssociations = UniqueListAssociationsFactory<UsingDirective, UsingDirectiveListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<UsingDirective>.Create(in records, r => r.UsingDirectiveId));
        }
    }
}
