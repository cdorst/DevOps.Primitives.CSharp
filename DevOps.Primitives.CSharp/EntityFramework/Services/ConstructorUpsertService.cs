using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class ConstructorUpsertService<TDbContext> : UpsertService<TDbContext, Constructor>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertUniqueListService<TDbContext, Attribute, AttributeListCollection, AttributeListCollectionAssociation> _attributeLists;
        private readonly IUpsertService<TDbContext, Block> _blocks;
        private readonly IUpsertService<TDbContext, ConstructorBaseInitializer> _constructorBaseInitializers;
        private readonly IUpsertUniqueListService<TDbContext, DocumentationComment, DocumentationCommentList, DocumentationCommentListAssociation> _documentationCommentLists;
        private readonly IUpsertService<TDbContext, Identifier> _identifiers;
        private readonly IUpsertUniqueListService<TDbContext, SyntaxToken, ModifierList, ModifierListAssociation> _modifierLists;
        private readonly IUpsertUniqueListService<TDbContext, Parameter, ParameterList, ParameterListAssociation> _parameterLists;

        public ConstructorUpsertService(ICacheService<Constructor> cache, TDbContext database, ILogger<UpsertService<TDbContext, Constructor>> logger,
            IUpsertUniqueListService<TDbContext, Attribute, AttributeListCollection, AttributeListCollectionAssociation> attributeLists,
            IUpsertService<TDbContext, Block> blocks,
            IUpsertService<TDbContext, ConstructorBaseInitializer> constructorBaseInitializers,
            IUpsertUniqueListService<TDbContext, DocumentationComment, DocumentationCommentList, DocumentationCommentListAssociation> documentationCommentLists,
            IUpsertService<TDbContext, Identifier> identifiers,
            IUpsertUniqueListService<TDbContext, SyntaxToken, ModifierList, ModifierListAssociation> modifierLists,
            IUpsertUniqueListService<TDbContext, Parameter, ParameterList, ParameterListAssociation> parameterLists)
            : base(cache, database, logger, database.Constructors)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Constructor)}={record.AttributeListCollectionId}:{record.BlockId}:{record.ConstructorBaseInitializerId}:{record.DocumentationCommentListId}:{record.IdentifierId}:{record.ModifierListId}:{record.ParameterListId}";
            _attributeLists = attributeLists ?? throw new ArgumentNullException(nameof(attributeLists));
            _blocks = blocks ?? throw new ArgumentNullException(nameof(blocks));
            _constructorBaseInitializers = constructorBaseInitializers ?? throw new ArgumentNullException(nameof(constructorBaseInitializers));
            _documentationCommentLists = documentationCommentLists ?? throw new ArgumentNullException(nameof(documentationCommentLists));
            _identifiers = identifiers ?? throw new ArgumentNullException(nameof(identifiers));
            _modifierLists = modifierLists ?? throw new ArgumentNullException(nameof(modifierLists));
            _parameterLists = parameterLists ?? throw new ArgumentNullException(nameof(parameterLists));
        }

        protected override async Task<Constructor> AssignUpsertedReferences(Constructor record)
        {
            record.AttributeListCollection = await _attributeLists.UpsertAsync(record.AttributeListCollection);
            record.AttributeListCollectionId = record.AttributeListCollection?.AttributeListCollectionId ?? record.AttributeListCollectionId;
            record.Block = await _blocks.UpsertAsync(record.Block);
            record.BlockId = record.Block?.BlockId ?? record.BlockId;
            record.ConstructorBaseInitializer = await _constructorBaseInitializers.UpsertAsync(record.ConstructorBaseInitializer);
            record.ConstructorBaseInitializerId = record.ConstructorBaseInitializer?.ConstructorBaseInitializerId ?? record.ConstructorBaseInitializerId;
            record.DocumentationCommentList = await _documentationCommentLists.UpsertAsync(record.DocumentationCommentList);
            record.DocumentationCommentListId = record.DocumentationCommentList?.DocumentationCommentListId ?? record.DocumentationCommentListId;
            record.Identifier = await _identifiers.UpsertAsync(record.Identifier);
            record.IdentifierId = record.Identifier?.IdentifierId ?? record.IdentifierId;
            record.ModifierList = await _modifierLists.UpsertAsync(record.ModifierList);
            record.ModifierListId = record.ModifierList?.ModifierListId ?? record.ModifierListId;
            record.ParameterList = await _parameterLists.UpsertAsync(record.ParameterList);
            record.ParameterListId = record.ParameterList?.ParameterListId ?? record.ParameterListId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Constructor record)
        {
            yield return record.AttributeListCollection;
            yield return record.Block;
            yield return record.ConstructorBaseInitializer;
            yield return record.DocumentationCommentList;
            yield return record.Identifier;
            yield return record.ModifierList;
            yield return record.ParameterList;
        }

        protected override Expression<Func<Constructor, bool>> FindExisting(Constructor record)
            => existing
                => ((existing.AttributeListCollectionId == null && record.AttributeListCollectionId == null) || (existing.AttributeListCollectionId == record.AttributeListCollectionId))
                && existing.BlockId == record.BlockId
                && ((existing.ConstructorBaseInitializerId == null && record.ConstructorBaseInitializerId == null) || (existing.ConstructorBaseInitializerId == record.ConstructorBaseInitializerId))
                && ((existing.DocumentationCommentListId == null && record.DocumentationCommentListId == null) || (existing.DocumentationCommentListId == record.DocumentationCommentListId))
                && existing.IdentifierId == record.IdentifierId
                && ((existing.ModifierListId == null && record.ModifierListId == null) || (existing.ModifierListId == record.ModifierListId))
                && ((existing.ParameterListId == null && record.ParameterListId == null) || (existing.ParameterListId == record.ParameterListId));
    }
}
