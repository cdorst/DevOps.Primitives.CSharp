using Common.EntityFrameworkServices.Services;
using DevOps.Primitives.Strings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class StatementUpsertService<TDbContext> : UpsertService<TDbContext, Statement>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiMaxStringReference> _strings;

        public StatementUpsertService(ICacheService<Statement> cache, TDbContext database, ILogger<UpsertService<TDbContext, Statement>> logger, IUpsertService<TDbContext, AsciiMaxStringReference> strings)
            : base(cache, database, logger, database.Statements)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Statement)}={record.TextId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<Statement> AssignUpsertedReferences(Statement record)
        {
            record.Text = await _strings.UpsertAsync(record.Text);
            record.TextId = record.Text?.AsciiMaxStringReferenceId ?? record.TextId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Statement record)
        {
            yield return record.Text;
        }

        protected override Expression<Func<Statement, bool>> FindExisting(Statement record)
            => existing => existing.TextId == record.TextId;
    }
}
