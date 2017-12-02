using Common.EntityFrameworkServices;
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
        [Key]
        [ProtoMember(1)]
        public int AccessorListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<AccessorListAssociation> AccessorListAssociations { get; set; }

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
            for (int i = 0; i < AccessorListAssociations.Count; i++)
            {
                AccessorListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.AccessorId)));
        }
    }
}
