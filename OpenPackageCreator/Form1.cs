using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace OpenPackageCreator
{
    public partial class Form1 : Form
    {
        private string curPath = "";
        private DesktopFileOption desktopFileOpt = DesktopFileOption.Ignore;

        public Form1()
        {
            InitializeComponent();
            EnableFields(false);
            MinimumSize = Size;
            SetupTooltips();
        }

        private void SetupTooltips()
        {
            string descName = "Name\n\nThe title of the app on the menu";
            string descComment = "Comment\n\nA short description of the app";
            string descCategories = "Categories\n\nOne or more categories the application should show up under in the launcher";
            string descExecutableGcw = "Executable\n\nThe command to execute the program for the GCW Zero. Leave blank if this target is not supported.";
            string descExecutableA320 = "Executable\n\nThe command to execute the program for the Dingoo A320. Leave blank if this target is not supported.";
            string descIcon = "Icon\n\nThe icon that shows up for the application in the launcher";
            string descLaunchWithFile = "Launch Executable With File\n\nSet if the user should be able to select files to launch with the application, e.g. launching a rom with an emulator";
            string descMimeTypes = "MimeTypes\n\nFile types to launch with the application if Launch Executable With File is set";
            string descTerminal = "Terminal\n\nTell the menu to launch the app in a framebuffer console if enabled, e.g. for ncurses or regular stdout apps";
            string descManual = "Manual\n\nName of a text file that will be used as the manual of the app by the launcher";
            string descJoystickMode = "Use Joystick Mode\n\nJoystick Mode makes the system report joystick events instead of keyboard events for input";
            string descGSensor = "Use GSensor\n\nBind the gravity sensor of the GCW Zero to a joystick device accessible alongside the joystick or keyboard";
            string descHardwareScaling = "Enable Hardware Scaling\n\nEnable the hardware scaling of resolutions larger than 320x240 (up to 640x480)";

            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 32767;
            toolTip.InitialDelay = 0;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            int toolTipMaxLine = 60;

            toolTip.SetToolTip(this.infoName, DoLineBreak(descName, toolTipMaxLine));
            toolTip.SetToolTip(this.infoComment, DoLineBreak(descComment, toolTipMaxLine));
            toolTip.SetToolTip(this.infoCategories, DoLineBreak(descCategories, toolTipMaxLine));
            toolTip.SetToolTip(this.infoExeGcw, DoLineBreak(descExecutableGcw, toolTipMaxLine));
            toolTip.SetToolTip(this.infoExeA320, DoLineBreak(descExecutableA320, toolTipMaxLine));
            toolTip.SetToolTip(this.infoIcon, DoLineBreak(descIcon, toolTipMaxLine));
            toolTip.SetToolTip(this.infoLaunchWithFile, DoLineBreak(descLaunchWithFile, toolTipMaxLine));
            toolTip.SetToolTip(this.infoMimeTypes, DoLineBreak(descMimeTypes, toolTipMaxLine));
            toolTip.SetToolTip(this.infoTerminal, DoLineBreak(descTerminal, toolTipMaxLine));
            toolTip.SetToolTip(this.infoManual, DoLineBreak(descManual, toolTipMaxLine));
            toolTip.SetToolTip(this.infoJoystickMode, DoLineBreak(descJoystickMode, toolTipMaxLine));
            toolTip.SetToolTip(this.infoGSensor, DoLineBreak(descGSensor, toolTipMaxLine));
            toolTip.SetToolTip(this.infoHardwareScaling, DoLineBreak(descHardwareScaling, toolTipMaxLine));

            infoName.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descName, "Name", MessageBoxButtons.OK); });
            infoComment.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descComment, "Comment", MessageBoxButtons.OK); });
            infoCategories.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descCategories, "Categories", MessageBoxButtons.OK); });
            infoExeGcw.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descExecutableGcw, "Executable", MessageBoxButtons.OK); });
            infoExeA320.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descExecutableA320, "Executable", MessageBoxButtons.OK); });
            infoIcon.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descIcon, "Icon", MessageBoxButtons.OK); });
            infoLaunchWithFile.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descLaunchWithFile, "Launch Executable With File", MessageBoxButtons.OK); });
            infoMimeTypes.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descMimeTypes, "Mime Types", MessageBoxButtons.OK); });
            infoTerminal.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descTerminal, "Terminal", MessageBoxButtons.OK); });
            infoManual.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descManual, "Manual", MessageBoxButtons.OK); });
            infoJoystickMode.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descJoystickMode, "Use Joystick Mode", MessageBoxButtons.OK); });
            infoGSensor.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descGSensor, "Use GSensor", MessageBoxButtons.OK); });
            infoHardwareScaling.Click += new EventHandler(delegate(object sender, EventArgs e) { MessageBox.Show(descHardwareScaling, "Enable Hardware Scaling", MessageBoxButtons.OK); });
        }

        private string DoLineBreak(string text, int lineLength)
        {
            List<string> rows = new List<string>();

            int curRowStartPos = 0;
            int curRowLength = 0;
            int lastSpaceForCurRow = -1;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    rows.Add(text.Substring(curRowStartPos, i - curRowStartPos).Trim());
                    lastSpaceForCurRow = -1;
                    curRowLength = 0;
                    curRowStartPos = i + 1;
                    continue;
                }

                if (text[i] == ' ')
                {
                    lastSpaceForCurRow = i;
                }

                if (curRowLength >= lineLength)
                {
                    // If we have an appropriate space to break on, do so, otherwise force break anyway
                    if (lastSpaceForCurRow > -1)
                    {
                        i = lastSpaceForCurRow;
                    }

                    rows.Add(text.Substring(curRowStartPos, i - curRowStartPos).Trim());
                    lastSpaceForCurRow = -1;
                    curRowLength = 0;
                    curRowStartPos = i;
                    continue;
                }

                curRowLength++;
            }

            if (text.Length > curRowStartPos)
            {
                rows.Add(text.Substring(curRowStartPos, text.Length - curRowStartPos).Trim());
            }

            return String.Join("\n", rows);
        }

        private void LoadDirectory(string path)
        {
            Reset();
            curPath = path;
            textBoxCurPath.Text = path;

            List<string> desktopFiles = new List<string>();
            IEnumerable<string> tempDesktopFiles = Directory.EnumerateFiles(path, "*.desktop");
            foreach (string desktopFile in tempDesktopFiles)
            {
                desktopFiles.Add(desktopFile);
            }

            if (desktopFiles.Count > 0)
            {
                ExistingDesktopFilesWindow desktopAskWindow = new ExistingDesktopFilesWindow();
                DialogResult result = desktopAskWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    desktopFileOpt = desktopAskWindow.DesktopFileOption;

                    if (desktopFileOpt == DesktopFileOption.LoadExisting)
                    {
                        string execGcw = "";
                        string execA320 = "";
                        DesktopFile desktopFileToUse = null;

                        // Load desktop files
                        List<DesktopFile> loadedDesktopFiles = new List<DesktopFile>();
                        foreach (string desktopFilename in desktopFiles)
                        {
                            DesktopFile df = new DesktopFile();
                            Regex platformPattern = new Regex("default\\.([ ._0-9A-Za-z-]+)\\.desktop");
                            string platform = platformPattern.Match(Path.GetFileName(desktopFilename)).Groups[1].Value;
                            if (!df.ReadDesktopFile(path, platform))
                            {
                                MessageBox.Show("Loading of existing desktop file failed: " + df.LastError, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            loadedDesktopFiles.Add(df);

                            if (platform == "gcw0")
                            {
                                execGcw = df.Exec;
                            }
                            else if (platform == "a320")
                            {
                                execA320 = df.Exec;
                            }

                            if (desktopFileToUse == null)
                                desktopFileToUse = df;
                        }

                        if (loadedDesktopFiles.Count > 1)
                        {
                            // Compare desktop files
                            // If they differ other than the executable, prompt to pick one to use
                            if (desktopFileToUse != null)
                            {
                                foreach (DesktopFile df in loadedDesktopFiles)
                                {
                                    if (!desktopFileToUse.Compare(df))
                                    {
                                        LoadDesktopSelectorDialog selectorDialog = new LoadDesktopSelectorDialog();
                                        selectorDialog.SetData(loadedDesktopFiles);
                                        DialogResult selectorResult = selectorDialog.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {
                                            DesktopFile selected = selectorDialog.SelectedData;
                                            if (selected != null)
                                            {
                                                desktopFileToUse = selected;
                                            }
                                            else
                                            {
                                                desktopFileToUse = null;
                                            }
                                        }
                                        else
                                        {
                                            desktopFileToUse = null;
                                        }
                                        break;
                                    }
                                }
                            }
                        }

                        if (desktopFileToUse != null)
                        {
                            // Set fields with desktop file data
                            textBoxName.Text = desktopFileToUse.Name;
                            textBoxComment.Text = desktopFileToUse.Comment;
                            textBoxCategories.Text = desktopFileToUse.Categories;
                            textBoxExe.Text = execGcw;
                            textBoxExeA320.Text = execA320;
                            textBoxIcon.Text = desktopFileToUse.Icon;
                            checkBoxLaunchWithFile.Checked = desktopFileToUse.WithFile;
                            textBoxMimeTypes.Text = desktopFileToUse.MimeTypes;
                            checkBoxTerminal.Checked = desktopFileToUse.Terminal;
                            textBoxManual.Text = desktopFileToUse.Manual;
                            checkBoxJoystickMode.Checked = desktopFileToUse.JoystickMode;
                            checkBoxGSensor.Checked = desktopFileToUse.GSensor;
                            checkBoxHardwareScaling.Checked = desktopFileToUse.HardwareScaling;
                        }
                        
                        EnableFields(true);
                    }
                    else if (desktopFileOpt == DesktopFileOption.UseAsIs)
                    {
                        SetUsingExistingFilesInAllFields();
                    }
                    else if (desktopFileOpt == DesktopFileOption.Ignore)
                    {
                        EnableFields(true);
                    }
                }
                else
                {
                    return;
                }
            }

            if (desktopFileOpt == DesktopFileOption.Ignore)
            {
                // Guess values
                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.dge");
                string probableExe = "";
                foreach (string file in files)
                {
                    probableExe = Path.GetFileName(file);
                    break;
                }

                string probableIcon = "";
                string firstIconMatch = "";
                files = Directory.EnumerateFiles(path, "*.png");
                foreach (string file in files)
                {
                    if (firstIconMatch.Length == 0)
                        firstIconMatch = Path.GetFileName(file);

                    if (Path.GetFileNameWithoutExtension(file) == Path.GetFileNameWithoutExtension(probableExe))
                    {
                        probableIcon = Path.GetFileName(file);
                        break;
                    }
                }

                if (probableIcon == "")
                    probableIcon = firstIconMatch;

                textBoxName.Text = Path.GetFileName(path);
                textBoxExe.Text = probableExe;
                textBoxIcon.Text = probableIcon;

                EnableFields(true);
            }
        }

        private void Pack()
        {
            if (!Directory.Exists(curPath))
            {
                MessageBox.Show("No valid folder selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (desktopFileOpt == DesktopFileOption.Ignore || desktopFileOpt == DesktopFileOption.LoadExisting)
            {

                DesktopFile desktopFileGCW0 = null;
                DesktopFile desktopFileA320 = null;

                if (textBoxExe.Text != "")
                {
                    desktopFileGCW0 = new DesktopFile();
                }

                if (textBoxExeA320.Text != "")
                {
                    desktopFileA320 = new DesktopFile();
                }

                if (desktopFileGCW0 == null && desktopFileA320 == null)
                {
                    MessageBox.Show("You must enter an executable for at least one platform.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (desktopFileGCW0 != null)
                {
                    desktopFileGCW0.Platform = "gcw0";

                    desktopFileGCW0.Name = textBoxName.Text;
                    desktopFileGCW0.Exec = textBoxExe.Text;
                    desktopFileGCW0.Icon = textBoxIcon.Text;
                    desktopFileGCW0.Comment = textBoxComment.Text;
                    desktopFileGCW0.Categories = textBoxCategories.Text;
                    desktopFileGCW0.MimeTypes = textBoxMimeTypes.Text;
                    desktopFileGCW0.Terminal = checkBoxTerminal.Checked;
                    desktopFileGCW0.Manual = textBoxManual.Text;
                    desktopFileGCW0.JoystickMode = checkBoxJoystickMode.Checked;
                    desktopFileGCW0.GSensor = checkBoxGSensor.Checked;
                    desktopFileGCW0.HardwareScaling = checkBoxHardwareScaling.Checked;
                }

                if (desktopFileA320 != null)
                {
                    desktopFileA320.Platform = "a320";

                    desktopFileA320.Name = textBoxName.Text;
                    desktopFileA320.Exec = textBoxExeA320.Text;
                    desktopFileA320.Icon = textBoxIcon.Text;
                    desktopFileA320.Comment = textBoxComment.Text;
                    desktopFileA320.Categories = textBoxCategories.Text;
                    desktopFileA320.MimeTypes = textBoxMimeTypes.Text;
                    desktopFileA320.Terminal = checkBoxTerminal.Checked;
                    desktopFileA320.Manual = textBoxManual.Text;
                    desktopFileA320.JoystickMode = checkBoxJoystickMode.Checked;
                    desktopFileA320.GSensor = checkBoxGSensor.Checked;
                    desktopFileA320.HardwareScaling = checkBoxHardwareScaling.Checked;
                }

                if (desktopFileGCW0 != null && !desktopFileGCW0.VerifyData())
                {
                    MessageBox.Show("Error: " + desktopFileGCW0.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (desktopFileA320 != null && !desktopFileA320.VerifyData())
                {
                    MessageBox.Show("Error: " + desktopFileA320.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (desktopFileGCW0 != null)
                {
                    string execPath = Path.Combine(new string[] { curPath, desktopFileGCW0.Exec });
                    bool exeExists = File.Exists(execPath);
                    if (!exeExists)
                    {
                        DialogResult exeResult = MessageBox.Show("Executable can not be found - Continue anyway?", "Executable not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (exeResult != System.Windows.Forms.DialogResult.Yes)
                            return;
                    }
                    
                    desktopFileGCW0.WriteDesktopFile(curPath);

                    if (exeExists)
                        VerifyAndFixLineEndingsIfScript(execPath);
                }
                else
                {
                    string path = Path.Combine(curPath, DesktopFile.GetFilename("gcw0"));
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }

                if (desktopFileA320 != null)
                {
                    string execPath = Path.Combine(new string[] { curPath, desktopFileA320.Exec });
                    bool exeExists = File.Exists(execPath);
                    if (!exeExists)
                    {
                        DialogResult exeResult = MessageBox.Show("Executable can not be found - Continue anyway?", "Executable not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (exeResult != System.Windows.Forms.DialogResult.Yes)
                            return;
                    }

                    desktopFileA320.WriteDesktopFile(curPath);

                    if (exeExists)
                        VerifyAndFixLineEndingsIfScript(execPath);
                }
                else
                {
                    string path = Path.Combine(curPath, DesktopFile.GetFilename("a320"));
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            if (textBoxManual.Text != "")
            {
                try
                {
                    VerifyAndFixLineEndings(Path.Combine(curPath, textBoxManual.Text));
                }
                catch (Exception)
                { }
            }

            saveFileDialogOpk.InitialDirectory = Directory.GetParent(curPath).FullName;

            DialogResult result = saveFileDialogOpk.ShowDialog();
            if (result != DialogResult.OK)
                return;

            ExecutePacker(saveFileDialogOpk.FileName);
        }

        private void ExecutePacker(string saveFile)
        {
            try
            {
                // Start the child process. 
                Process p = new Process();
                // Redirect the output stream of the child process. 
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.EnvironmentVariables.Add("CYGWIN", "nodosfilewarning");
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "mksquashfs";
                p.StartInfo.Arguments = "\"" + curPath + "\" \"" + saveFile + "\" -all-root -noappend";
                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                output += p.StandardError.ReadToEnd();
                output = output.Replace("\n", "\r\n");
                p.WaitForExit();
                MessageBox.Show(output, "Operation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerifyAndFixLineEndings(string filename)
        {
            VerifyAndFixLineEndings(filename, false);
        }

        private void VerifyAndFixLineEndings(string filename, bool isScript)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                FileStream fs = fi.OpenRead();

                // Now look for \r
                byte[] data = new byte[fi.Length];
                fs.Position = 0;
                if (fs.Read(data, 0, (int)fi.Length) != fi.Length)
                {
                    MessageBox.Show("Error reading data from " + Path.GetFileName(filename), "Error reading data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                fs.Close();

                bool containsCr = false;
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == '\r')
                    {
                        containsCr = true;
                        break;
                    }
                }

                if (containsCr)
                {
                    // File has windows file endings...
                    // Ask the user if we should fix this
                    string message;
                    if (isScript)
                        message = "Executable script (" + Path.GetFileName(filename) + ") contains Windows line endings, which is not compatible with OpenDingux. Do you want to convert line endings to the Unix format?\n\n(Only the chosen executable is checked, if there are other scripts, these must be fixed too)";
                    else
                        message = Path.GetFileName(filename) + " contains Windows line endings, which is not compatible with OpenDingux. Do you want to convert line endings to the Unix format?";

                    DialogResult result = MessageBox.Show(message, "Convert line endings?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        fi.Delete();
                        FileStream fsWrite = fi.OpenWrite();
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] != '\r')
                            {
                                fsWrite.WriteByte(data[i]);
                            }
                        }
                        fsWrite.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured while trying to read from or write to " + Path.GetFileName(filename) + ": " + e.Message);
            }
        }

        private void VerifyAndFixLineEndingsIfScript(string filename)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                FileStream fs = fi.OpenRead();
                int b1 = fs.ReadByte();
                int b2 = fs.ReadByte();
                fs.Close();
                if (b1 == '#' && b2 == '!')
                {
                    // Appears to be shell script
                    VerifyAndFixLineEndings(filename, true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured while trying to read from " + Path.GetFileName(filename) + ": " + e.Message);
            }
        }

        private void SetUsingExistingFilesInAllFields()
        {
            textBoxName.Text = "<using existing files>";
            textBoxComment.Text = "<using existing files>";
            textBoxCategories.Text = "<using existing files>";
            textBoxExe.Text = "<using existing files>";
            textBoxIcon.Text = "<using existing files>";
            textBoxMimeTypes.Text = "<using existing files>";
            textBoxManual.Text = "<using existing files>";
        }

        private void EnableFields(bool b)
        {
            textBoxName.Enabled = b;
            textBoxComment.Enabled = b;
            textBoxCategories.Enabled = b;
            buttonCategories.Enabled = b;
            textBoxExe.Enabled = b;
            buttonExe.Enabled = b;
            textBoxExeA320.Enabled = b;
            buttonExeA320.Enabled = b;
            textBoxIcon.Enabled = b;
            buttonIcon.Enabled = b;
            checkBoxLaunchWithFile.Enabled = b;
            if (!b || checkBoxLaunchWithFile.Checked)
            {
                textBoxMimeTypes.Enabled = b;
                buttonMimeTypes.Enabled = b;
            }
            checkBoxTerminal.Enabled = b;
            textBoxManual.Enabled = b;
            buttonManual.Enabled = b;
            checkBoxJoystickMode.Enabled = b;
            checkBoxGSensor.Enabled = b;
            checkBoxHardwareScaling.Enabled = b;
        }

        private void Reset()
        {
            curPath = "";
            textBoxCurPath.Text = "No Path Loaded";
            textBoxName.Text = "";
            textBoxComment.Text = "";
            textBoxCategories.Text = "";
            textBoxExe.Text = "";
            textBoxExeA320.Text = "";
            textBoxIcon.Text = "";
            checkBoxLaunchWithFile.Checked = false;
            EnableFields(false);
            textBoxMimeTypes.Text = "";
            checkBoxTerminal.Checked = false;
            textBoxManual.Text = "";
            checkBoxJoystickMode.Checked = false;
            checkBoxGSensor.Checked = false;
            checkBoxHardwareScaling.Checked = false;

            desktopFileOpt = DesktopFileOption.Ignore;
        }

        private void EnableDisableMimeTypes()
        {
            if (checkBoxLaunchWithFile.Checked && !checkBoxLaunchWithFile.Enabled)
                return;

            textBoxMimeTypes.Enabled = checkBoxLaunchWithFile.Checked;
            buttonMimeTypes.Enabled = checkBoxLaunchWithFile.Checked;
        }

        #region DragNDrop
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (Directory.Exists(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (Directory.Exists(files[0]))
                    LoadDirectory(files[0]);
            }
        }
        #endregion

        #region EventHandlers
        private void buttonPack_Click(object sender, EventArgs e)
        {
            Pack();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            string path = folderBrowserDialog.SelectedPath;

            LoadDirectory(path);
        }

        private void checkBoxLaunchWithFile_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableMimeTypes();
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            MultiSelectionDialog msd = new MultiSelectionDialog();
            msd.Text = "Select Categories";
            msd.Selected = textBoxCategories.Text;
            msd.Preset = "applications;emulators;games;settings";
            msd.SelectDefaultInPresetList("games");
            if (msd.ShowDialog() == DialogResult.OK)
                textBoxCategories.Text = msd.Selected;
        }

        private void buttonMimeTypes_Click(object sender, EventArgs e)
        {
            MultiSelectionDialog msd = new MultiSelectionDialog();
            msd.Text = "Select Mime Types";
            msd.Selected = textBoxMimeTypes.Text;
            msd.Preset = 
                "application/zip;" +
                "application/gzip;" +
                "application/x-compressed-tar;" +
                "application/x-dc-rom;" +
                "application/x-nintendo-ds-rom;" +
                "application/x-lynx-rom;" +
                "application/x-gameboy-rom;" +
                "application/x-gba-rom;" +
                "application/x-gbc-rom;" +
                "application/x-genesis-rom;" +
                "application/x-megadrive-rom;" +
                "application/x-msx-rom;" +
                "application/x-n64-rom;" +
                "application/x-nes-rom;" +
                "application/x-sms-rom;" +
                "application/x-snes-rom;" +
                "application/usp-zx-snapshot;" +
                "application/usp-zx-disk;" +
                "application/usp-zx-tape;" +
                "application/x-cue;" +
                "application/x-cd-image;" +
                "audio/x-matroska;" +
                "audio/webm;" +
                "audio/ogg;" +
                "audio/x-vorbis+ogg;" +
                "audio/x-flac+ogg;" +
                "audio/ac3;" +
                "audio/vnd.dts;" +
                "audio/prs.sid;" +
                "audio/x-adpcm;" +
                "audio/x-aiff;" +
                "audio/x-ape;" +
                "audio/x-it;" +
                "audio/flac;" +
                "audio/x-wavpack;" +
                "audio/midi;" +
                "audio/aac;" +
                "audio/mp4;" +
                "audio/x-mod;" +
                "audio/mp2;" +
                "audio/mp3;" +
                "audio/mpeg;" +
                "audio/m3u;" +
                "audio/x-ms-asx;" +
                "audio/wma;" +
                "audio/x-musepack;" +
                "audio/vnd.rn-realaudio;" +
                "audio/x-s3m;" +
                "audio/x-wav;" +
                "audio/x-xm;" +
                "video/x-flv;" +
                "video/x-matroska;" +
                "video/webm;" +
                "video/ogg;" +
                "video/mp4;" +
                "video/3gpp;" +
                "video/vnd.rn-realvideo;" +
                "video/mpeg;" +
                "video/quicktime;" +
                "video/x-ms-asf;" +
                "video/x-ms-wmv;" +
                "video/avi;" +
                "image/bmp;" +
                "image/gif;" +
                "image/jpeg;" +
                "image/jp2;" +
                "image/png;" +
                "image/rle;" +
                "image/svg+xml;" +
                "image/tiff;" +
                "image/x-pcx;" +
                "image/x-tga;";
            if (msd.ShowDialog() == DialogResult.OK)
                textBoxMimeTypes.Text = msd.Selected;
        }

        private void buttonForPath_Click(object sender, EventArgs e)
        {
            if (!(sender is Button))
                return;
            Button curButton = (Button)sender;

            openFileDialog.InitialDirectory = curPath;
            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            string relativePath = openFileDialog.FileName.Replace(curPath, "");
            relativePath = relativePath.Replace("\\", "/");
            if (relativePath.StartsWith("/"))
                relativePath = relativePath.Substring(1);

            if (curButton == buttonExe)
                textBoxExe.Text = relativePath;
            else if (curButton == buttonExeA320)
                textBoxExeA320.Text = relativePath;
            else if (curButton == buttonIcon)
                textBoxIcon.Text = relativePath;
            else if (curButton == buttonManual)
                textBoxManual.Text = relativePath;
        }
        #endregion

        #region Menu
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            string path = folderBrowserDialog.SelectedPath;

            LoadDirectory(path);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void webSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.harteex.com/?page=openpackagecreator");
        }
        #endregion
    }
}
