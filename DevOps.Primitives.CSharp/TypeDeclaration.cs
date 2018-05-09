using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    // https://github.com/mgravell/protobuf-net#inheritance
    [ProtoInclude(96, typeof(ClassDeclaration))]
    [ProtoInclude(97, typeof(EnumDeclaration))]
    [ProtoInclude(98, typeof(InterfaceDeclaration))]
    [ProtoInclude(99, typeof(StructDeclaration))]
    [Table("TypeDeclarations", Schema = nameof(CSharp))]
    public class TypeDeclaration
    {
        public TypeDeclaration() { }
        public TypeDeclaration(
            Identifier identifier,
            Namespace _namespace,
            ModifierList modifierList = null,
            UsingDirectiveList usingDirectiveList = null,
            DocumentationCommentList documentationCommentList = null,
            AttributeListCollection attributeListCollection = null,
            TypeParameterList typeParameterList = null,
            ConstraintClauseList constraintClauseList = null,
            BaseList baseList = null,
            ConstructorList constructorList = null,
            FieldList fieldList = null,
            MethodList methodList = null,
            PropertyList propertyList = null)
        {
            Identifier = identifier;
            Namespace = _namespace;
            ModifierList = modifierList;
            UsingDirectiveList = usingDirectiveList;
            DocumentationCommentList = documentationCommentList;
            AttributeListCollection = attributeListCollection;
            TypeParameterList = typeParameterList;
            ConstraintClauseList = constraintClauseList;
            BaseList = baseList;
            ConstructorList = constructorList;
            FieldList = fieldList;
            MethodList = methodList;
            PropertyList = propertyList;
        }

        public TypeDeclaration(
            string identifier,
            string @namespace,
            ModifierList modifierList = null,
            UsingDirectiveList usingDirectiveList = null,
            DocumentationCommentList documentationCommentList = null,
            AttributeListCollection attributeListCollection = null,
            TypeParameterList typeParameterList = null,
            ConstraintClauseList constraintClauseList = null,
            BaseList baseList = null,
            ConstructorList constructorList = null,
            FieldList fieldList = null,
            MethodList methodList = null,
            PropertyList propertyList = null)
            : this(
                  new Identifier(identifier),
                  new Namespace(@namespace),
                  modifierList,
                  usingDirectiveList,
                  documentationCommentList,
                  attributeListCollection,
                  typeParameterList,
                  constraintClauseList,
                  baseList,
                  constructorList,
                  fieldList,
                  methodList,
                  propertyList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int TypeDeclarationId { get; set; }

        [ProtoMember(2)]
        public AttributeListCollection AttributeListCollection { get; set; }
        [ProtoMember(3)]
        public int? AttributeListCollectionId { get; set; }

        [ProtoMember(4)]
        public BaseList BaseList { get; set; }
        [ProtoMember(5)]
        public int? BaseListId { get; set; }

        [ProtoMember(6)]
        public ConstraintClauseList ConstraintClauseList { get; set; }
        [ProtoMember(7)]
        public int? ConstraintClauseListId { get; set; }

        [ProtoMember(8)]
        public ConstructorList ConstructorList { get; set; }
        [ProtoMember(9)]
        public int? ConstructorListId { get; set; }

        [ProtoMember(10)]
        public DocumentationCommentList DocumentationCommentList { get; set; }
        [ProtoMember(11)]
        public int? DocumentationCommentListId { get; set; }

        [ProtoMember(12)]
        public FieldList FieldList { get; set; }
        [ProtoMember(13)]
        public int? FieldListId { get; set; }

        [ProtoMember(14)]
        public Identifier Identifier { get; set; }
        [ProtoMember(15)]
        public int IdentifierId { get; set; }

        [ProtoMember(16)]
        public MethodList MethodList { get; set; }
        [ProtoMember(17)]
        public int? MethodListId { get; set; }

        [ProtoMember(18)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(19)]
        public byte? ModifierListId { get; set; }

        [ProtoMember(20)]
        public Namespace Namespace { get; set; }
        [ProtoMember(21)]
        public int NamespaceId { get; set; }

        [ProtoMember(22)]
        public PropertyList PropertyList { get; set; }
        [ProtoMember(23)]
        public int? PropertyListId { get; set; }

        [ProtoMember(24)]
        public TypeParameterList TypeParameterList { get; set; }
        [ProtoMember(25)]
        public int? TypeParameterListId { get; set; }

        [ProtoMember(26)]
        public UsingDirectiveList UsingDirectiveList { get; set; }
        [ProtoMember(27)]
        public int? UsingDirectiveListId { get; set; }

        public CompilationUnitSyntax GetCompilationUnitSyntax()
        {
            var compilationUnit = CompilationUnit();
            if (UsingDirectiveList != null)
            {
                compilationUnit = compilationUnit.WithUsings(
                    UsingDirectiveList.GetUsingDirectiveListSyntax());
            }
            return compilationUnit.WithMembers(
                SingletonList<MemberDeclarationSyntax>(
                    Namespace.GetNamespaceDeclaration(
                        GetTypeDeclarationSyntax())));
        }

        public string GetFileName()
            => string.Concat(GetTypeName(), ".cs");

        public string GetNamespace()
            => Namespace.Identifier.Name.Value;

        public string GetTypeName()
            => Identifier.ToString();

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                GetFormattedSyntaxNode().WriteTo(stringWriter);
            }
            return stringBuilder.AppendLine().ToString();
        }

        protected virtual BaseTypeDeclarationSyntax GetTypeDeclarationSyntax()
            => default(BaseTypeDeclarationSyntax);

        private SyntaxNode GetFormattedSyntaxNode()
            => Formatter.Format(
                GetCompilationUnitSyntax(),
                new AdhocWorkspace());
    }
}
