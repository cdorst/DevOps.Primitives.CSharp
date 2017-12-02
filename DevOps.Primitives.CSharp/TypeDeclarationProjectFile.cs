using DevOps.Abstractions.SourceCode.Solutions;
using ProtoBuf;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    public class TypeDeclarationProjectFile : ProjectFile
    {
        public TypeDeclarationProjectFile() { }
        public TypeDeclarationProjectFile(TypeDeclaration typeDeclaration, Project project) : base(project,
            fileContent: typeDeclaration.ToString(),
            fileName: $"{typeDeclaration.Identifier.Name.Value}.cs",
            pathRelativeToProject: NamespacePathResolver.GetPath(
                project.GetNamespace(),
                typeDeclaration.GetNamespace()))
        {
        }

        [ProtoMember(6)]
        public TypeDeclaration TypeDeclaration { get; set; }
        [ProtoMember(7)]
        public int TypeDeclarationId { get; set; }
    }
}
