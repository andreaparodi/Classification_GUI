using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Classification_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readData(GlobalVariables.datasetFilePath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|Comma Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            string path = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            textBox1.Text = path;
            GlobalVariables.datasetFilePath = path;
        }





        #region funzioni varie

        //lettura dati da file attraverso finestra di dialogo
        void readData(string path)
        {
            //valido il percorso file e lancio messagebox di errore in cui percorso vuoto o file non apribile
            string errorMessage = "";
            string[] fileContent;
            if (GlobalVariables.datasetFilePath != null)
            {
                try
                {
                    fileContent = File.ReadAllLines(path);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Path error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                errorMessage = "Percorso vuoto";
                MessageBox.Show(errorMessage, "Path error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
