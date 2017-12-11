using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
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
    [Table("AccessorLists", Schema = nameof(CSharp))]
    public class AccessorList : IUniqueList<Accessor, AccessorListAssociation>
    {
        public AccessorList() { }
        public AccessorList(List<AccessorListAssociation> accessorListAssociations, AsciiStringReference listIdentifier = null)
        {
            AccessorListAssociations = accessorListAssociations;
            ListIdentifier = listIdentifier;
        }
        public AccessorList(AccessorListAssociation accessorListAssociation, AsciiStringReference listIdentifier = null)
            : this(new List<AccessorListAssociation> { accessorListAssociation }, listIdentifier)
        {
        }
        public AccessorList(Accessor accessor, AsciiStringReference listIdentifier = null)
            : this(new AccessorListAssociation(accessor), listIdentifier)
        {
        }
        public AccessorList(SyntaxToken syntaxToken, AsciiStringReference listIdentifier = null)
            : this(new Accessor(syntaxToken), listIdentifier)
        {
        }
        public AccessorList(SyntaxKind syntaxKind, AsciiStringReference listIdentifier = null)
            : this(new SyntaxToken(syntaxKind), listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int AccessorListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<AccessorListAssociation> AccessorListAssociations { get; set; }

        public static AccessorList AutoGet => new AccessorList(SyntaxKind.GetAccessorDeclaration);
        public static AccessorList AutoGetSet => new AccessorList(new List<AccessorListAssociation>
        {
            new AccessorListAssociation(SyntaxKind.GetAccessorDeclaration),
            new AccessorListAssociation(SyntaxKind.SetAccessorDeclaration)
        });

        public AccessorListSyntax GetAccessorListSyntax()
            => AccessorListAssociations.Count == 1
            ? AccessorList(
                SingletonList(
                    AccessorListAssociations
                        .First()
                        .Accessor
                        .GetAccessorDeclarationSyntax()))
            : AccessorList(
                List(
                    AccessorListAssociations
                        .OrderBy(a => a.Accessor.SyntaxToken.SyntaxKind == SyntaxKind.GetAccessorDeclaration ? 0 : 1)
                        .Select(a => a.Accessor.GetAccessorDeclarationSyntax())));

        public List<AccessorListAssociation> GetAssociations() => AccessorListAssociations;

        public void SetRecords(List<Accessor> records)
        {
            AccessorListAssociations = UniqueListAssociationsFactory<Accessor, AccessorListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Accessor>.Create(records, r => r.AccessorId));
        }
    }
}
