using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class AttributeUpsertService<TDbContext> : UpsertService<TDbContext, Attribute>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertService<TDbContext, AttributeArgumentListExpression> _attributeArgumentListExpressions;
        private readonly IUpsertService<TDbContext, Identifier> _identifiers;

        public AttributeUpsertService(ICacheService<Attribute> cache, TDbContext database, ILogger<UpsertService<TDbContext, Attribute>> logger, IUpsertService<TDbContext, AttributeArgumentListExpression> attributeArgumentListExpressions, IUpsertService<TDbContext, Identifier> identifiers)
            : base(cache, database, logger, database.Attributes)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Attribute)}={record.AttributeArgumentListExpressionId}:{record.IdentifierId}";
            _attributeArgumentListExpressions = attributeArgumentListExpressions ?? throw new ArgumentNullException(nameof(attributeArgumentListExpressions));
            _identifiers = identifiers ?? throw new ArgumentNullException(nameof(identifiers));
        }

        protected override async Task<Attribute> AssignUpsertedReferences(Attribute record)
        {
            record.AttributeArgumentListExpression = await _attributeArgumentListExpressions.UpsertAsync(record.AttributeArgumentListExpression);
            record.AttributeArgumentListExpressionId = record.AttributeArgumentListExpression?.AttributeArgumentListExpressionId ?? record.AttributeArgumentListExpressionId;
            record.Identifier = await _identifiers.UpsertAsync(record.Identifier);
            record.IdentifierId = record.Identifier?.IdentifierId ?? record.IdentifierId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Attribute record)
        {
            yield return record.AttributeArgumentListExpression;
            yield return record.Identifier;
        }

        protected override Expression<Func<Attribute, bool>> FindExisting(Attribute record)
            => existing
                => ((existing.AttributeArgumentListExpressionId == null && record.AttributeArgumentListExpressionId == null) || (existing.AttributeArgumentListExpressionId == record.AttributeArgumentListExpressionId))
                && existing.IdentifierId == record.IdentifierId;
    }
}
