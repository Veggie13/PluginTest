using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Base
{
    public interface IBase
    {
        string Name { get; }
    }

    public delegate IBase CreateDelegate();

    public static class Base
    {
        private static Dictionary<string, CreateDelegate> _register = new Dictionary<string, CreateDelegate>();

        public static void Register(Type type, CreateDelegate del)
        {
            if (typeof(IBase).IsAssignableFrom(type))
            {
                _register[type.FullName] = del;
            }
        }

        public static IBase Create(string typeName)
        {
            return _register[typeName]();
        }

        public static void LoadPlugin(string path)
        {
            var pluginModule = System.Reflection.Assembly.LoadFile(path);
            var types = pluginModule.TypesWith<PluginExportAttribute>();
            foreach (var type in types)
            {
                Register(type, type.MethodsWith<PluginCreateAttribute>().First().AsDelegate<CreateDelegate>());
            }
        }
    }

    static class Extensions
    {
        public static IEnumerable<Type> TypesWith<AT>(this Assembly assembly) where AT : Attribute
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(AT), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        public static IEnumerable<MethodInfo> MethodsWith<AT>(this Type type) where AT : Attribute
        {
            foreach (MethodInfo mi in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                if (mi.GetCustomAttributes(typeof(AT), true).Length > 0)
                {
                    yield return mi;
                }
            }
        }

        public static D AsDelegate<D>(this MethodInfo mi) where D : class
        {
            if (!typeof(Delegate).IsAssignableFrom(typeof(D)))
                return default(D);
            return Delegate.CreateDelegate(typeof(D), mi) as D;
        }
    }
}
