using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadesOfGray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch 
                {
                    MessageBox.Show("Неможливо відкрити обраний файл", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) 
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Зберегти зображення як...";
                sfd.OverwritePrompt = true; 
                sfd.CheckPathExists = true; 
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                sfd.ShowHelp = true; 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch 
                    {
                        MessageBox.Show("Неможливо відкрити обраний файл", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


private void grayButton_Click(object sender, EventArgs e)
{
    if (pictureBox1.Image != null) 
    {
        
        Bitmap input = new Bitmap(pictureBox1.Image);
        
        Bitmap output = new Bitmap(input.Width, input.Height);
        
        for (int j = 0; j < input.Height; j++)
            for (int i = 0; i < input.Width; i++)
            {
                
                UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                
                float R = (float)((pixel & 0x00FF0000) >> 16); 
                float G = (float)((pixel & 0x0000FF00) >> 8); 
                float B = (float)(pixel & 0x000000FF); 
                
                R = G = B = (R + G + B) / 3.0f;
                
                UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                
                output.SetPixel(i, j, Color.FromArgb((int)newPixel));
            }
        
        pictureBox2.Image = output;
    }
}

        private void mono_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            Color color = new Color();

            try
            {
                for (int j = 0; j < result.Height; j++)
                {
                    for (int i = 0; i < result.Width; i++)
                    {
                        color = result.GetPixel(i, j);
                        int K = (color.R + color.G + color.B) / 3;
                        result.SetPixel(i, j, (K <= 120 ? Color.Black : Color.White));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pictureBox2.Image = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cmPicture = new ColorMatrix(new float[][]
            {
                new float[]{.393f+0.3f, .349f, .272f, 0, 0},
                new float[]{.769f, .686f+0.2f, .534f, 0, 0},
                new float[]{.189f, .168f, .131f+0.9f, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 1}
            });

            ia.SetColorMatrix(cmPicture);
            
            Graphics g = Graphics.FromImage(bmpInverted);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            
            pictureBox2.Image = bmpInverted;
        }
    }
}
