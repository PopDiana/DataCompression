using DataCompression.Interfaces;
using DataCompression.Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DataCompression
{
    public partial class MainForm : Form
    {
        private byte[] dataBytes;
        private string fileName;
        private BindingList<string> algorithmTypeList;
        ICompression compression;

        public MainForm()
        {
            InitializeComponent();
            this.textBoxDirectoryPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

            this.algorithmTypeList = new BindingList<string> { "LZ4", "Deflate", "GZip", "ZStandard"};

            this.comboBoxAlgorithmType.DataSource = algorithmTypeList;

            this.MaximizeBox = false;
        }

        private void buttonInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogInput = new OpenFileDialog();

            openFileDialogInput.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            openFileDialogInput.RestoreDirectory = true;

            if (openFileDialogInput.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream myStream = openFileDialogInput.OpenFile())
                    {
                        if (myStream != null)
                        {
                            dataBytes = new byte[myStream.Length];

                            myStream.Read(dataBytes, 0, dataBytes.Length);

                            textBoxFilePath.Text = openFileDialogInput.FileName;

                            fileName = openFileDialogInput.SafeFileName;

                            buttonCode.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }

        }

        private void buttonOutputDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
                this.textBoxDirectoryPath.Text = folderBrowserDialog1.SelectedPath + "\\";
        }

        private void GetUsedMemory()
        {
            long beforeCollection = GC.GetTotalMemory(false);
            long afterCollection = GC.GetTotalMemory(true);
            var memoryUsed = beforeCollection - afterCollection;
            textBoxMemory.Text = memoryUsed.ToString() + " bytes";
        }

        private void GetElapsedTime(Stopwatch stopwatch)
        {
            textBoxTime.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
        }

        private void GetOriginalSize()
        {
            textBoxOriginalSize.Text = Convert.ToUInt32(dataBytes.Length).ToString() + " bytes";
        }

        private void GetNewSize(bool decode = false)
        {
            textBoxNewSize.Text = (decode? this.compression.Decompress(textBoxFilePath.Text, 
                this.textBoxDirectoryPath.Text + fileName + ".decomp") : this.compression.Compress(textBoxFilePath.Text,
                this.textBoxDirectoryPath.Text)).ToString() + " bytes";
        }

        private void CodeDecode(bool decode)
        {
            Stopwatch stopwatch = new Stopwatch();
            GetOriginalSize();
            stopwatch.Start();
            CompressionType t = (CompressionType)algorithmTypeList.IndexOf(comboBoxAlgorithmType.SelectedItem.ToString());
            this.compression = CompressionFactory.CreateAlgorithm(t);
            GetNewSize(decode);
            stopwatch.Stop();
            GetElapsedTime(stopwatch);
            GetUsedMemory();
        }

        private void buttonCode_Click(object sender, EventArgs e)
        {
            CodeDecode(false);
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            CodeDecode(true);
        }
    }
}
