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
    [Table("ParameterLists", Schema = nameof(CSharp))]
    public class ParameterList : IUniqueList<Parameter, ParameterListAssociation>
    {
        public ParameterList() { }
        public ParameterList(in List<ParameterListAssociation> parameterListAssociations, in AsciiStringReference listIdentifier = default)
        {
            ParameterListAssociations = parameterListAssociations;
            ListIdentifier = listIdentifier;
        }
        public ParameterList(in ParameterListAssociation parameterListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<ParameterListAssociation> { parameterListAssociation }, in listIdentifier)
        {
        }
        public ParameterList(in Identifier identifier, in Identifier type, in Expression defaultValue = default, in AsciiStringReference listIdentifier = default)
            : this(new ParameterListAssociation(in identifier, in type, in defaultValue), in listIdentifier)
        {
        }
        public ParameterList(in string identifier, in string type, in Expression defaultValue = default, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in identifier), new Identifier(in type), in defaultValue, in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int ParameterListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<ParameterListAssociation> ParameterListAssociations { get; set; }

        public ParameterListSyntax GetParameterListSyntax()
        {
            if (ParameterListAssociations.Count == 1)
            {
                return ParameterList(
                    SingletonSeparatedList(
                        ParameterListAssociations
                            .First()
                            .Parameter
                            .GetParameterSyntax()));
            }
            var last = ParameterListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    ParameterListAssociations[i]
                        .Parameter
                        .GetParameterSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return ParameterList(
                SeparatedList<ParameterSyntax>(
                    list));
        }

        public List<ParameterListAssociation> GetAssociations() => ParameterListAssociations;

        public void SetRecords(in List<Parameter> records)
        {
            ParameterListAssociations = UniqueListAssociationsFactory<Parameter, ParameterListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Parameter>.Create(in records, r => r.ParameterId));
        }
    }
}
