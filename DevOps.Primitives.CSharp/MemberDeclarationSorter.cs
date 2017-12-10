using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp
{
    public static class MemberDeclarationSorter
    {
        public static IEnumerable<MemberDeclarationSyntax> Sort(IEnumerable<ISortableMemberDeclaration> declarations)
        {
            var ranked = Rank(declarations);
            return ranked
                .OrderBy(r => r.Item2)
                .ThenBy(r => r.Item1.Identifier.Name.Value)
                .Select(r => r.Item1.GetMemberDeclarationSyntax());
        }

        private static IEnumerable<Tuple<ISortableMemberDeclaration, byte>> Rank(IEnumerable<ISortableMemberDeclaration> declarations)
        {
            foreach (var declaration in declarations)
            {
                var modifiers = new HashSet<SyntaxKind>(
                    declaration.ModifierList?.ModifierListAssociations.Select(m => m.SyntaxToken.SyntaxKind)
                    ?? new SyntaxKind[] { SyntaxKind.PrivateKeyword });
                var rank = GetRankValue(modifiers);
                yield return new Tuple<ISortableMemberDeclaration, byte>(declaration, rank);
            }
        }

        /// <summary>
        /// Returns an integer indicating rank. Based on rules from https://stackoverflow.com/a/310967
        /// </summary>
        private static byte GetRankValue(HashSet<SyntaxKind> modifiers)
        {
            var isConstant = modifiers.Contains(SyntaxKind.ConstKeyword);
            var isInternal = modifiers.Contains(SyntaxKind.InternalKeyword);
            var isReadOnly = modifiers.Contains(SyntaxKind.ReadOnlyKeyword);
            var isProtected = modifiers.Contains(SyntaxKind.ProtectedKeyword);
            var isStatic = modifiers.Contains(SyntaxKind.StaticKeyword);
            var rank = 0;
            if (modifiers.Contains(SyntaxKind.PublicKeyword))
            {
                if (isStatic) rank = isReadOnly ? 0 : 1;
                else rank = isReadOnly ? 2 : 3;
            }
            else if (isInternal && !isProtected)
            {
                if (isStatic) rank = isReadOnly ? 4 : 5;
                else rank = isReadOnly ? 6 : 7;
            }
            else if (isProtected && isInternal)
            {
                if (isStatic) rank = isReadOnly ? 8 : 9;
                else rank = isReadOnly ? 10 : 11;
            }
            else if (isProtected)
            {
                if (isStatic) rank = isReadOnly ? 12 : 13;
                else rank = isReadOnly ? 14 : 15;
            }
            else
            {
                if (isStatic) rank = isReadOnly ? 16 : 17;
                else rank = isReadOnly ? 18 : 19;
            }
            if (isConstant) rank = rank - 20; // Sort const fields above non-const fields
            return unchecked((byte)rank);
        }
    }
}
