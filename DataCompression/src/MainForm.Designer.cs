using System.Drawing;

namespace DataCompression
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    
        private void InitializeComponent()
        {
            this.labelNewSize = new System.Windows.Forms.Label();
            this.labelOriginalSize = new System.Windows.Forms.Label();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelMemory = new System.Windows.Forms.Label();
            this.comboBoxAlgorithmType = new System.Windows.Forms.ComboBox();
            this.buttonOutputDirectory = new System.Windows.Forms.Button();
            this.textBoxDirectoryPath = new System.Windows.Forms.TextBox();
            this.buttonInputFile = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonCode = new System.Windows.Forms.Button();
            this.textBoxNewSize = new System.Windows.Forms.TextBox();
            this.textBoxOriginalSize = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxMemory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNewSize
            // 
            this.labelNewSize.AutoSize = true;
            this.labelNewSize.Font = new System.Drawing.Font("Arial", 14F);
            this.labelNewSize.Location = new System.Drawing.Point(366, 240);
            this.labelNewSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNewSize.Name = "labelNewSize";
            this.labelNewSize.Size = new System.Drawing.Size(115, 27);
            this.labelNewSize.TabIndex = 3;
            this.labelNewSize.Text = "New size:";
            // 
            // labelOriginalSize
            // 
            this.labelOriginalSize.AutoSize = true;
            this.labelOriginalSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOriginalSize.Location = new System.Drawing.Point(366, 190);
            this.labelOriginalSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOriginalSize.Name = "labelOriginalSize";
            this.labelOriginalSize.Size = new System.Drawing.Size(124, 29);
            this.labelOriginalSize.TabIndex = 1;
            this.labelOriginalSize.Text = "Initial size:";
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.labelAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAlgorithm.Location = new System.Drawing.Point(13, 193);
            this.labelAlgorithm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(131, 29);
            this.labelAlgorithm.TabIndex = 4;
            this.labelAlgorithm.Text = "Algorithm:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTime.Location = new System.Drawing.Point(13, 311);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(176, 29);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Execution time:";
            // 
            // labelMemory
            // 
            this.labelMemory.AutoSize = true;
            this.labelMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMemory.Location = new System.Drawing.Point(13, 355);
            this.labelMemory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMemory.Name = "labelMemory";
            this.labelMemory.Size = new System.Drawing.Size(165, 29);
            this.labelMemory.TabIndex = 8;
            this.labelMemory.Text = "Memory used:";
            // 
            // comboBoxAlgorithmType
            // 
            this.comboBoxAlgorithmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgorithmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAlgorithmType.FormattingEnabled = true;
            this.comboBoxAlgorithmType.Location = new System.Drawing.Point(162, 193);
            this.comboBoxAlgorithmType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxAlgorithmType.Name = "comboBoxAlgorithmType";
            this.comboBoxAlgorithmType.Size = new System.Drawing.Size(158, 37);
            this.comboBoxAlgorithmType.TabIndex = 5;       
            // 
            // buttonOutputDirectory
            // 
            this.buttonOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOutputDirectory.Location = new System.Drawing.Point(665, 89);
            this.buttonOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOutputDirectory.Name = "buttonOutputDirectory";
            this.buttonOutputDirectory.Size = new System.Drawing.Size(137, 37);
            this.buttonOutputDirectory.TabIndex = 14;
            this.buttonOutputDirectory.Text = "Output Directory";
            this.buttonOutputDirectory.UseVisualStyleBackColor = true;
            this.buttonOutputDirectory.Click += new System.EventHandler(this.buttonOutputDirectory_Click);
            // 
            // textBoxDirectoryPath
            // 
            this.textBoxDirectoryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDirectoryPath.Location = new System.Drawing.Point(16, 89);
            this.textBoxDirectoryPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDirectoryPath.Name = "textBoxDirectoryPath";
            this.textBoxDirectoryPath.ReadOnly = true;
            this.textBoxDirectoryPath.Size = new System.Drawing.Size(614, 34);
            this.textBoxDirectoryPath.TabIndex = 15;
            // 
            // buttonInputFile
            // 
            this.buttonInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonInputFile.Location = new System.Drawing.Point(665, 32);
            this.buttonInputFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonInputFile.Name = "buttonInputFile";
            this.buttonInputFile.Size = new System.Drawing.Size(137, 38);
            this.buttonInputFile.TabIndex = 12;
            this.buttonInputFile.Text = "Input File";
            this.buttonInputFile.UseVisualStyleBackColor = true;
            this.buttonInputFile.Click += new System.EventHandler(this.buttonInputFile_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxFilePath.Location = new System.Drawing.Point(16, 32);
            this.textBoxFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(614, 34);
            this.textBoxFilePath.TabIndex = 13;
            // 
            // buttonDecode
            // 
            this.buttonDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDecode.Location = new System.Drawing.Point(665, 355);
            this.buttonDecode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(137, 41);
            this.buttonDecode.TabIndex = 10;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // buttonCode
            // 
            this.buttonCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCode.Location = new System.Drawing.Point(493, 355);
            this.buttonCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCode.Name = "buttonCode";
            this.buttonCode.Size = new System.Drawing.Size(137, 41);
            this.buttonCode.TabIndex = 11;
            this.buttonCode.Text = "Code";
            this.buttonCode.UseVisualStyleBackColor = true;
            this.buttonCode.Click += new System.EventHandler(this.buttonCode_Click);
            // 
            // textBoxNewSize
            // 
            this.textBoxNewSize.AllowDrop = true;
            this.textBoxNewSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxNewSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNewSize.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNewSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNewSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNewSize.Location = new System.Drawing.Point(551, 238);
            this.textBoxNewSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNewSize.MaxLength = 15;
            this.textBoxNewSize.Name = "textBoxNewSize";
            this.textBoxNewSize.ReadOnly = true;
            this.textBoxNewSize.Size = new System.Drawing.Size(251, 27);
            this.textBoxNewSize.TabIndex = 2;
            // 
            // textBoxOriginalSize
            // 
            this.textBoxOriginalSize.AllowDrop = true;
            this.textBoxOriginalSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOriginalSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxOriginalSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxOriginalSize.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxOriginalSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOriginalSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxOriginalSize.Location = new System.Drawing.Point(551, 190);
            this.textBoxOriginalSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOriginalSize.MaxLength = 15;
            this.textBoxOriginalSize.Name = "textBoxOriginalSize";
            this.textBoxOriginalSize.ReadOnly = true;
            this.textBoxOriginalSize.Size = new System.Drawing.Size(251, 27);
            this.textBoxOriginalSize.TabIndex = 0;
            // 
            // textBoxTime
            // 
            this.textBoxTime.AllowDrop = true;
            this.textBoxTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxTime.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTime.Location = new System.Drawing.Point(209, 311);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(258, 27);
            this.textBoxTime.TabIndex = 7;
            // 
            // textBoxMemory
            // 
            this.textBoxMemory.AllowDrop = true;
            this.textBoxMemory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxMemory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxMemory.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMemory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMemory.Location = new System.Drawing.Point(209, 355);
            this.textBoxMemory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMemory.Name = "textBoxMemory";
            this.textBoxMemory.ReadOnly = true;
            this.textBoxMemory.Size = new System.Drawing.Size(258, 27);
            this.textBoxMemory.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 440);
            this.Controls.Add(this.textBoxOriginalSize);
            this.Controls.Add(this.labelOriginalSize);
            this.Controls.Add(this.textBoxNewSize);
            this.Controls.Add(this.labelNewSize);
            this.Controls.Add(this.labelAlgorithm);
            this.Controls.Add(this.comboBoxAlgorithmType);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.labelMemory);
            this.Controls.Add(this.textBoxMemory);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonCode);
            this.Controls.Add(this.buttonInputFile);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.buttonOutputDirectory);
            this.Controls.Add(this.textBoxDirectoryPath);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Data Compression";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelNewSize;
        private System.Windows.Forms.Label labelOriginalSize;
        private System.Windows.Forms.Label labelAlgorithm;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelMemory;
        private System.Windows.Forms.ComboBox comboBoxAlgorithmType;
        private System.Windows.Forms.Button buttonOutputDirectory;
        private System.Windows.Forms.TextBox textBoxDirectoryPath;
        private System.Windows.Forms.Button buttonInputFile;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonCode;
        private System.Windows.Forms.TextBox textBoxNewSize;
        private System.Windows.Forms.TextBox textBoxOriginalSize;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxMemory;
    }
}

