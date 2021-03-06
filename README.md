# DevOps.Primitives.CSharp

Entity types for C# programming-language concepts

## Available on NuGet

[https://www.nuget.org/packages/CDorst.DevOps.Primitives.CSharp](https://www.nuget.org/packages/CDorst.DevOps.Primitives.CSharp/)

## Use Cases

This library enables meta-programming tasks for C# type declarations:
- Code generation
- Database storage (w/ EntityFrameworkCore)

## Usage Notes

Compose `TypeDeclaration` graphs using the following types:
- `ClassDeclaration`
- `EnumDeclaration`
- `InterfaceDeclaration`
- `StructDeclaration`

Invoke `ToString()` to generate a source-code document as `string`.

```csharp
var classDeclaration = new ClassDeclaration("TypeName", "Namespace");

var @namespace = classDeclaration.GetNamespace();
var fileName = classDeclaration.GetFileName();
var path = Path.Combine(
    /*Root*/ Environment.CurrentDirectory,
    /*Path*/ Path.Combine(@namespace.Split('.')),
    /*File*/ fileName);
var csharpCodeDocument = classDeclartion.ToString();
File.WriteAllText(path, csharpCodeDocument);
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

