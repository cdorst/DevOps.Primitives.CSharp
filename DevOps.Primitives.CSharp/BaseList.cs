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
        public BaseList(List<BaseListAssociation> baseListAssociations, AsciiStringReference listIdentifier = null)
        {
            BaseListAssociations = baseListAssociations;
            ListIdentifier = listIdentifier;
        }
        public BaseList(BaseListAssociation baseListAssociation, AsciiStringReference listIdentifier = null)
            : this(new List<BaseListAssociation> { baseListAssociation }, listIdentifier)
        {
        }
        public BaseList(Identifier baseType, AsciiStringReference listIdentifier = null)
            : this(new BaseListAssociation(baseType), listIdentifier)
        {
        }
        public BaseList(string baseType, AsciiStringReference listIdentifier = null)
            : this(new Identifier(baseType), listIdentifier)
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

        public void SetRecords(List<BaseType> records)
        {
            BaseListAssociations = UniqueListAssociationsFactory<BaseType, BaseListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<BaseType>.Create(records, r => r.BaseTypeId));
        }
    }
}
