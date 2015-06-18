namespace OpenPackageCreator
{
    partial class ExistingDesktopFilesWindow
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.richButtonIgnore = new OpenPackageCreator.RichButton();
            this.richButtonUseAsIs = new OpenPackageCreator.RichButton();
            this.richButtonLoad = new OpenPackageCreator.RichButton();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(293, 20);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "One or more .desktop files already exists";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(259, 334);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // richButtonIgnore
            // 
            this.richButtonIgnore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richButtonIgnore.Description = "Ignore and overwrite existing .desktop files";
            this.richButtonIgnore.Location = new System.Drawing.Point(12, 246);
            this.richButtonIgnore.Name = "richButtonIgnore";
            this.richButtonIgnore.Size = new System.Drawing.Size(327, 75);
            this.richButtonIgnore.TabIndex = 2;
            this.richButtonIgnore.Title = "Ignore";
            this.richButtonIgnore.Click += new System.EventHandler(this.richButtonIgnore_Click);
            // 
            // richButtonUseAsIs
            // 
            this.richButtonUseAsIs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richButtonUseAsIs.Description = "Use the existing .desktop files as they are.\\r\\nNo fields will be editable.";
            this.richButtonUseAsIs.Location = new System.Drawing.Point(12, 165);
            this.richButtonUseAsIs.Name = "richButtonUseAsIs";
            this.richButtonUseAsIs.Size = new System.Drawing.Size(327, 75);
            this.richButtonUseAsIs.TabIndex = 1;
            this.richButtonUseAsIs.Title = "Use existing as is";
            this.richButtonUseAsIs.Click += new System.EventHandler(this.richButtonUseAsIs_Click);
            // 
            // richButtonLoad
            // 
            this.richButtonLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richButtonLoad.Description = "Load data from existing .desktop files.\\r\\nIf the file has been manually modified" +
    ", some data might be lost.";
            this.richButtonLoad.Location = new System.Drawing.Point(12, 84);
            this.richButtonLoad.Name = "richButtonLoad";
            this.richButtonLoad.Size = new System.Drawing.Size(327, 75);
            this.richButtonLoad.TabIndex = 0;
            this.richButtonLoad.Title = "Load data from existing";
            this.richButtonLoad.Click += new System.EventHandler(this.richButtonLoad_Click);
            // 
            // ExistingDesktopFilesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(351, 372);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.richButtonIgnore);
            this.Controls.Add(this.richButtonUseAsIs);
            this.Controls.Add(this.richButtonLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExistingDesktopFilesWindow";
            this.Text = "ExistingDesktopFilesWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichButton richButtonLoad;
        private RichButton richButtonUseAsIs;
        private RichButton richButtonIgnore;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonCancel;
    }
}