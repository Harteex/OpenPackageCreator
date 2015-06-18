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
    public partial class ExistingDesktopFilesWindow : Form
    {
        private DesktopFileOption option = DesktopFileOption.Ignore;

        public ExistingDesktopFilesWindow()
        {
            InitializeComponent();
        }

        public DesktopFileOption DesktopFileOption
        {
            get { return option; }
        }

        private void richButtonLoad_Click(object sender, EventArgs e)
        {
            option = DesktopFileOption.LoadExisting;
            DialogResult = DialogResult.OK;
        }

        private void richButtonUseAsIs_Click(object sender, EventArgs e)
        {
            option = DesktopFileOption.UseAsIs;
            DialogResult = DialogResult.OK;
        }

        private void richButtonIgnore_Click(object sender, EventArgs e)
        {
            option = DesktopFileOption.Ignore;
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }

    public enum DesktopFileOption { LoadExisting, UseAsIs, Ignore };
}
