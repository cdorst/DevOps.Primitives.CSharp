# DevOps.Primitives.CSharp

Represents C#-language concepts as C# entity types

## Available on NuGet

[https://www.nuget.org/packages/CDorst.DevOps.Primitives.CSharp](https://www.nuget.org/packages/CDorst.DevOps.Primitives.CSharp/)

## Use Cases

This library enables meta-programming tasks for C# type declarations:
- Code generation
- Database storage (w/ EntityFrameworkCore)

## Usage Notes

Compose your `TypeDeclaration` graphs using the following derived types:
- `ClassDeclaration`
- `EnumDeclaration`
- `InterfaceDeclaration`
- `StructDeclaration`

Invoke `ToString()` to generate a source-code document as `string`.

```csharp
var classDeclaration = new ClassDeclaration("TypeName", "Namespace");

var @namespace = classDeclaration.GetNamespace();
var name = classDeclaration.GetName();
var csharpCodeDocument = classDeclartion.ToString();
File.WriteAllText(Path.Combine(
    /*Path*/ Path.Combine(@namespace.Split('.')),
    /*File*/ string.Concat(name, ".cs")),
    /*Text*/ csharpCodeDocument);
```

Invoke `GetCompilationUnitSyntax()` to generate a `Microsoft.CodeAnalysis.CSharp` ("Roslyn") syntax tree.
```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

var classDeclaration = new ClassDeclaration("TypeName", "Namespace");
CompilationUnitSyntax compilationUnit = classDeclaration.GetCompilationUnitSyntax();
SyntaxNode formattedSyntax = Formatter.Format(compilationUnit, new AdhocWorkspace());
```

