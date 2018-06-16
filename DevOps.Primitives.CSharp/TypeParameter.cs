using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("TypeParameters", Schema = nameof(CSharp))]
    public class TypeParameter : IUniqueListRecord
    {
        public TypeParameter() { }
        public TypeParameter(in Identifier identifier) { Identifier = identifier; }
        public TypeParameter(in string identifier) : this(new Identifier(in identifier)) { }

        [Key]
        [ProtoMember(1)]
        public int TypeParameterId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public TypeParameterSyntax GetTypeParameterSyntax()
            => TypeParameter(Identifier.GetSyntaxToken());
    }
}
