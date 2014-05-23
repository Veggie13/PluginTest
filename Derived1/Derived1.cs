using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Derived1
{
    [Base.PluginExport]
    public class Derived1 : Base.IBase
    {
        [Base.PluginCreate]
        public static Base.IBase Create()
        {
            return new Derived1();
        }

        public string Name
        {
            get { return "Derived1"; }
        }
    }
}
