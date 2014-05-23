using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Derived2
{
    [Base.PluginExport]
    public class Derived2 : Base.IBase
    {
        [Base.PluginCreate]
        public static Base.IBase Create()
        {
            return new Derived2();
        }

        public string Name
        {
            get { return "Derived2"; }
        }
    }
}
