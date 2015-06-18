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
    public partial class MultiSelectionDialog : Form
    {
        public MultiSelectionDialog()
        {
            InitializeComponent();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxSelected.SelectedIndex != -1)
                listBoxSelected.Items.RemoveAt(listBoxSelected.SelectedIndex);
        }

        public string Selected
        {
            get
            {
                string ret = "";
                for (int i = 0; i < listBoxSelected.Items.Count; i++)
                {
                    ret += listBoxSelected.Items[i] + ";";
                }

                return ret;
            }
            set
            {
                string[] selectedSplit = value.Split(new char[] { ';' });
                for (int i = 0; i < selectedSplit.Length; i++)
                {
                    string tempItem = selectedSplit[i].Trim();
                    if (tempItem != "")
                        listBoxSelected.Items.Add(tempItem);
                }
            }
        }

        public string Preset
        {
            set
            {
                string[] presetSplit = value.Split(new char[] { ';' });
                for (int i = 0; i < presetSplit.Length; i++)
                {
                    string tempItem = presetSplit[i].Trim();
                    if (tempItem != "")
                        comboBoxPreset.Items.Add(tempItem);
                }

                if (comboBoxPreset.Items.Count > 0)
                    comboBoxPreset.SelectedIndex = 0;
            }
        }

        public void SelectDefaultInPresetList(string def)
        {
            if (comboBoxPreset.Items.Contains(def))
                comboBoxPreset.SelectedItem = def;
        }

        private void buttonAddPreset_Click(object sender, EventArgs e)
        {
            if (comboBoxPreset.SelectedItem != null)
            {
                if (!listBoxSelected.Items.Contains(comboBoxPreset.SelectedItem))
                    listBoxSelected.Items.Add(comboBoxPreset.SelectedItem);
            }
        }

        private void buttonAddCustom_Click(object sender, EventArgs e)
        {
            if (textBoxCustom.Text != "")
            {
                if (!listBoxSelected.Items.Contains(textBoxCustom.Text))
                    listBoxSelected.Items.Add(textBoxCustom.Text);
            }
        }
    }
}
