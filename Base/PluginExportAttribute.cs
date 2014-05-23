using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginExportAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class PluginCreateAttribute : Attribute
    {
    }
}
