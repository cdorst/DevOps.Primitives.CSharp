using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class ConstructorBaseInitializerUpsertService<TDbContext> : UpsertService<TDbContext, ConstructorBaseInitializer>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertUniqueListService<TDbContext, Argument, ArgumentList, ArgumentListAssociation> _argumentLists;

        public ConstructorBaseInitializerUpsertService(ICacheService<ConstructorBaseInitializer> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConstructorBaseInitializer>> logger, IUpsertUniqueListService<TDbContext, Argument, ArgumentList, ArgumentListAssociation> argumentLists)
            : base(cache, database, logger, database.ConstructorBaseInitializers)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(ConstructorBaseInitializer)}={record.ArgumentListId}";
            _argumentLists = argumentLists ?? throw new ArgumentNullException(nameof(argumentLists));
        }

        protected override async Task<ConstructorBaseInitializer> AssignUpsertedReferences(ConstructorBaseInitializer record)
        {
            record.ArgumentList = await _argumentLists.UpsertAsync(record.ArgumentList);
            record.ArgumentListId = record.ArgumentList?.ArgumentListId ?? record.ArgumentListId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(ConstructorBaseInitializer record)
        {
            yield return record.ArgumentList;
        }

        protected override Expression<Func<ConstructorBaseInitializer, bool>> FindExisting(ConstructorBaseInitializer record)
            => existing => existing.ArgumentListId == record.ArgumentListId;
    }
}
