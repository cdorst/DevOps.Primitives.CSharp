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
    [Table("TypeParameterLists", Schema = nameof(CSharp))]
    public class TypeParameterList : IUniqueList<TypeParameter, TypeParameterListAssociation>
    {
        public TypeParameterList() { }
        public TypeParameterList(in List<TypeParameterListAssociation> typeParameterListAssociations, in AsciiStringReference listIdentifier = default)
        {
            TypeParameterListAssociations = typeParameterListAssociations;
            ListIdentifier = listIdentifier;
        }
        public TypeParameterList(in TypeParameterListAssociation typeParameterListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<TypeParameterListAssociation> { typeParameterListAssociation }, in listIdentifier)
        {
        }
        public TypeParameterList(in Identifier typeParameter, in AsciiStringReference listIdentifier = default)
            : this(new TypeParameterListAssociation(typeParameter), listIdentifier)
        {
        }
        public TypeParameterList(in string typeParameter, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in typeParameter), in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int TypeParameterListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<TypeParameterListAssociation> TypeParameterListAssociations { get; set; }

        public TypeParameterListSyntax GetTypeParameterListSyntax()
        {
            if (TypeParameterListAssociations.Count == 1)
            {
                return TypeParameterList(
                    SingletonSeparatedList(
                        TypeParameterListAssociations
                            .First()
                            .TypeParameter
                            .GetTypeParameterSyntax()));
            }
            var last = TypeParameterListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    TypeParameterListAssociations[i]
                        .TypeParameter
                        .GetTypeParameterSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return TypeParameterList(
                SeparatedList<TypeParameterSyntax>(
                    list));
        }

        public List<TypeParameterListAssociation> GetAssociations() => TypeParameterListAssociations;

        public void SetRecords(in List<TypeParameter> records)
        {
            TypeParameterListAssociations = UniqueListAssociationsFactory<TypeParameter, TypeParameterListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<TypeParameter>.Create(in records, r => r.TypeParameterId));
        }
    }
}
