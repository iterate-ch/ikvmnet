﻿using System;

namespace IKVM.Runtime.Accessors
{

    internal abstract partial class Accessor
    {

        protected MethodAccessor<Action<object>> GetVoidMethod(ref MethodAccessor<Action<object>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1>> GetVoidMethod<TArg1>(ref MethodAccessor<Action<object, TArg1>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1, TArg2>> GetVoidMethod<TArg1, TArg2>(ref MethodAccessor<Action<object, TArg1, TArg2>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1, TArg2, TArg3>> GetVoidMethod<TArg1, TArg2, TArg3>(ref MethodAccessor<Action<object, TArg1, TArg2, TArg3>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4>> GetVoidMethod<TArg1, TArg2, TArg3, TArg4>(ref MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5>> GetVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(ref MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>> GetVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>> GetVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>> GetVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref MethodAccessor<Action<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>> location, string name)
        {
            return MethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TResult>> GetMethod<TResult>(ref MethodAccessor<Func<object, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TResult>> GetMethod<TArg1, TResult>(ref MethodAccessor<Func<object, TArg1, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TArg2, TResult>> GetMethod<TArg1, TArg2, TResult>(ref MethodAccessor<Func<object, TArg1, TArg2, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TArg2, TArg3, TResult>> GetMethod<TArg1, TArg2, TArg3, TResult>(ref MethodAccessor<Func<object, TArg1, TArg2, TArg3, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TResult>> GetMethod<TArg1, TArg2, TArg3, TArg4, TResult>(ref MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(ref MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>> GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(ref MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>> GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(ref MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }

        protected MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>> GetMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(ref MethodAccessor<Func<object, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>> location, string name)
        {
            return MethodAccessor.LazyGet(ref location, type, name);
        }


        protected StaticMethodAccessor<Action> GetStaticVoidMethod(ref StaticMethodAccessor<Action> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1>> GetStaticVoidMethod<TArg1>(ref StaticMethodAccessor<Action<TArg1>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1, TArg2>> GetStaticVoidMethod<TArg1, TArg2>(ref StaticMethodAccessor<Action<TArg1, TArg2>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1, TArg2, TArg3>> GetStaticVoidMethod<TArg1, TArg2, TArg3>(ref StaticMethodAccessor<Action<TArg1, TArg2, TArg3>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4>> GetStaticVoidMethod<TArg1, TArg2, TArg3, TArg4>(ref StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5>> GetStaticVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(ref StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>> GetStaticVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ref StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>> GetStaticVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ref StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>> GetStaticVoidMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ref StaticMethodAccessor<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>> location, string name)
        {
            return StaticMethodAccessor.LazyGetVoid(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TResult>> GetStaticMethod<TResult>(ref StaticMethodAccessor<Func<TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TResult>> GetStaticMethod<TArg1, TResult>(ref StaticMethodAccessor<Func<TArg1, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TArg2, TResult>> GetStaticMethod<TArg1, TArg2, TResult>(ref StaticMethodAccessor<Func<TArg1, TArg2, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TResult>> GetStaticMethod<TArg1, TArg2, TArg3, TResult>(ref StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TResult>> GetStaticMethod<TArg1, TArg2, TArg3, TArg4, TResult>(ref StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> GetStaticMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(ref StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>> GetStaticMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(ref StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>> GetStaticMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(ref StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

        protected StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>> GetStaticMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(ref StaticMethodAccessor<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>> location, string name)
        {
            return StaticMethodAccessor.LazyGet(ref location, type, name);
        }

    }

}