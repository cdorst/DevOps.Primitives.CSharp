using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("TypeParameterListAssociations", Schema = nameof(CSharp))]
    public class TypeParameterListAssociation : IUniqueListAssociation<TypeParameter>
    {
        [Key]
        [ProtoMember(1)]
        public int TypeParameterListAssociationId { get; set; }

        [ProtoMember(2)]
        public TypeParameter TypeParameter { get; set; }
        [ProtoMember(3)]
        public int TypeParameterId { get; set; }

        [ProtoMember(4)]
        public TypeParameterList TypeParameterList { get; set; }
        [ProtoMember(5)]
        public int TypeParameterListId { get; set; }

        public TypeParameter GetRecord() => TypeParameter;

        public void SetRecord(TypeParameter record)
        {
            TypeParameter = record;
            TypeParameterId = TypeParameter.TypeParameterId;
        }
    }
}
