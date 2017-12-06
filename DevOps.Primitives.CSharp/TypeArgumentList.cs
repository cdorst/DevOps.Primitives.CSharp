using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis;
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
    [Table("TypeArgumentLists", Schema = nameof(CSharp))]
    public class TypeArgumentList : IUniqueList<TypeArgument, TypeArgumentListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int TypeArgumentListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<TypeArgumentListAssociation> TypeArgumentListAssociations { get; set; }

        public TypeArgumentListSyntax GetTypeArgumentListSyntax()
        {
            if (TypeArgumentListAssociations.Count == 1)
            {
                return TypeArgumentList(
                    SingletonSeparatedList<TypeSyntax>(
                        TypeArgumentListAssociations
                            .First()
                            .TypeArgument
                            .Identifier
                            .GetIdentifierNameSyntax()));
            }
            var last = TypeArgumentListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    TypeArgumentListAssociations[i]
                        .TypeArgument
                        .Identifier
                        .GetIdentifierNameSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return TypeArgumentList(
                SeparatedList<TypeSyntax>(
                    list));
        }

        public List<TypeArgumentListAssociation> GetAssociations() => TypeArgumentListAssociations;

        public void SetRecords(List<TypeArgument> records)
        {
            TypeArgumentListAssociations = UniqueListAssociationsFactory<TypeArgument, TypeArgumentListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<TypeArgument>.Create(records, r => r.TypeArgumentId));
        }
    }
}
