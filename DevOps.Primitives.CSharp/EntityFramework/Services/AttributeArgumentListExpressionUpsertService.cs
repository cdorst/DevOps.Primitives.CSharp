using Common.EntityFrameworkServices.Services;
using DevOps.Abstractions.UniqueStrings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class AttributeArgumentListExpressionUpsertService<TDbContext> : UpsertService<TDbContext, AttributeArgumentListExpression>
        where TDbContext : SourceCodeTypeDeclarationsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiMaxStringReference> _strings;

        public AttributeArgumentListExpressionUpsertService(ICacheService<AttributeArgumentListExpression> cache, TDbContext database, ILogger<UpsertService<TDbContext, AttributeArgumentListExpression>> logger, IUpsertService<TDbContext, AsciiMaxStringReference> strings)
            : base(cache, database, logger, database.AttributeArgumentListExpressions)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(AttributeArgumentListExpression)}={record.ExpressionId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<AttributeArgumentListExpression> AssignUpsertedReferences(AttributeArgumentListExpression record)
        {
            record.Expression = await _strings.UpsertAsync(record.Expression);
            record.ExpressionId = record.Expression?.AsciiMaxStringReferenceId ?? record.ExpressionId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(AttributeArgumentListExpression record)
        {
            yield return record.Expression;
        }

        protected override Expression<Func<AttributeArgumentListExpression, bool>> FindExisting(AttributeArgumentListExpression record)
            => existing => existing.ExpressionId == record.ExpressionId;
    }
}
