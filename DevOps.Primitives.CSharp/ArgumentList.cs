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
    [Table("ArgumentLists", Schema = nameof(CSharp))]
    public class ArgumentList : IUniqueList<Argument, ArgumentListAssociation>
    {
        public ArgumentList() { }
        public ArgumentList(in List<ArgumentListAssociation> argumentListAssociations, in AsciiStringReference listIdentifier = default)
        {
            ArgumentListAssociations = argumentListAssociations;
            ListIdentifier = listIdentifier;
        }
        public ArgumentList(in ArgumentListAssociation argumentListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<ArgumentListAssociation> { argumentListAssociation }, in listIdentifier)
        {
        }
        public ArgumentList(in Argument argument, in AsciiStringReference listIdentifier = default)
            : this(new ArgumentListAssociation(in argument), in listIdentifier)
        {
        }
        public ArgumentList(in Identifier argument, in AsciiStringReference listIdentifier = default)
            : this(new Argument(in argument), in listIdentifier)
        {
        }
        public ArgumentList(in string argument, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in argument), in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int ArgumentListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<ArgumentListAssociation> ArgumentListAssociations { get; set; }

        public ArgumentListSyntax GetArgumentListSyntax()
        {
            if (ArgumentListAssociations.Count == 1)
            {
                return ArgumentList(
                    SingletonSeparatedList(
                        ArgumentListAssociations
                            .First()
                            .Argument
                            .GetArgumentSyntax()));
            }
            var last = ArgumentListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    ArgumentListAssociations[i]
                        .Argument
                        .GetArgumentSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return ArgumentList(
                SeparatedList<ArgumentSyntax>(
                    list));
        }

        public List<ArgumentListAssociation> GetAssociations() => ArgumentListAssociations;

        public void SetRecords(in List<Argument> records)
        {
            ArgumentListAssociations = UniqueListAssociationsFactory<Argument, ArgumentListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Argument>.Create(in records, r => r.ArgumentId));
        }
    }
}
