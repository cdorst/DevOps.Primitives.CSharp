using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class EnumMemberListAssociationUpsertService<TDbContext> : UpsertService<TDbContext, EnumMemberListAssociation>
        where TDbContext : CSharpDbContext
    {
        public EnumMemberListAssociationUpsertService(ICacheService<EnumMemberListAssociation> cache, TDbContext database, ILogger<UpsertService<TDbContext, EnumMemberListAssociation>> logger)
            : base(cache, database, logger, database.EnumMemberListAssociations)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(EnumMemberListAssociation)}={record.EnumMemberId}:{record.EnumMemberListId}";
        }

        protected override IEnumerable<object> EnumerateReferences(EnumMemberListAssociation record)
        {
            yield return record.EnumMember;
            yield return record.EnumMemberList;
        }

        protected override Expression<Func<EnumMemberListAssociation, bool>> FindExisting(EnumMemberListAssociation record)
            => existing
                => existing.EnumMemberId == record.EnumMemberId
                && existing.EnumMemberListId == record.EnumMemberListId;
    }
}
