using Common.EntityFrameworkServices.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class DocumentationCommentAttributeListUpsertService<TDbContext> : UpsertService<TDbContext, DocumentationCommentAttributeList>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public DocumentationCommentAttributeListUpsertService(ICacheService<DocumentationCommentAttributeList> cache, TDbContext database, ILogger<UpsertService<TDbContext, DocumentationCommentAttributeList>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.DocumentationCommentAttributeLists)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Expression)}={record.ListIdentifierId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<DocumentationCommentAttributeList> AssignUpsertedReferences(DocumentationCommentAttributeList record)
        {
            record.ListIdentifier = await _strings.UpsertAsync(record.ListIdentifier);
            record.ListIdentifierId = record.ListIdentifier?.AsciiStringReferenceId ?? record.ListIdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(DocumentationCommentAttributeList record)
        {
            yield return record.DocumentationCommentAttributeListAssociations;
            yield return record.ListIdentifier;
        }

        protected override Expression<Func<DocumentationCommentAttributeList, bool>> FindExisting(DocumentationCommentAttributeList record)
            => existing => existing.ListIdentifierId == record.ListIdentifierId;
    }
}
