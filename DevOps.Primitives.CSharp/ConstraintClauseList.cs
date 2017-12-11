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
    [Table("ConstraintClauseLists", Schema = nameof(CSharp))]
    public class ConstraintClauseList : IUniqueList<ConstraintClause, ConstraintClauseListAssociation>
    {
        public ConstraintClauseList() { }
        public ConstraintClauseList(List<ConstraintClauseListAssociation> constraintClauseListAssociations, AsciiStringReference listIdentifier = null)
        {
            ConstraintClauseListAssociations = constraintClauseListAssociations;
            ListIdentifier = listIdentifier;
        }
        public ConstraintClauseList(ConstraintClauseListAssociation constraintClauseListAssociations, AsciiStringReference listIdentifier = null)
            : this(new List<ConstraintClauseListAssociation> { constraintClauseListAssociations }, listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int ConstraintClauseListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<ConstraintClauseListAssociation> ConstraintClauseListAssociations { get; set; }

        public SyntaxList<TypeParameterConstraintClauseSyntax> GetConstraintClauses()
            => ConstraintClauseListAssociations.Count == 1
            ? SingletonList(
                ConstraintClauseListAssociations
                    .First()
                    .ConstraintClause
                    .GetTypeParameterConstraintClauseSyntax())
            : List(
                ConstraintClauseListAssociations
                    .Select(c => c.ConstraintClause.GetTypeParameterConstraintClauseSyntax()));

        public List<ConstraintClauseListAssociation> GetAssociations() => ConstraintClauseListAssociations;

        public void SetRecords(List<ConstraintClause> records)
        {
            ConstraintClauseListAssociations = UniqueListAssociationsFactory<ConstraintClause, ConstraintClauseListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<ConstraintClause>.Create(records, r => r.ConstraintClauseId));
        }
    }
}
