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
    [Table("Constraints", Schema = nameof(CSharp))]
    public class Constraint : IUniqueListRecord
    {
        public Constraint() { }
        public Constraint(in Identifier identifier) { Identifier = identifier; }
        public Constraint(in string identifier) : this(new Identifier(in identifier)) { }

        [Key]
        [ProtoMember(1)]
        public int ConstraintId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public TypeParameterConstraintSyntax GetTypeParameterConstraintSyntax()
            => Identifier.Name.Value == "class"
            ? ClassOrStructConstraint(SyntaxKind.ClassConstraint)
            : Identifier.Name.Value == "struct"
            ? ClassOrStructConstraint(SyntaxKind.StructConstraint)
            : (TypeParameterConstraintSyntax)TypeConstraint(
                Identifier.GetIdentifierNameSyntax());
    }
}
