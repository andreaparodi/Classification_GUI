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
    public partial class GuiForm : Form
    {
        public GuiForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readData(GlobalVariables.datasetFilePath);
            ImageForm imageForm = new ImageForm();
            Image backGroundImage;
            //TODO: mettere il file immagine di sfondo nel progetto invece di caricarla da percorso, per ora più comodo tenere così

            backGroundImage = imageForm.createImageForm(@"C:\Users\andre\Documents\asset vari\spruz501.png");

            //drawSomething(backGroundImage);
            int stop = 0;
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
            //controllo che ci sia un classificatore selezionato
            if (GlobalVariables.selectedClassifier == 0)
            {
                MessageBox.Show("Nessun classificatore selezionato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //valido il percorso file e lancio messagebox di errore in cui percorso vuoto o file non apribile
                //string errorMessage = "";
                string[] fileContent;
                if (GlobalVariables.datasetFilePath != null)
                {
                    try
                    {
                        fileContent = File.ReadAllLines(path);
                    }
                    catch (Exception e)

                    { 
                        MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                /*
                else
                {
                    errorMessage = "Percorso vuoto";
                    MessageBox.Show(errorMessage, "Path error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                */
                //finiti i controlli apro finestra dove voglio plottare i punti
                // createImageForm(@"C:\Users\andre\Documents\asset vari\trans.png");
            }
        }


        void drawSomething(Image i)
        {
            Graphics g = Graphics.FromImage(i);

            g.DrawEllipse(Pens.DarkBlue, new Rectangle(50, 25, 1, 1));

            g.DrawImage(i, new Point(0, 0));
        }

        public void DrawLineInt(Bitmap bmp)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            int x1 = 100;
            int y1 = 100;
            int x2 = 500;
            int y2 = 100;
            // Draw line to screen.
            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.DrawLine(blackPen, x1, y1, x2, y2);
            }
        }
        #endregion

        //knn
        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            GlobalVariables.selectedClassifier = 1;
        }
        //neural network
        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            GlobalVariables.selectedClassifier = 2;
        }
        //SVN
        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            GlobalVariables.selectedClassifier = 3;
        }
    }
}
