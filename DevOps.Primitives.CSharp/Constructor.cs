using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Constructors", Schema = nameof(CSharp))]
    public class Constructor : ISortableMemberDeclaration, IUniqueListRecord
    {
        public Constructor() { }
        public Constructor(
            in Identifier identifier,
            in Block block,
            in ModifierList modifierList = default,
            in ParameterList parameterList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in ConstructorBaseInitializer constructorBaseInitializer = default)
        {
            AttributeListCollection = attributeListCollection;
            Block = block;
            ConstructorBaseInitializer = constructorBaseInitializer;
            DocumentationCommentList = documentationCommentList;
            Identifier = identifier;
            ModifierList = modifierList;
            ParameterList = parameterList;
        }
        public Constructor(
            in string identifier,
            in Block block,
            in ModifierList modifierList = default,
            in ParameterList parameterList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributeListCollection = default,
            in ConstructorBaseInitializer constructorBaseInitializer = default)
            : this(new Identifier(in identifier), in block, in modifierList, in parameterList, in documentationCommentList, in attributeListCollection, in constructorBaseInitializer)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int ConstructorId { get; set; }

        [ProtoMember(2)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(3)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(4)]
        public Block Block { get; set; }
        [ProtoMember(5)]
        public int BlockId { get; set; }

        [ProtoMember(6)]
        public ConstructorBaseInitializer ConstructorBaseInitializer { get; set; }
        [ProtoMember(7)]
        public int? ConstructorBaseInitializerId { get; set; }

        [ProtoMember(8)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(9)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(10)]
        public Identifier Identifier { get; set; }
        [ProtoMember(11)]
        public int IdentifierId { get; set; }

        [ProtoMember(12)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(13)]
        public byte? ModifierListId { get; set; }

        [ProtoMember(14)]
        public ParameterList ParameterList { get; set; }
        [ProtoMember(15)]
        public int? ParameterListId { get; set; }

        public MemberDeclarationSyntax GetMemberDeclarationSyntax()
        {
            var hasAttributes = AttributeListCollection != null;
            var hasModifiers = ModifierList != null;
            var declaration = ConstructorDeclaration(
                Identifier.GetSyntaxToken((!hasAttributes && !hasModifiers) ? DocumentationCommentList : null));
            if (hasAttributes)
            {
                declaration = declaration.WithAttributeLists(
                    AttributeListCollection.GetAttributeListSyntaxList(DocumentationCommentList));
            }
            if (hasModifiers)
            {
                declaration = declaration.WithModifiers(
                    ModifierList.GetSyntaxTokenList(hasAttributes ? null : DocumentationCommentList));
            }
            if (ConstructorBaseInitializer != null)
            {
                declaration = declaration.WithInitializer(
                    ConstructorBaseInitializer.GetConstructorInitializerSyntax());
            }
            if (ParameterList != null)
            {
                declaration = declaration.WithParameterList(
                    ParameterList.GetParameterListSyntax());
            }
            return declaration.WithBody(Block.GetBlockSyntax());
        }
    }
}
