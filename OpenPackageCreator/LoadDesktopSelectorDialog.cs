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
    public partial class LoadDesktopSelectorDialog : Form
    {
        public LoadDesktopSelectorDialog()
        {
            InitializeComponent();
        }

        public void SetData(List<DesktopFile> list)
        {
            foreach (DesktopFile df in list)
            {
                listBox1.Items.Add(df);
            }
        }

        public DesktopFile SelectedData
        {
            get { return (DesktopFile)listBox1.SelectedItem; }
        }
    }
}
