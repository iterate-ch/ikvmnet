﻿using System;

namespace IKVM.Runtime.Accessors.Java.Lang
{

    /// <summary>
    /// Provides runtime access to the 'java.security.AccessController' type.
    /// </summary>
    internal sealed class AccessControllerAccessor : Accessor<object>
    {

        MethodAccessor<Func<object, object>> doPrivledged;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resolver"></param>
        public AccessControllerAccessor(AccessorTypeResolver resolver) :
            base(resolver("java.security.AccessController"))
        {

        }

        /// <summary>
        /// Invokes the 'doPrivledged' method.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public object InvokeDoPrivledged(object action) => GetMethod(ref doPrivledged, nameof(doPrivledged), "(Ljava.security.PrivilegedAction;)Ljava.lang.Object;").Invoker(action);

    }

}