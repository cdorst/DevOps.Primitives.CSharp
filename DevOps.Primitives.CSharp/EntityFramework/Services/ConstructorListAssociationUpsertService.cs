using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class ConstructorListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, ConstructorListAssociation>
        where TDbContext : CSharpDbContext
    {
        public ConstructorListAssociationUpsertService(ICacheService<ConstructorListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, ConstructorListAssociation>> logger)
            : base(cache, database, logger, database.ConstructorListAssociations)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(ConstructorListAssociation)}={record.ConstructorId}:{record.ConstructorListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(ConstructorListAssociation record)
        {
            yield return record.Constructor;
            yield return record.ConstructorList;
        }

        protected override Expression<Func<ConstructorListAssociation, bool>> FindExisting(ConstructorListAssociation record)
            => existing
                => existing.ConstructorId == record.ConstructorId
                && existing.ConstructorListId == record.ConstructorListId;
    }
}
