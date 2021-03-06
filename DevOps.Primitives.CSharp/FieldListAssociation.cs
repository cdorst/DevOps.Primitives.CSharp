﻿using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("FieldListAssociations", Schema = nameof(CSharp))]
    public class FieldListAssociation : IUniqueListAssociation<Field>
    {
        public FieldListAssociation() { }
        public FieldListAssociation(in Field field, in FieldList fieldList = default)
        {
            Field = field;
            FieldList = fieldList;
        }

        [Key]
        [ProtoMember(1)]
        public int FieldListAssociationId { get; set; }

        [ProtoMember(2)]
        public Field Field { get; set; }
        [ProtoMember(3)]
        public int FieldId { get; set; }

        [ProtoMember(4)]
        public FieldList FieldList { get; set; }
        [ProtoMember(5)]
        public int FieldListId { get; set; }

        public Field GetRecord() => Field;

        public void SetRecord(in Field record)
        {
            Field = record;
            FieldId = record.FieldId;
        }
    }
}
