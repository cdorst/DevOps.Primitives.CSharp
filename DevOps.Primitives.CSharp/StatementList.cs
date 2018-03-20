﻿using Common.EntityFrameworkServices;
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
        public StatementList(List<StatementListAssociation> statementListAssociations, AsciiStringReference listIdentifier = null)
        {
            StatementListAssociations = statementListAssociations;
            ListIdentifier = listIdentifier;
        }
        public StatementList(StatementListAssociation statementListAssociation, AsciiStringReference listIdentifier = null)
            : this(new List<StatementListAssociation> { statementListAssociation }, listIdentifier)
        {
        }
        public StatementList(AsciiMaxStringReference statement, AsciiStringReference listIdentifier = null)
            : this(new StatementListAssociation(statement), listIdentifier)
        {
        }
        public StatementList(string statement, AsciiStringReference listIdentifier = null)
            : this(new AsciiMaxStringReference(statement), listIdentifier)
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

        public void SetRecords(List<Statement> records)
        {
            StatementListAssociations = UniqueListAssociationsFactory<Statement, StatementListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<Statement>.Create(records, r => r.StatementId));
        }
    }
}
