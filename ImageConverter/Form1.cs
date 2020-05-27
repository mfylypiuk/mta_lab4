using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ImageConverter
{
    public partial class ImageConverter : Form
    {
        private FileFetcher fileFetcher = null;

        public ImageConverter()
        {
            InitializeComponent();
            this.Text = string.Empty;
        }

        private void ImageConverter_Load(object sender, EventArgs e)
        {
            this.Text = "Lab4.1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fileFetcher != null && !fileFetcher.IsEmpty())
            {
                ConvertImage con = new ConvertImage();
                string[] fileNames = fileFetcher.GetFileNames();
                string[] extensions = fileFetcher.GetExtension();
                string[] image = fileFetcher.GetFileWithPath();
                string ext = ".png";

                for (int i = 0; i < fileNames.Length; i++)
                {
                    con.ConvertImageTo(fileNames[i], ext, image[i]);
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (fileFetcher != null && !fileFetcher.IsEmpty())
            {
                ConvertImage con = new ConvertImage();
                string[] fileNames = fileFetcher.GetFileNames();
                string[] extensions = fileFetcher.GetExtension();
                string[] image = fileFetcher.GetFileWithPath();
                string ext = ".jpg";

                for (int i = 0; i < fileNames.Length; i++)
                {
                    con.ConvertImageTo(fileNames[i], ext, image[i]);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (fileFetcher != null && !fileFetcher.IsEmpty())
            {
                ConvertImage con = new ConvertImage();
                string[] fileNames = fileFetcher.GetFileNames();
                string[] extensions = fileFetcher.GetExtension();
                string[] image = fileFetcher.GetFileWithPath();
                string ext = ".bmp";

                for (int i = 0; i < fileNames.Length; i++)
                {
                    con.ConvertImageTo(fileNames[i], ext, image[i]);
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = null;
            string[] filePath = null;
            fileFetcher = new FileFetcher();

            path = fileFetcher.Fetch("files");
            filePath = fileFetcher.GetFileWithPath();

            if (path != null)
            {
                this.path.Text = filePath.FirstOrDefault();
            }
        }
    }
}
