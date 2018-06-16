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
    [Table("UsingDirectives", Schema = nameof(CSharp))]
    public class UsingDirective : IUniqueListRecord
    {
        public UsingDirective() { }
        public UsingDirective(in Identifier identifier) { Identifier = identifier; }
        public UsingDirective(in string identifier) : this(new Identifier(in identifier)) { }

        [Key]
        [ProtoMember(1)]
        public int UsingDirectiveId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        [ProtoMember(4)]
        public bool UsingStatic { get; set; }

        public UsingDirectiveSyntax GetUsingDirectiveSyntax()
            => !UsingStatic
            ? GetUsing()
            : GetUsing().WithStaticKeyword(
                Token(SyntaxKind.StaticKeyword));

        private UsingDirectiveSyntax GetUsing()
            => UsingDirective(Identifier.GetNameSyntax());
    }
}
