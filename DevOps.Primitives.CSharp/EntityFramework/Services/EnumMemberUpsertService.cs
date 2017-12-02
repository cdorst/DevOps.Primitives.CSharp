using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class EnumMemberUpsertService<TDbContext> : UpsertService<TDbContext, EnumMember>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertUniqueListService<TDbContext, DocumentationComment, DocumentationCommentList, DocumentationCommentListAssociation> _documentationComments;
        private readonly IUpsertService<TDbContext, Identifier> _identifiers;

        public EnumMemberUpsertService(ICacheService<EnumMember> cache, TDbContext database, ILogger<UpsertService<TDbContext, EnumMember>> logger, IUpsertService<TDbContext, Identifier> identifiers, IUpsertUniqueListService<TDbContext, DocumentationComment, DocumentationCommentList, DocumentationCommentListAssociation> documentationComments)
            : base(cache, database, logger, database.EnumMembers)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(EnumMember)}={record.EqualsValue}:{record.IdentifierId}:{record.DocumentationCommentListId}";
            _identifiers = identifiers ?? throw new ArgumentNullException(nameof(identifiers));
            _documentationComments = documentationComments ?? throw new ArgumentNullException(nameof(documentationComments));
        }

        protected override async Task<EnumMember> AssignUpsertedReferences(EnumMember record)
        {
            record.DocumentationCommentList = await _documentationComments.UpsertAsync(record.DocumentationCommentList);
            record.DocumentationCommentListId = record.DocumentationCommentList?.DocumentationCommentListId ?? record.DocumentationCommentListId;
            record.Identifier = await _identifiers.UpsertAsync(record.Identifier);
            record.IdentifierId = record.Identifier?.IdentifierId ?? record.IdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(EnumMember record)
        {
            yield return record.DocumentationCommentList;
            yield return record.Identifier;
        }

        protected override Expression<Func<EnumMember, bool>> FindExisting(EnumMember record)
            => existing
                => ((existing.EqualsValue == null && record.EqualsValue == null) || (existing.EqualsValue == record.EqualsValue))
                && existing.DocumentationCommentListId == record.DocumentationCommentListId
                && existing.IdentifierId == record.IdentifierId;
    }
}
