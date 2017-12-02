using Common.EntityFrameworkServices.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class ArgumentListUpsertService<TDbContext> : UpsertService<TDbContext, ArgumentList>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public ArgumentListUpsertService(ICacheService<ArgumentList> cache, TDbContext database, ILogger<UpsertService<TDbContext, ArgumentList>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.ArgumentLists)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Expression)}={record.ListIdentifierId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<ArgumentList> AssignUpsertedReferences(ArgumentList record)
        {
            record.ListIdentifier = await _strings.UpsertAsync(record.ListIdentifier);
            record.ListIdentifierId = record.ListIdentifier?.AsciiStringReferenceId ?? record.ListIdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ArgumentList record)
        {
            yield return record.ArgumentListAssociations;
            yield return record.ListIdentifier;
        }

        protected override Expression<Func<ArgumentList, bool>> FindExisting(ArgumentList record)
            => existing => existing.ListIdentifierId == record.ListIdentifierId;
    }
}
