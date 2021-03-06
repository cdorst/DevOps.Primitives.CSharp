﻿using Common.EntityFrameworkServices;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DevOps.Primitives.CSharp
{
    [ProtoContract]
    [Table("Accessors", Schema = nameof(CSharp))]
    public class Accessor : IUniqueListRecord
    {
        public Accessor() { }
        public Accessor(in SyntaxToken syntaxToken)
        {
            SyntaxToken = syntaxToken;
        }
        public Accessor(in SyntaxKind syntaxKind)
            : this(new SyntaxToken(in syntaxKind))
        {
        }
        public Accessor(in SyntaxToken syntaxToken, in Block block, in ModifierList modifierList = default)
            : this(in syntaxToken)
        {
            Body = block;
            ModifierList = modifierList;
        }
        public Accessor(in SyntaxKind syntaxKind, in Block block, in ModifierList modifierList = default)
            : this(new SyntaxToken(in syntaxKind), in block, in modifierList)
        {
        }
        public Accessor(in SyntaxToken syntaxToken, in Expression arrowClauseExpression, in ModifierList modifierList = default)
            : this(in syntaxToken)
        {
            ArrowClauseExpressionBody = arrowClauseExpression;
            ModifierList = modifierList;
        }
        public Accessor(in SyntaxKind syntaxKind, in Expression arrowClauseExpression, in ModifierList modifierList = default)
            : this(new SyntaxToken(in syntaxKind), in arrowClauseExpression, in modifierList)
        {
        }

        [Key]
        [ProtoMember(1)]
        public int AccessorId { get; set; }

        [ProtoMember(2)]
        public Expression ArrowClauseExpressionBody { get; set; }
        [ProtoMember(3)]
        public int? ArrowClauseExpressionBodyId { get; set; }

        [ProtoMember(4)]
        public Block Body { get; set; }
        [ProtoMember(5)]
        public int? BodyId { get; set; }

        [ProtoMember(6)]
        public ModifierList ModifierList { get; set; }
        [ProtoMember(7)]
        public byte? ModifierListId { get; set; }

        [ProtoMember(8)]
        public SyntaxToken SyntaxToken { get; set; }
        [ProtoMember(9)]
        public short SyntaxTokenId { get; set; }

        public AccessorDeclarationSyntax GetAccessorDeclarationSyntax()
        {
            var accessor = AccessorDeclaration(
                SyntaxToken.SyntaxKind);
            if (ModifierList != null) accessor = accessor.WithModifiers(ModifierList.GetSyntaxTokenList());
            if (Body != null) return accessor.WithBody(Body.GetBlockSyntax());
            if (ArrowClauseExpressionBody != null)
                accessor = accessor.WithExpressionBody(ArrowClauseExpressionBody.GetArrowExpressionClauseSyntax());
            return accessor.WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
        }
    }
}
