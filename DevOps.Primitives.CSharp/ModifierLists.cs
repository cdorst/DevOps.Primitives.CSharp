using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp
{
    public static class ModifierLists
    {
        public static ModifierList Internal => new ModifierList(SyntaxKind.InternalKeyword);
        public static ModifierList InternalAbstract => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static ModifierList InternalAbstractAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList InternalAbstractOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList InternalAbstractOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList InternalAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList InternalConst => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static ModifierList InternalDelegate => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static ModifierList InternalEvent => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static ModifierList InternalOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList InternalOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList InternalReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList InternalSealed => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static ModifierList InternalSealedOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList InternalStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList InternalStaticAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList InternalStaticExtern => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static ModifierList InternalStaticReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList InternalUnsafeStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList InternalVirtual => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static ModifierList InternalVirtualAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList InternalVolatile => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static ModifierList Private => new ModifierList(SyntaxKind.PrivateKeyword);
        public static ModifierList PrivateAbstract => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static ModifierList PrivateAbstractAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateAbstractOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PrivateAbstractOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateConst => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static ModifierList PrivateDelegate => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static ModifierList PrivateEvent => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static ModifierList PrivateOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PrivateOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PrivateSealed => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static ModifierList PrivateSealedOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PrivateStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList PrivateStaticAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateStaticExtern => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static ModifierList PrivateStaticReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PrivateUnsafeStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList PrivateVirtual => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static ModifierList PrivateVirtualAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PrivateVolatile => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PrivateKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static ModifierList Protected => new ModifierList(SyntaxKind.ProtectedKeyword);
        public static ModifierList ProtectedAbstract => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static ModifierList ProtectedAbstractAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedAbstractOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList ProtectedAbstractOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedConst => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static ModifierList ProtectedDelegate => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static ModifierList ProtectedEvent => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static ModifierList ProtectedOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList ProtectedOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList ProtectedSealed => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static ModifierList ProtectedSealedOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList ProtectedStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList ProtectedStaticAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedStaticExtern => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static ModifierList ProtectedStaticReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList ProtectedUnsafeStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList ProtectedVirtual => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static ModifierList ProtectedVirtualAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedVolatile => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static ModifierList ProtectedInternal => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword)
        });
        public static ModifierList ProtectedInternalAbstract => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static ModifierList ProtectedInternalAbstractAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedInternalAbstractOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList ProtectedInternalAbstractOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedInternalAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedInternalConst => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static ModifierList ProtectedInternalDelegate => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static ModifierList ProtectedInternalEvent => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static ModifierList ProtectedInternalOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList ProtectedInternalOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedInternalReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList ProtectedInternalSealed => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static ModifierList ProtectedInternalSealedOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList ProtectedInternalStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList ProtectedInternalStaticAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedInternalStaticExtern => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static ModifierList ProtectedInternalStaticReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList ProtectedInternalUnsafeStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList ProtectedInternalVirtual => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static ModifierList ProtectedInternalVirtualAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList ProtectedInternalVolatile => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.ProtectedKeyword),
            new ModifierListAssociation(SyntaxKind.InternalKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
        public static ModifierList Public => new ModifierList(SyntaxKind.PublicKeyword);
        public static ModifierList PublicAbstract => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword)
        });
        public static ModifierList PublicAbstractAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicAbstractOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PublicAbstractOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AbstractKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicConst => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.ConstKeyword)
        });
        public static ModifierList PublicDelegate => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.DelegateKeyword)
        });
        public static ModifierList PublicEvent => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.EventKeyword)
        });
        public static ModifierList PublicOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PublicOverrideAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PublicSealed => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword)
        });
        public static ModifierList PublicSealedOverride => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.SealedKeyword),
            new ModifierListAssociation(SyntaxKind.OverrideKeyword)
        });
        public static ModifierList PublicStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList PublicStaticAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicStaticExtern => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ExternKeyword)
        });
        public static ModifierList PublicStaticReadonly => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword),
            new ModifierListAssociation(SyntaxKind.ReadOnlyKeyword)
        });
        public static ModifierList PublicUnsafeStatic => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.UnsafeKeyword),
            new ModifierListAssociation(SyntaxKind.StaticKeyword)
        });
        public static ModifierList PublicVirtual => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword)
        });
        public static ModifierList PublicVirtualAsync => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VirtualKeyword),
            new ModifierListAssociation(SyntaxKind.AsyncKeyword)
        });
        public static ModifierList PublicVolatile => new ModifierList(new List<ModifierListAssociation>
        {
            new ModifierListAssociation(SyntaxKind.PublicKeyword),
            new ModifierListAssociation(SyntaxKind.VolatileKeyword)
        });
    }
}
