using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("MethodListAssociations", Schema = nameof(CSharp))]
    public class MethodListAssociation : IUniqueListAssociation<Method>
    {
        public MethodListAssociation() { }
        public MethodListAssociation(in Method method, in MethodList methodList = default)
        {
            Method = method;
            MethodList = methodList;
        }
        public MethodListAssociation(
            in Identifier identifier,
            in Identifier type,
            in ParameterList parameterList = default,
            in Expression arrowClauseExpression = default,
            in Block block = default,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributes = default,
            in MethodList methodList = default)
            : this(
                  new Method(in identifier, in type, in parameterList, in arrowClauseExpression, in block, in modifierList, in documentationCommentList, in attributes),
                  in methodList)
        {
        }
        public MethodListAssociation(
            in string identifier,
            in string type,
            in ParameterList parameterList = default,
            in Expression arrowClauseExpression = default,
            in Block block = default,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributes = default,
            in MethodList methodList = default)
            : this(
                  new Identifier(in identifier),
                  new Identifier(in type),
                  in parameterList,
                  in arrowClauseExpression,
                  in block,
                  in modifierList,
                  in documentationCommentList,
                  in attributes,
                  in methodList)
        {
        }
        public MethodListAssociation(
            in string identifier,
            in string type,
            in string arrowClauseExpression,
            in ParameterList parameterList = default,
            in ModifierList modifierList = default,
            in DocumentationCommentList documentationCommentList = default,
            in AttributeListCollection attributes = default,
            in MethodList methodList = default)
            : this(
                  new Identifier(in identifier),
                  new Identifier(in type),
                  in parameterList,
                  new Expression(in arrowClauseExpression),
                  block: null,
                  in modifierList,
                  in documentationCommentList,
                  in attributes,
                  in methodList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int MethodListAssociationId { get; set; }

        [ProtoMember(2)]
        public Method Method { get; set; }
        [ProtoMember(3)]
        public int MethodId { get; set; }

        [ProtoMember(4)]
        public MethodList MethodList { get; set; }
        [ProtoMember(5)]
        public int MethodListId { get; set; }

        public Method GetRecord() => Method;

        public void SetRecord(in Method record)
        {
            Method = record;
            MethodId = record.MethodId;
        }
    }
}
