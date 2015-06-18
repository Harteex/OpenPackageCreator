using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenPackageCreator
{
    public partial class RichButton : UserControl
    {
        public RichButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                return;
            else
            {
                base.OnMouseLeave(e);
            }
        }

        private void RichButton_MouseEnter(object sender, EventArgs e)
        {
            UserControl control = (UserControl)sender;
            control.BackColor = SystemColors.GradientActiveCaption;
        }

        private void RichButton_MouseLeave(object sender, EventArgs e)
        {
            UserControl control = (UserControl)sender;
            control.BackColor = SystemColors.Control;
        }

        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }

        [Description("Title of the option"),
        Category("Data"),
        DefaultValueAttribute(typeof(string), null),
        Browsable(true)]
        public string Title
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }

        [Description("Option description"),
        Category("Data"),
        DefaultValueAttribute(typeof(string), null),
        Browsable(true)]
        public string Description
        {
            get { return labelDescription.Text.Replace("\r", "\\r").Replace("\n", "\\n"); }
            set { labelDescription.Text = value.Replace("\\r", "\r").Replace("\\n", "\n"); }
        }
    }
}
