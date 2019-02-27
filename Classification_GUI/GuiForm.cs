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
            Dataset dataset = readData(GlobalVariables.datasetFilePath);
            extractNormalizationFactors(dataset);

            ImageForm imageForm = new ImageForm();
            Image backGroundImage;
            //TODO: mettere il file immagine di sfondo nel progetto invece di caricarla da percorso, per ora più comodo tenere così

            //backGroundImage = imageForm.createImageForm(@"C:\Users\andre\Documents\asset vari\sfondo_GUI_png_501.png");
            
            //inutile
            double[] tetststst = GlobalVariables.normalizationFactor;

            dataset = normalizeDataset(dataset, GlobalVariables.normalizationFactor);

            NN nn = new NN();
            nn.initializeNetwork();
            
            nn.inputLayer.addNode((int)GlobalVariables.nnNodeType.Input);
                
             

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
        // valutare spostamento in Dataset.cs
        Dataset readData(string path)
        {
            Dataset dataset = new Dataset();
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
                        //TODO lettura e gestione dataset

                        //per capire se è già classificato posso contare i ; nella riga, però dovrebbe essere dinamico per poter gestire 
                        //i casi in cui non so il num features e ipotizzando che non so se la prima riga è classified o meno
                        //memo: num features = max numero ; +1
                        bool exit = true;
                        int index = 0;
                        //int numFeatures = 0;
                        do
                        {
                            string[] buffer = fileContent[index].Split(';');
                            if (buffer.Length-1 > GlobalVariables.inputFeatures)
                            { 
                                GlobalVariables.inputFeatures = buffer.Length-1;
                                //se becco una riga più lunga e non parto da zero vuol dire che ho trovato una riga classificata dopo averne lette tot da classificare
                                if (index != 0)
                                {
                                    exit = false;
                                }
                            }
                            //qua esco sicuro perchè ho beccato una riga con meno valori (senza etichetta)
                            else if (buffer.Length-1 < GlobalVariables.inputFeatures)
                            {
                                exit = false;
                            }
                            index++;
                        }
                        while (exit);

                        //metto effettivamente i dati nella struttura dataset
                        foreach (var line in fileContent)
                        {
                            string[] buffer = line.Split(';');
                            ClassifiedDatapoint cdp = new ClassifiedDatapoint();
                            UnclassifiedDatapoint ucdp = new UnclassifiedDatapoint();
                            //è un punto con etichetta
                            if (buffer.Length-1 == GlobalVariables.inputFeatures)
                            {
                                for (int i = 0; i < GlobalVariables.inputFeatures; i++)
                                {
                                    cdp.attributes.Add(Convert.ToDouble(buffer[i]));
                                }
                                cdp.label = Convert.ToInt32(buffer[GlobalVariables.inputFeatures]);
                                dataset.classified_data.Add(cdp);
                            }
                            //altrimenti no
                            else
                            {
                                for (int i = 0; i < GlobalVariables.inputFeatures; i++)
                                {
                                    ucdp.attributes.Add(Convert.ToDouble(buffer[i]));
                                }
                                dataset.unclassified_data.Add(ucdp);
                            }
                        }

                        int stop = 9;
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
            return dataset;
        }

        //può essere portata dentro la funzione di lettura file che crea il dataset
        void extractNormalizationFactors(Dataset dataset)
        {
            double[] maxVal = new double[GlobalVariables.inputFeatures];
            

            for (int feat = 0; feat < GlobalVariables.inputFeatures; feat++)
            {

                foreach (var point in dataset.classified_data)
                {
                    double value = Math.Abs(point.attributes[feat]);
                    if (value > maxVal[feat])
                    {
                        maxVal[feat] = value;
                    }
                }
            }
            GlobalVariables.normalizationFactor = maxVal;
        }
        Dataset normalizeDataset(Dataset dataset, double[] normFactors)
        {
            for (int point = 0;point<dataset.classified_data.Count();point++)
            {
                for (int index = 0; index < GlobalVariables.inputFeatures; index++)
                {
                    dataset.classified_data[point].attributes[index] = dataset.classified_data[point].attributes[index] / normFactors[index];
                }
            }
            for (int point = 0; point < dataset.unclassified_data.Count(); point++)
            {
                for (int index = 0; index < GlobalVariables.inputFeatures; index++)
                {
                    dataset.unclassified_data[point].attributes[index] = dataset.unclassified_data[point].attributes[index] / normFactors[index];
                }
            }
            return dataset;
        }

        void drawSomething(Image i)
        {
            Graphics g = Graphics.FromImage(i);

            g.DrawEllipse(Pens.DarkBlue, new Rectangle(50, 25, 1, 1));

            g.DrawImage(i, new Point(0, 0));
        }
        /*
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
        }*/

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
