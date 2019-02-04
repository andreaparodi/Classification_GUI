using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classification_GUI
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
        }

        private void ImageForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random rnd = new Random();
            Rectangle[] myrects = new Rectangle[1000];
            for (int i = 0; i < 1000; i++)
                myrects[i] = new Rectangle(rnd.Next(0, this.Width), rnd.Next(0, this.Height), 1, 1);
            g.FillRectangles(Brushes.Red, myrects);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        public Image createImageForm(string path)
        {
            //ImageForm imageForm = new ImageForm();

            //PictureBox guiBackground = new PictureBox();
            PictureBox guiBackground = pictureBox1;
            //Bitmap guiBackGround =  
            guiBackground.Dock = DockStyle.Fill;
            guiBackground.Image = Image.FromFile(path);


            //guiBackground.Image = Image.FromFile(@"C:\Users\andre\Documents\asset vari\sfondo_gui_png.png");

            //guiBackground.SizeMode = PictureBoxSizeMode.StretchImage;

            //rendo il form della stessa grandezza dell'immagine senza stare a scriverlo su globals
            this.Size = guiBackground.Image.Size;
            //e lo rendo non stretchabile
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Controls.Add(guiBackground);

            Image img = guiBackground.Image;

            this.ShowDialog();
            this.Update();
            return img;
            /*
            int pause = 0;
            Image img = guiBackground.Image;
            Graphics g = Graphics.FromImage(img);

            g.DrawEllipse(Pens.DarkBlue, new Rectangle(50, 25, 1, 1));

            g.DrawImage(img, new Point(0, 0));
            */
            // guiBackground.Image.SetPixel(15, 15, Color.Red);

        }
    }
}
