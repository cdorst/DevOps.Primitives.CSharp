using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
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
        public Parameter(in Identifier identifier, in Identifier type, in Expression defaultValue = default, in AttributeListCollection attributeListCollection = default, in bool useThisModifier = false)
        {
            AttributeListCollection = attributeListCollection;
            DefaultValue = defaultValue;
            Identifier = identifier;
            Type = type;
            UseThisModifier = useThisModifier;
        }
        public Parameter(in string identifier, in string type, in Expression defaultValue = default, in AttributeListCollection attributeListCollection = default, in bool useThisModifier = false)
            : this(new Identifier(in identifier), new Identifier(in type), in defaultValue, in attributeListCollection, in useThisModifier)
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
        public bool? UseThisModifier { get; set; }

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
            if (UseThisModifier ?? false)
            {
                parameter = parameter.WithModifiers(
                    TokenList(
                        Token(SyntaxKind.ThisKeyword)));
            }
            return parameter;
        }
    }
}
