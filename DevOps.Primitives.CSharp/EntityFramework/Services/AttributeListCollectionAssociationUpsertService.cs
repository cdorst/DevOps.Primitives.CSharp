using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class AttributeListCollectionAssociationUpsertService<TDbContext> : UpsertService<TDbContext, AttributeListCollectionAssociation>
        where TDbContext : CSharpDbContext
    {
        public AttributeListCollectionAssociationUpsertService(ICacheService<AttributeListCollectionAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, AttributeListCollectionAssociation>> logger)
            : base(cache, database, logger, database.AttributeListCollectionAssociations)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(AttributeListCollectionAssociation)}={record.AttributeId}:{record.AttributeListCollectionId}";
        }

        protected override IEnumerable<object> EnumerateReferences(AttributeListCollectionAssociation record)
        {
            yield return record.Attribute;
            yield return record.AttributeListCollection;
        }

        protected override Expression<Func<AttributeListCollectionAssociation, bool>> FindExisting(AttributeListCollectionAssociation record)
            => existing
                => existing.AttributeId == record.AttributeId
                && existing.AttributeListCollectionId == record.AttributeListCollectionId;
    }
}
