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
    [Table("StatementLists", Schema = nameof(CSharp))]
    public class StatementList : IUniqueList<Statement, StatementListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int StatementListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<StatementListAssociation> StatementListAssociations { get; set; }

        public SyntaxList<StatementSyntax> GetStatementListSyntax()
            => StatementListAssociations.Count == 1
            ? SingletonList(
                StatementListAssociations
                    .First()
                    .Statement
                    .GetStatementSyntax())
            : List(
                StatementListAssociations
                    .Select(s => s.Statement.GetStatementSyntax()));

        public List<StatementListAssociation> GetAssociations() => StatementListAssociations;

        public void SetRecords(List<Statement> records)
        {
            StatementListAssociations = UniqueListAssociationsFactory<Statement, StatementListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Statement>.Create(records, r => r.StatementId));
        }
    }
}
