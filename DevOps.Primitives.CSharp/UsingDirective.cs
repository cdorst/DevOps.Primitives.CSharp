using Common.EntityFrameworkServices;
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
        [Key]
        [ProtoMember(1)]
        public int UsingDirectiveId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        public UsingDirectiveSyntax GetUsingDirectiveSyntax()
            => UsingDirective(Identifier.GetNameSyntax());
    }
}
