using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class AccessorUpsertService<TDbContext> : UpsertService<TDbContext, Accessor>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertService<TDbContext, Block> _blocks;
        private readonly IUpsertService<TDbContext, Expression> _expressions;
        private readonly IUpsertUniqueListService<TDbContext, SyntaxToken, ModifierList, ModifierListAssociation> _modifierLists;
        private readonly IUpsertService<TDbContext, SyntaxToken> _syntaxTokens;

        public AccessorUpsertService(ICacheService<Accessor> cache, TDbContext database, ILogger<UpsertService<TDbContext, Accessor>> logger, IUpsertService<TDbContext, Block> blocks, IUpsertService<TDbContext, Expression> expressions, IUpsertUniqueListService<TDbContext, SyntaxToken, ModifierList, ModifierListAssociation> modifierLists, IUpsertService<TDbContext, SyntaxToken> syntaxTokens)
            : base(cache, database, logger, database.Accessors)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Accessor)}={record.ArrowClauseExpressionBodyId}:{record.BodyId}:{record.ModifierListId}:{record.SyntaxTokenId}";
            _blocks = blocks ?? throw new ArgumentNullException(nameof(blocks));
            _expressions = expressions ?? throw new ArgumentNullException(nameof(expressions));
            _modifierLists = modifierLists ?? throw new ArgumentNullException(nameof(modifierLists));
            _syntaxTokens = syntaxTokens ?? throw new ArgumentNullException(nameof(syntaxTokens));
        }

        protected override async Task<Accessor> AssignUpsertedReferences(Accessor record)
        {
            record.ArrowClauseExpressionBody = await _expressions.UpsertAsync(record.ArrowClauseExpressionBody);
            record.ArrowClauseExpressionBodyId = record.ArrowClauseExpressionBody?.ExpressionId ?? record.ArrowClauseExpressionBodyId;
            record.Body = await _blocks.UpsertAsync(record.Body);
            record.BodyId = record.Body?.BlockId ?? record.BodyId;
            record.ModifierList = await _modifierLists.UpsertAsync(record.ModifierList);
            record.ModifierListId = record.ModifierList?.ModifierListId ?? record.ModifierListId;
            record.SyntaxToken = await _syntaxTokens.UpsertAsync(record.SyntaxToken);
            record.SyntaxTokenId = record.SyntaxToken?.SyntaxTokenId ?? record.SyntaxTokenId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Accessor record)
        {
            yield return record.ArrowClauseExpressionBody;
            yield return record.Body;
            yield return record.ModifierList;
            yield return record.SyntaxToken;
        }

        protected override Expression<Func<Accessor, bool>> FindExisting(Accessor record)
            => existing
                => ((existing.ArrowClauseExpressionBodyId == null && record.ArrowClauseExpressionBodyId == null) || (existing.ArrowClauseExpressionBodyId == record.ArrowClauseExpressionBodyId))
                && ((existing.BodyId == null && record.BodyId == null) || (existing.BodyId == record.BodyId))
                && ((existing.ModifierListId == null && record.ModifierListId == null) || (existing.ModifierListId == record.ModifierListId))
                && existing.SyntaxTokenId == record.SyntaxTokenId;
    }
}
