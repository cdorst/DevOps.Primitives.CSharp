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
        public UsingDirectiveList(List<UsingDirectiveListAssociation> usingDirectiveListAssociations, AsciiStringReference listIdentifier = null)
        {
            UsingDirectiveListAssociations = usingDirectiveListAssociations;
            ListIdentifier = listIdentifier;
        }
        public UsingDirectiveList(UsingDirectiveListAssociation usingDirectiveListAssociation, AsciiStringReference listIdentifier = null)
            : this(new List<UsingDirectiveListAssociation> { usingDirectiveListAssociation }, listIdentifier)
        {
        }
        public UsingDirectiveList(Identifier usingDirective, AsciiStringReference listIdentifier = null)
            : this(new UsingDirectiveListAssociation(usingDirective), listIdentifier)
        {
        }
        public UsingDirectiveList(string usingDirective, AsciiStringReference listIdentifier = null)
            : this(new Identifier(usingDirective), listIdentifier)
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
                    .Select(s => s.UsingDirective.GetUsingDirectiveSyntax()));

        public List<UsingDirectiveListAssociation> GetAssociations() => UsingDirectiveListAssociations;

        public void SetRecords(List<UsingDirective> records)
        {
            UsingDirectiveListAssociations = UniqueListAssociationsFactory<UsingDirective, UsingDirectiveListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<UsingDirective>.Create(records, r => r.UsingDirectiveId));
        }
    }
}
