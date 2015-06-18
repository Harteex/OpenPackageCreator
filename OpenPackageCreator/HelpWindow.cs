using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenPackageCreator
{
    public partial class HelpWindow : Form
    {
        public HelpWindow()
        {
            InitializeComponent();

            textBox1.Text = OpenPackageCreator.Properties.Resources.HelpFile;
            textBox1.Select(0, 0);
        }
    }
}
