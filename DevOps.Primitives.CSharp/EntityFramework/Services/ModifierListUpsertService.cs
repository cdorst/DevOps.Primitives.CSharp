using Common.EntityFrameworkServices;
using DevOps.Primitives.Strings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class ModifierListUpsertService<TDbContext> : UpsertService<TDbContext, ModifierList>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public ModifierListUpsertService(ICacheService<ModifierList> cache, TDbContext database, ILogger<UpsertService<TDbContext, ModifierList>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.ModifierLists)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Expression)}={record.ListIdentifierId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<ModifierList> AssignUpsertedReferences(ModifierList record)
        {
            record.ListIdentifier = await _strings.UpsertAsync(record.ListIdentifier);
            record.ListIdentifierId = record.ListIdentifier?.AsciiStringReferenceId ?? record.ListIdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ModifierList record)
        {
            yield return record.ModifierListAssociations;
            yield return record.ListIdentifier;
        }

        protected override Expression<Func<ModifierList, bool>> FindExisting(ModifierList record)
            => existing => existing.ListIdentifierId == record.ListIdentifierId;
    }
}
