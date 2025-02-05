﻿using System;
using System.Linq;

using ConstructorInfo = IKVM.Reflection.ConstructorInfo;
using EventInfo = IKVM.Reflection.EventInfo;
using FieldInfo = IKVM.Reflection.FieldInfo;
using MemberInfo = IKVM.Reflection.MemberInfo;
using MethodInfo = IKVM.Reflection.MethodInfo;
using PropertyInfo = IKVM.Reflection.PropertyInfo;
using Type = IKVM.Reflection.Type;

namespace IKVM.CoreLib.Symbols.IkvmReflection
{

    abstract class IkvmReflectionMemberSymbol : IkvmReflectionSymbol, IMemberSymbol
    {

        readonly IkvmReflectionModuleSymbol _module;
        readonly IkvmReflectionTypeSymbol? _type;
        readonly MemberInfo _member;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="module"></param>
        /// <param name="type"></param>
        /// <param name="member"></param>
        public IkvmReflectionMemberSymbol(IkvmReflectionSymbolContext context, IkvmReflectionModuleSymbol module, IkvmReflectionTypeSymbol? type, MemberInfo member) :
            base(context)
        {
            _module = module ?? throw new ArgumentNullException(nameof(module));
            _type = type;
            _member = member ?? throw new ArgumentNullException(nameof(member));
        }

        /// <summary>
        /// Resolves the symbol for the specified type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected internal override IkvmReflectionTypeSymbol ResolveTypeSymbol(Type type)
        {
            if (_type != null && type == _type.ReflectionObject)
                return _type;
            else if (type.Module == _member.Module)
                return _module.GetOrCreateTypeSymbol(type);
            else
                return base.ResolveTypeSymbol(type);
        }

        /// <summary>
        /// Resolves the symbol for the specified constructor.
        /// </summary>
        /// <param name="ctor"></param>
        /// <returns></returns>
        protected internal override IkvmReflectionConstructorSymbol ResolveConstructorSymbol(ConstructorInfo ctor)
        {
            if (_type != null && ctor.DeclaringType == _type.ReflectionObject)
                return _type.GetOrCreateConstructorSymbol(ctor);
            else if (ctor.DeclaringType != null && ctor.Module == _member.Module)
                return _module.GetOrCreateTypeSymbol(ctor.DeclaringType).GetOrCreateConstructorSymbol(ctor);
            else
                return base.ResolveConstructorSymbol(ctor);
        }

        /// <summary>
        /// Resolves the symbol for the specified method.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        protected internal override IkvmReflectionMethodSymbol ResolveMethodSymbol(MethodInfo method)
        {
            if (_type != null && method.DeclaringType == _type.ReflectionObject)
                return _type.GetOrCreateMethodSymbol(method);
            else if (method.DeclaringType != null && method.Module == _member.Module)
                return _module.GetOrCreateTypeSymbol(method.DeclaringType).GetOrCreateMethodSymbol(method);
            else
                return base.ResolveMethodSymbol(method);
        }

        /// <summary>
        /// Resolves the symbol for the specified field.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        protected internal override IkvmReflectionFieldSymbol ResolveFieldSymbol(FieldInfo field)
        {
            if (_type != null && field.DeclaringType == _type.ReflectionObject)
                return _type.GetOrCreateFieldSymbol(field);
            else if (field.DeclaringType != null && field.Module == _member.Module)
                return _module.GetOrCreateTypeSymbol(field.DeclaringType).GetOrCreateFieldSymbol(field);
            else
                return base.ResolveFieldSymbol(field);
        }


        /// <summary>
        /// Resolves the symbol for the specified field.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        protected internal override IkvmReflectionPropertySymbol ResolvePropertySymbol(PropertyInfo property)
        {

            if (_type != null && property.DeclaringType == _type.ReflectionObject)
                return _type.GetOrCreatePropertySymbol(property);
            else if (property.DeclaringType != null && property.Module == _member.Module)
                return _module.GetOrCreateTypeSymbol(property.DeclaringType).GetOrCreatePropertySymbol(property);
            else
                return base.ResolvePropertySymbol(property);
        }

        /// <summary>
        /// Resolves the symbol for the specified event.
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        protected internal override IkvmReflectionEventSymbol ResolveEventSymbol(EventInfo @event)
        {
            if (_type != null && @event.DeclaringType == _type.ReflectionObject)
                return _type.GetOrCreateEventSymbol(@event);
            else if (@event.DeclaringType != null && @event.Module == _member.Module)
                return _module.GetOrCreateTypeSymbol(@event.DeclaringType).GetOrCreateEventSymbol(@event);
            else
                return base.ResolveEventSymbol(@event);
        }

        internal MemberInfo ReflectionObject => _member;

        internal IkvmReflectionModuleSymbol ContainingModule => _module;

        internal IkvmReflectionTypeSymbol? ContainingType => _type;

        public virtual ITypeSymbol? DeclaringType => _member.DeclaringType is Type t ? Context.GetOrCreateTypeSymbol(t) : null;

        public virtual System.Reflection.MemberTypes MemberType => (System.Reflection.MemberTypes)_member.MemberType;

        public virtual int MetadataToken => _member.MetadataToken;

        public virtual IModuleSymbol Module => Context.GetOrCreateModuleSymbol(_member.Module);

        public virtual string Name => _member.Name;

        public override bool IsMissing => _member.__IsMissing;

        public virtual CustomAttributeSymbol[] GetCustomAttributes()
        {
            return ResolveCustomAttributes(_member.GetCustomAttributesData());
        }

        public virtual CustomAttributeSymbol[] GetCustomAttributes(ITypeSymbol attributeType)
        {
            return ResolveCustomAttributes(_member.GetCustomAttributesData()).Where(i => i.AttributeType == attributeType).ToArray();
        }

        public virtual bool IsDefined(ITypeSymbol attributeType)
        {
            return _member.IsDefined(((IkvmReflectionTypeSymbol)attributeType).ReflectionObject, false);
        }

    }

}