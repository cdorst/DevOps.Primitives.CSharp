using Common.EntityFrameworkServices;
using DevOps.Abstractions.UniqueStrings;
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
            for (int i = 0; i < ConstraintClauseListAssociations.Count; i++)
            {
                ConstraintClauseListAssociations[i].SetRecord(records[i]);
            }
            ListIdentifier = new AsciiStringReference(
                string.Join(",", records.Select(r => r.ConstraintClauseId)));
        }
    }
}
