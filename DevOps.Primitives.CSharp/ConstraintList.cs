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
    [Table("ConstraintLists", Schema = nameof(CSharp))]
    public class ConstraintList : IUniqueList<Constraint, ConstraintListAssociation>
    {
        public ConstraintList() { }
        public ConstraintList(List<ConstraintListAssociation> constraintListAssociations, AsciiStringReference listIdentifier = null)
        {
            ConstraintListAssociations = constraintListAssociations;
            ListIdentifier = listIdentifier;
        }
        public ConstraintList(ConstraintListAssociation argumentListAssociation, AsciiStringReference listIdentifier = null)
            : this(new List<ConstraintListAssociation> { argumentListAssociation }, listIdentifier)
        {
        }
        public ConstraintList(Constraint constraint, AsciiStringReference listIdentifier = null)
            : this(new ConstraintListAssociation(constraint), listIdentifier)
        {
        }
        public ConstraintList(Identifier constraint, AsciiStringReference listIdentifier = null)
            : this(new Constraint(constraint), listIdentifier)
        {
        }
        public ConstraintList(string constraint, AsciiStringReference listIdentifier = null)
            : this(new Identifier(constraint), listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int ConstraintListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<ConstraintListAssociation> ConstraintListAssociations { get; set; }

        public SeparatedSyntaxList<TypeParameterConstraintSyntax> GetConstraintList()
        {
            if (ConstraintListAssociations.Count == 1)
            {
                return SingletonSeparatedList(
                    ConstraintListAssociations
                        .First()
                        .Constraint
                        .GetTypeParameterConstraintSyntax());
            }
            var last = ConstraintListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    ConstraintListAssociations[i]
                        .Constraint
                        .GetTypeParameterConstraintSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return SeparatedList<TypeParameterConstraintSyntax>(list);
        }

        public List<ConstraintListAssociation> GetAssociations() => ConstraintListAssociations;

        public void SetRecords(List<Constraint> records)
        {
            ConstraintListAssociations = UniqueListAssociationsFactory<Constraint, ConstraintListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Constraint>.Create(records, r => r.ConstraintId));
        }
    }
}
