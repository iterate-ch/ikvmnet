﻿/*
  Copyright (C) 2002-2013 Jeroen Frijters

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.

  Jeroen Frijters
  jeroen@frijters.net
  
*/
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#if IMPORTER || EXPORTER
using IKVM.Reflection;

using Type = IKVM.Reflection.Type;
#else
using System.Reflection;
#endif

#if IMPORTER
using IKVM.Tools.Importer;
#endif

namespace IKVM.Runtime
{
    /// <summary>
    /// Maintains instances of <see cref="RuntimeAssemblyClassLoader"/>.
    /// </summary>
    static class RuntimeAssemblyClassLoaderFactory
    {

        /// <summary>
        /// Maps existing <see cref="RuntimeAssemblyClassLoader"/> instances to <see cref="Assembly"/> instances. Allows
        /// assemblies to be unloaded.
        /// </summary>
        static readonly ConditionalWeakTable<Assembly, RuntimeAssemblyClassLoader> assemblyClassLoaders = new();

#if !IMPORTER && !EXPORTER && !FIRST_PASS
        internal static Dictionary<string, string> customClassLoaderRedirects;
#endif

        /// <summary>
        /// Obtains the <see cref="RuntimeAssemblyClassLoader"/> for the given <see cref="Assembly"/>. This method should not
        /// be used with dynamic Java assemblies
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static RuntimeAssemblyClassLoader FromAssembly(Assembly assembly)
        {
            if (assemblyClassLoaders.TryGetValue(assembly, out RuntimeAssemblyClassLoader loader))
                return loader;

            loader = Create(assembly);

            lock (assemblyClassLoaders)
            {
                if (assemblyClassLoaders.TryGetValue(assembly, out var existing))
                    loader = existing;
                else
                    assemblyClassLoaders.Add(assembly, loader);
            }

            return loader;
        }

        /// <summary>
        /// Creates a new <see cref="RuntimeAssemblyClassLoader"/> for the given assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        static RuntimeAssemblyClassLoader Create(Assembly assembly)
        {
            // If the assembly is a part of a multi-assembly shared class loader,
            // it will export the __<MainAssembly> type from the main assembly in the group.
            var forwarder = assembly.GetType("__<MainAssembly>");
            if (forwarder != null)
            {
                var mainAssembly = forwarder.Assembly;
                if (mainAssembly != assembly)
                    return FromAssembly(mainAssembly);
            }

#if IMPORTER

            if (JVM.BaseAssembly == null && CompilerClassLoader.IsCoreAssembly(assembly))
            {
                JVM.BaseAssembly = assembly;
                RuntimeClassLoaderFactory.LoadRemappedTypes();
            }

#endif

            if (assembly == JVM.BaseAssembly)
            {
                // This cast is necessary for ikvmc and a no-op for the runtime.
                // Note that the cast cannot fail, because ikvmc will only return a non AssemblyClassLoader
                // from GetBootstrapClassLoader() when compiling the core assembly and in that case JVM.CoreAssembly
                // will be null.
                return (RuntimeAssemblyClassLoader)RuntimeClassLoaderFactory.GetBootstrapClassLoader();
            }

            return new RuntimeAssemblyClassLoader(assembly);
        }

    }

}