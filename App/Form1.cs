using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Base.Base.LoadPlugin(@"E:\Veggie\Visual Studio 2010\Projects\PluginTest\Derived2\bin\Debug\Derived2.dll");
                Base.IBase b = Base.Base.Create("Derived2.Derived2");
                label1.Text = b.Name;
            }
            catch (Exception)
            {
            }
        }
    }
}
