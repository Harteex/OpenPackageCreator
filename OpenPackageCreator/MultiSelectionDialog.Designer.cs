namespace OpenPackageCreator
{
    partial class MultiSelectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSelected = new System.Windows.Forms.GroupBox();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.comboBoxPreset = new System.Windows.Forms.ComboBox();
            this.labelPreset = new System.Windows.Forms.Label();
            this.labelCustom = new System.Windows.Forms.Label();
            this.textBoxCustom = new System.Windows.Forms.TextBox();
            this.buttonAddPreset = new System.Windows.Forms.Button();
            this.buttonAddCustom = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxSelected.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSelected
            // 
            this.groupBoxSelected.Controls.Add(this.buttonRemove);
            this.groupBoxSelected.Controls.Add(this.listBoxSelected);
            this.groupBoxSelected.Location = new System.Drawing.Point(13, 13);
            this.groupBoxSelected.Name = "groupBoxSelected";
            this.groupBoxSelected.Size = new System.Drawing.Size(280, 101);
            this.groupBoxSelected.TabIndex = 0;
            this.groupBoxSelected.TabStop = false;
            this.groupBoxSelected.Text = "Selected";
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.buttonAddCustom);
            this.groupBoxAdd.Controls.Add(this.buttonAddPreset);
            this.groupBoxAdd.Controls.Add(this.textBoxCustom);
            this.groupBoxAdd.Controls.Add(this.labelCustom);
            this.groupBoxAdd.Controls.Add(this.labelPreset);
            this.groupBoxAdd.Controls.Add(this.comboBoxPreset);
            this.groupBoxAdd.Location = new System.Drawing.Point(13, 125);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(280, 120);
            this.groupBoxAdd.TabIndex = 1;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "Add";
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(7, 20);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(181, 69);
            this.listBoxSelected.TabIndex = 0;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(204, 20);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(59, 23);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // comboBoxPreset
            // 
            this.comboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreset.FormattingEnabled = true;
            this.comboBoxPreset.Location = new System.Drawing.Point(10, 36);
            this.comboBoxPreset.Name = "comboBoxPreset";
            this.comboBoxPreset.Size = new System.Drawing.Size(178, 21);
            this.comboBoxPreset.TabIndex = 0;
            // 
            // labelPreset
            // 
            this.labelPreset.AutoSize = true;
            this.labelPreset.Location = new System.Drawing.Point(7, 20);
            this.labelPreset.Name = "labelPreset";
            this.labelPreset.Size = new System.Drawing.Size(64, 13);
            this.labelPreset.TabIndex = 1;
            this.labelPreset.Text = "Add from list";
            // 
            // labelCustom
            // 
            this.labelCustom.AutoSize = true;
            this.labelCustom.Location = new System.Drawing.Point(6, 67);
            this.labelCustom.Name = "labelCustom";
            this.labelCustom.Size = new System.Drawing.Size(63, 13);
            this.labelCustom.TabIndex = 1;
            this.labelCustom.Text = "Add custom";
            // 
            // textBoxCustom
            // 
            this.textBoxCustom.Location = new System.Drawing.Point(10, 84);
            this.textBoxCustom.Name = "textBoxCustom";
            this.textBoxCustom.Size = new System.Drawing.Size(178, 20);
            this.textBoxCustom.TabIndex = 2;
            // 
            // buttonAddPreset
            // 
            this.buttonAddPreset.Location = new System.Drawing.Point(204, 34);
            this.buttonAddPreset.Name = "buttonAddPreset";
            this.buttonAddPreset.Size = new System.Drawing.Size(59, 23);
            this.buttonAddPreset.TabIndex = 1;
            this.buttonAddPreset.Text = "Add";
            this.buttonAddPreset.UseVisualStyleBackColor = true;
            this.buttonAddPreset.Click += new System.EventHandler(this.buttonAddPreset_Click);
            // 
            // buttonAddCustom
            // 
            this.buttonAddCustom.Location = new System.Drawing.Point(204, 82);
            this.buttonAddCustom.Name = "buttonAddCustom";
            this.buttonAddCustom.Size = new System.Drawing.Size(59, 23);
            this.buttonAddCustom.TabIndex = 1;
            this.buttonAddCustom.Text = "Add";
            this.buttonAddCustom.UseVisualStyleBackColor = true;
            this.buttonAddCustom.Click += new System.EventHandler(this.buttonAddCustom_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(76, 263);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(159, 263);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // MultiSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 302);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxAdd);
            this.Controls.Add(this.groupBoxSelected);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MultiSelectionDialog";
            this.Text = "MultiSelectionDialog";
            this.groupBoxSelected.ResumeLayout(false);
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSelected;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.Button buttonAddCustom;
        private System.Windows.Forms.Button buttonAddPreset;
        private System.Windows.Forms.TextBox textBoxCustom;
        private System.Windows.Forms.Label labelCustom;
        private System.Windows.Forms.Label labelPreset;
        private System.Windows.Forms.ComboBox comboBoxPreset;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}