using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Parameters", Schema = nameof(CSharp))]
    public class Parameter : IUniqueListRecord
    {
        public Parameter() { }
        public Parameter(
            in Identifier identifier,
            in Identifier type,
            in Expression defaultValue = default,
            in AttributeListCollection attributeListCollection = default,
            in SyntaxToken modifier = default)
        {
            AttributeListCollection = attributeListCollection;
            DefaultValue = defaultValue;
            Identifier = identifier;
            Type = type;
            Modifier = modifier;
        }
        public Parameter(
            in string identifier,
            in string type,
            in Expression defaultValue = default,
            in AttributeListCollection attributeListCollection = default,
            in SyntaxToken modifier = default)
            : this(
                  new Identifier(in identifier),
                  new Identifier(in type),
                  in defaultValue,
                  in attributeListCollection,
                  in modifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int ParameterId { get; set; }

        [ProtoMember(2)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(3)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(4)]
        public Expression DefaultValue { get; set; }
        [ProtoMember(5)]
        public int? DefaultValueId { get; set; }

        [ProtoMember(6)]
        public Identifier Identifier { get; set; }
        [ProtoMember(7)]
        public int IdentifierId { get; set; }

        [ProtoMember(8)]
        public Identifier Type { get; set; }
        [ProtoMember(9)]
        public int TypeId { get; set; }

        [ProtoMember(10)]
        public SyntaxToken Modifier { get; set; }
        [ProtoMember(11)]
        public short? ModifierId { get; set; }

        public ParameterSyntax GetParameterSyntax()
        {
            var parameter = Parameter(
                Identifier.GetSyntaxToken())
                .WithType(
                    Type.GetTypeSyntax());
            if (AttributeListCollection != null)
            {
                parameter = parameter.WithAttributeLists(
                    AttributeListCollection.GetAttributeListSyntaxList());
            }
            if (DefaultValue != null)
            {
                parameter = parameter.WithDefault(
                    EqualsValueClause(
                        DefaultValue.GetExpressionSyntax()));
            }
            if (Modifier != null)
            {
                parameter = parameter.WithModifiers(
                    TokenList(
                        Token(Modifier.SyntaxKind)));
            }
            return parameter;
        }
    }
}
