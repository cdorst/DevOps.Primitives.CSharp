using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("BaseTypes", Schema = nameof(CSharp))]
    public class BaseType : IUniqueListRecord
    {
        public BaseType() { }
        public BaseType(in Identifier identifier, in TypeArgumentList typeArgumentList = default)
        {
            Identifier = identifier;
            TypeArgumentList = typeArgumentList;
        }
        public BaseType(in string identifier, in TypeArgumentList typeArgumentList = default)
            : this(new Identifier(in identifier), in typeArgumentList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int BaseTypeId { get; set; }

        [ProtoMember(2)]
        public Identifier Identifier { get; set; }
        [ProtoMember(3)]
        public int IdentifierId { get; set; }

        [ProtoMember(4)]
        public TypeArgumentList TypeArgumentList { get; set; }
        [ProtoMember(5)]
        public int? TypeArgumentListId { get; set; }

        public SimpleBaseTypeSyntax GetSimpleBaseTypeSyntax()
            => TypeArgumentList == null
            ? SimpleBaseType(
                ParseTypeName(Identifier.Name.Value))
            : SimpleBaseType(
                GenericName(
                    Identifier.GetSyntaxToken())
                .WithTypeArgumentList(
                    TypeArgumentList.GetTypeArgumentListSyntax()));
    }
}
