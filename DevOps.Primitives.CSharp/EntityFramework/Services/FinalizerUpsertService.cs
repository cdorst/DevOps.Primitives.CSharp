using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class FinalizerUpsertService<TDbContext> : UpsertService<TDbContext, Finalizer>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertService<TDbContext, Block> _blocks;
        private readonly IUpsertService<TDbContext, Identifier> _identifiers;

        public FinalizerUpsertService(ICacheService<Finalizer> cache, TDbContext database, ILogger<UpsertService<TDbContext, Finalizer>> logger, IUpsertService<TDbContext, Block> blocks, IUpsertService<TDbContext, Identifier> identifiers)
            : base(cache, database, logger, database.Finalizers)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Finalizer)}={record.BlockId}:{record.IdentifierId}";
            _blocks = blocks ?? throw new ArgumentNullException(nameof(blocks));
            _identifiers = identifiers ?? throw new ArgumentNullException(nameof(identifiers));
        }

        protected override async Task<Finalizer> AssignUpsertedReferences(Finalizer record)
        {
            record.Block = await _blocks.UpsertAsync(record.Block);
            record.BlockId = record.Block?.BlockId ?? record.BlockId;
            record.Identifier = await _identifiers.UpsertAsync(record.Identifier);
            record.IdentifierId = record.Identifier?.IdentifierId ?? record.IdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Finalizer record)
        {
            yield return record.Block;
            yield return record.Identifier;
        }

        protected override Expression<Func<Finalizer, bool>> FindExisting(Finalizer record)
            => existing
                => existing.BlockId == record.BlockId
                && existing.IdentifierId == record.IdentifierId;
    }
}
