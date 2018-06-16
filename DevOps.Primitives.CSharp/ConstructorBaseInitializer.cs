using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("ConstructorBaseInitializers", Schema = nameof(CSharp))]
    public class ConstructorBaseInitializer
    {
        public ConstructorBaseInitializer() { }
        public ConstructorBaseInitializer(in ArgumentList argumentList, in SyntaxKind kind = SyntaxKind.BaseConstructorInitializer)
        {
            ArgumentList = argumentList;
            Kind = kind;
        }

        [Key]
        [ProtoMember(1)]
        public int ConstructorBaseInitializerId { get; set; }

        [ProtoMember(2)]
        public ArgumentList ArgumentList { get; set; }
        [ProtoMember(3)]
        public int ArgumentListId { get; set; }

        [ProtoMember(4)]
        public SyntaxKind Kind { get; set; }

        public ConstructorInitializerSyntax GetConstructorInitializerSyntax()
            => ConstructorInitializer(Kind,
                ArgumentList.GetArgumentListSyntax());
    }
}
