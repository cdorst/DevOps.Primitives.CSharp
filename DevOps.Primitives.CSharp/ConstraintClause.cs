using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ConstraintClauses", Schema = nameof(CSharp))]
    public class ConstraintClause : IUniqueListRecord
    {
        public ConstraintClause() { }
        public ConstraintClause(in Identifier identifier, in ConstraintList constraintList)
        {
            Identifier = identifier;
            ConstraintList = constraintList;
        }
        public ConstraintClause(in string identifier, in ConstraintList constraintList)
            : this(new Identifier(in identifier), in constraintList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int ConstraintClauseId { get; set; }

        [ProtoMember(2)]
        public ConstraintList ConstraintList { get; set; }
        [ProtoMember(3)]
        public int ConstraintListId { get; set; }

        [ProtoMember(4)]
        public Identifier Identifier { get; set; }
        [ProtoMember(5)]
        public int IdentifierId { get; set; }

        public TypeParameterConstraintClauseSyntax GetTypeParameterConstraintClauseSyntax()
            => TypeParameterConstraintClause(
                Identifier.GetIdentifierNameSyntax())
                .WithConstraints(
                    ConstraintList.GetConstraintList());
    }
}
