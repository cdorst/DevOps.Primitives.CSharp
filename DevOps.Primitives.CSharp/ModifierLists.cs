using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp
{
    public static class ModifierLists
    {
        public static readonly ModifierList Internal = new ModifierList(SyntaxKind.InternalKeyword);
        public static readonly ModifierList InternalAbstract = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static readonly ModifierList InternalAbstractAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList InternalAbstractOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList InternalAbstractOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList InternalAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList InternalConst = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static readonly ModifierList InternalDelegate = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static readonly ModifierList InternalEvent = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static readonly ModifierList InternalOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList InternalOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList InternalReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList InternalSealed = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static readonly ModifierList InternalSealedOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList InternalStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList InternalStaticAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList InternalStaticExtern = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static readonly ModifierList InternalStaticReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList InternalUnsafeStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList InternalVirtual = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static readonly ModifierList InternalVirtualAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList InternalVolatile = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static readonly ModifierList Private = new ModifierList(SyntaxKind.PrivateKeyword);
        public static readonly ModifierList PrivateAbstract = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static readonly ModifierList PrivateAbstractAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PrivateAbstractOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList PrivateAbstractOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PrivateAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PrivateConst = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static readonly ModifierList PrivateDelegate = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static readonly ModifierList PrivateEvent = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static readonly ModifierList PrivateOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList PrivateOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PrivateReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList PrivateSealed = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static readonly ModifierList PrivateSealedOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList PrivateStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList PrivateStaticAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PrivateStaticExtern = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static readonly ModifierList PrivateStaticReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList PrivateUnsafeStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList PrivateVirtual = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static readonly ModifierList PrivateVirtualAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PrivateVolatile = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static readonly ModifierList Protected = new ModifierList(SyntaxKind.ProtectedKeyword);
        public static readonly ModifierList ProtectedAbstract = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static readonly ModifierList ProtectedAbstractAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedAbstractOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList ProtectedAbstractOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedConst = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static readonly ModifierList ProtectedDelegate = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static readonly ModifierList ProtectedEvent = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static readonly ModifierList ProtectedOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList ProtectedOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList ProtectedSealed = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static readonly ModifierList ProtectedSealedOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList ProtectedStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList ProtectedStaticAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedStaticExtern = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static readonly ModifierList ProtectedStaticReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList ProtectedUnsafeStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList ProtectedVirtual = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static readonly ModifierList ProtectedVirtualAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedVolatile = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static readonly ModifierList ProtectedInternal = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword)
        });
        public static readonly ModifierList ProtectedInternalAbstract = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static readonly ModifierList ProtectedInternalAbstractAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedInternalAbstractOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList ProtectedInternalAbstractOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedInternalAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedInternalConst = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static readonly ModifierList ProtectedInternalDelegate = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static readonly ModifierList ProtectedInternalEvent = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static readonly ModifierList ProtectedInternalOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList ProtectedInternalOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedInternalReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList ProtectedInternalSealed = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static readonly ModifierList ProtectedInternalSealedOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList ProtectedInternalStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList ProtectedInternalStaticAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedInternalStaticExtern = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static readonly ModifierList ProtectedInternalStaticReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList ProtectedInternalUnsafeStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList ProtectedInternalVirtual = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static readonly ModifierList ProtectedInternalVirtualAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList ProtectedInternalVolatile = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static readonly ModifierList Public = new ModifierList(SyntaxKind.PublicKeyword);
        public static readonly ModifierList PublicAbstract = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static readonly ModifierList PublicAbstractAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PublicAbstractOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList PublicAbstractOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PublicAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PublicConst = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static readonly ModifierList PublicDelegate = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static readonly ModifierList PublicEvent = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static readonly ModifierList PublicOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList PublicOverrideAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PublicReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList PublicSealed = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static readonly ModifierList PublicSealedOverride = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static readonly ModifierList PublicStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList PublicStaticAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PublicStaticExtern = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static readonly ModifierList PublicStaticReadonly = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static readonly ModifierList PublicUnsafeStatic = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static readonly ModifierList PublicVirtual = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static readonly ModifierList PublicVirtualAsync = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static readonly ModifierList PublicVolatile = new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
    }
}
