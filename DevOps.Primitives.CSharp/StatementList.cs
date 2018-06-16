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
        public StatementList() { }
        public StatementList(in List<StatementListAssociation> statementListAssociations, in AsciiStringReference listIdentifier = default)
        {
            StatementListAssociations = statementListAssociations;
            ListIdentifier = listIdentifier;
        }
        public StatementList(in StatementListAssociation statementListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<StatementListAssociation> { statementListAssociation }, in listIdentifier)
        {
        }
        public StatementList(in AsciiMaxStringReference statement, in AsciiStringReference listIdentifier = default)
            : this(new StatementListAssociation(in statement), in listIdentifier)
        {
        }
        public StatementList(in string statement, in AsciiStringReference listIdentifier = default)
            : this(new AsciiMaxStringReference(in statement), in listIdentifier)
        {
        }

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
            => List(StatementListAssociations.Select(s => s.Statement.GetStatementSyntax()));

        public List<StatementListAssociation> GetAssociations() => StatementListAssociations;

        public void SetRecords(in List<Statement> records)
        {
            StatementListAssociations = UniqueListAssociationsFactory<Statement, StatementListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Statement>.Create(in records, r => r.StatementId));
        }
    }
}
