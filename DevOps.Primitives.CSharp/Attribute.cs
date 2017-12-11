using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Attributes", Schema = nameof(CSharp))]
    public class Attribute : IUniqueListRecord
    {
        public Attribute() { }
        public Attribute(Identifier identifier, AttributeArgumentListExpression argumentListExpression = null)
        {
            Identifier = identifier;
            AttributeArgumentListExpression = argumentListExpression;
        }
        public Attribute(string identifier, string argumentListExpression = null)
            : this(new Identifier(identifier), string.IsNullOrEmpty(argumentListExpression) ? null : new AttributeArgumentListExpression(argumentListExpression))
        {
        }

        [Key]
        [ProtoMember(1)]
        public int AttributeId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        [ProtoMember(4)]
        public AttributeArgumentListExpression AttributeArgumentListExpression { get; set; }
        [ProtoMember(5)]
        public int? AttributeArgumentListExpressionId { get; set; }

        public AttributeSyntax GetAttributeSyntax()
            => AttributeArgumentListExpression != null
                ? Attribute(Identifier.GetNameSyntax(), AttributeArgumentListExpression.GetAttributeArgumentListSyntax())
                : Attribute(Identifier.GetNameSyntax());
    }
}
