using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class ModifierListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, ModifierListAssociation>
        where TDbContext : CSharpDbContext
    {
        public ModifierListAssociationUpsertService(ICacheService<ModifierListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, ModifierListAssociation>> logger)
            : base(cache, database, logger, database.ModifierListAssociations)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(ModifierListAssociation)}={record.SyntaxTokenId}:{record.ModifierListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(ModifierListAssociation record)
        {
            yield return record.SyntaxToken;
            yield return record.ModifierList;
        }

        protected override Expression<Func<ModifierListAssociation, bool>> FindExisting(ModifierListAssociation record)
            => existing
                => existing.SyntaxTokenId == record.SyntaxTokenId
                && existing.ModifierListId == record.ModifierListId;
    }
}
