using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Namespaces", Schema = nameof(CSharp))]
    public class Namespace
    {
        public Namespace() { }
        public Namespace(Identifier identifier) { Identifier = identifier; }
        public Namespace(string identifier) : this(new Identifier(identifier)) { }

        [Key]
        [ProtoMember(1)]
        public int NamespaceId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public NamespaceDeclarationSyntax GetNamespaceDeclaration(SyntaxNode typeDeclaration)
            => NamespaceDeclaration(Identifier.GetNameSyntax())
                .WithMembers(SingletonList(typeDeclaration));
    }
}
