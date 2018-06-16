using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using DevOps.Primitives.Strings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("BaseLists", Schema = nameof(CSharp))]
    public class BaseList : IUniqueList<BaseType, BaseListAssociation>
    {
        public BaseList() { }
        public BaseList(in List<BaseListAssociation> baseListAssociations, in AsciiStringReference listIdentifier = default)
        {
            BaseListAssociations = baseListAssociations;
            ListIdentifier = listIdentifier;
        }
        public BaseList(in BaseListAssociation baseListAssociation, in AsciiStringReference listIdentifier = default)
            : this(new List<BaseListAssociation> { baseListAssociation }, in listIdentifier)
        {
        }
        public BaseList(in Identifier baseType, in AsciiStringReference listIdentifier = default)
            : this(new BaseListAssociation(in baseType), in listIdentifier)
        {
        }
        public BaseList(in string baseType, in AsciiStringReference listIdentifier = default)
            : this(new Identifier(in baseType), in listIdentifier)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int BaseListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<BaseListAssociation> BaseListAssociations { get; set; }

        public BaseListSyntax GetBaseListSyntax()
        {
            if (BaseListAssociations.Count == 1)
            {
                return BaseList(
                    SingletonSeparatedList<BaseTypeSyntax>(
                        BaseListAssociations
                            .First()
                            .BaseType
                            .GetSimpleBaseTypeSyntax()));
            }
            var last = BaseListAssociations.Count - 1;
            var list = new List<SyntaxNodeOrToken>();
            for (int i = 0; i < last + 1; i++)
            {
                list.Add(
                    BaseListAssociations[i]
                        .BaseType
                        .GetSimpleBaseTypeSyntax());
                if (i != last) list.Add(Token(SyntaxKind.CommaToken));
            }
            return BaseList(
                SeparatedList<BaseTypeSyntax>(
                    list));
        }

        public List<BaseListAssociation> GetAssociations() => BaseListAssociations;

        public void SetRecords(in List<BaseType> records)
        {
            BaseListAssociations = UniqueListAssociationsFactory<BaseType, BaseListAssociation>.Create(in records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<BaseType>.Create(in records, r => r.BaseTypeId));
        }
    }
}
