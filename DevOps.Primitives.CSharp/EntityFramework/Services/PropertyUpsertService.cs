using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.CSharp.EntityFramework.Services
{
    public class PropertyUpsertService<TDbContext> : UpsertService<TDbContext, Property>
        where TDbContext : CSharpDbContext
    {
        private readonly IUpsertUniqueListService<TDbContext, Accessor, AccessorList, AccessorListAssociation> _accessorLists;
        private readonly IUpsertUniqueListService<TDbContext, Attribute, AttributeListCollection, AttributeListCollectionAssociation> _attributeLists;
        private readonly IUpsertUniqueListService<TDbContext, DocumentationComment, DocumentationCommentList, DocumentationCommentListAssociation> _documentationCommentLists;
        private readonly IUpsertService<TDbContext, Identifier> _identifiers;
        private readonly IUpsertUniqueListService<TDbContext, SyntaxToken, ModifierList, ModifierListAssociation> _modifierLists;

        public PropertyUpsertService(ICacheService<Property> cache, TDbContext database, ILogger<UpsertService<TDbContext, Property>> logger,
            IUpsertUniqueListService<TDbContext, Accessor, AccessorList, AccessorListAssociation> accessorLists,
            IUpsertUniqueListService<TDbContext, Attribute, AttributeListCollection, AttributeListCollectionAssociation> attributeLists,
            IUpsertService<TDbContext, Block> blocks,
            IUpsertUniqueListService<TDbContext, DocumentationComment, DocumentationCommentList, DocumentationCommentListAssociation> documentationCommentLists,
            IUpsertService<TDbContext, Expression> expressions,
            IUpsertService<TDbContext, Identifier> identifiers,
            IUpsertUniqueListService<TDbContext, SyntaxToken, ModifierList, ModifierListAssociation> modifierLists,
            IUpsertUniqueListService<TDbContext, Parameter, ParameterList, ParameterListAssociation> parameterLists,
            IUpsertUniqueListService<TDbContext, TypeParameter, TypeParameterList, TypeParameterListAssociation> typeParameterLists)
            : base(cache, database, logger, database.Properties)
        {
            CacheKey = record => $"{nameof(CSharp)}.{nameof(Property)}={record.AccessorListId}:{record.AttributeListCollectionId}:{record.DocumentationCommentListId}:{record.IdentifierId}:{record.ModifierListId}:{record.TypeId}";
            _accessorLists = accessorLists ?? throw new ArgumentNullException(nameof(accessorLists));
            _attributeLists = attributeLists ?? throw new ArgumentNullException(nameof(attributeLists));
            _documentationCommentLists = documentationCommentLists ?? throw new ArgumentNullException(nameof(documentationCommentLists));
            _identifiers = identifiers ?? throw new ArgumentNullException(nameof(identifiers));
            _modifierLists = modifierLists ?? throw new ArgumentNullException(nameof(modifierLists));
        }

        protected override async Task<Property> AssignUpsertedReferences(Property record)
        {
            record.AccessorList = await _accessorLists.UpsertAsync(record.AccessorList);
            record.AccessorListId = record.AccessorList?.AccessorListId ?? record.AccessorListId;
            record.AttributeListCollection = await _attributeLists.UpsertAsync(record.AttributeListCollection);
            record.AttributeListCollectionId = record.AttributeListCollection?.AttributeListCollectionId ?? record.AttributeListCollectionId;
            record.DocumentationCommentList = await _documentationCommentLists.UpsertAsync(record.DocumentationCommentList);
            record.DocumentationCommentListId = record.DocumentationCommentList?.DocumentationCommentListId ?? record.DocumentationCommentListId;
            record.Identifier = await _identifiers.UpsertAsync(record.Identifier);
            record.IdentifierId = record.Identifier?.IdentifierId ?? record.IdentifierId;
            record.ModifierList = await _modifierLists.UpsertAsync(record.ModifierList);
            record.ModifierListId = record.ModifierList?.ModifierListId ?? record.ModifierListId;
            record.Type = await _identifiers.UpsertAsync(record.Type);
            record.TypeId = record.Type?.IdentifierId ?? record.TypeId;
            return record;
        }

        protected override IEnumerable<object> EnumerateReferences(Property record)
        {
            yield return record.AccessorList;
            yield return record.AttributeListCollection;
            yield return record.DocumentationCommentList;
            yield return record.Identifier;
            yield return record.ModifierList;
            yield return record.Type;
        }

        protected override Expression<Func<Property, bool>> FindExisting(Property record)
            => existing
                => existing.AccessorListId == record.AccessorListId
                && ((existing.AttributeListCollectionId == null && record.AttributeListCollectionId == null) || (existing.AttributeListCollectionId == record.AttributeListCollectionId))
                && ((existing.DocumentationCommentListId == null && record.DocumentationCommentListId == null) || (existing.DocumentationCommentListId == record.DocumentationCommentListId))
                && existing.IdentifierId == record.IdentifierId
                && ((existing.ModifierListId == null && record.ModifierListId == null) || (existing.ModifierListId == record.ModifierListId))
                && existing.TypeId == record.TypeId;
    }
}
