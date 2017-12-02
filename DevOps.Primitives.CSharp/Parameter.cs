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
            return parameter;
        }
    }
}
