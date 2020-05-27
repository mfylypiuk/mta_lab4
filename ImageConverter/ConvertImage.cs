using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ImageConverter
{
    class ConvertImage
    {

        private string specialPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string Rename(string file, string ext)
        {
            int count = 1;
            string newFile = file;

            while (File.Exists(specialPath + "\\" + newFile + ext))
            {
                newFile = string.Format("{0}({1})", newFile, count++);
            }
            return newFile;
        }

        public ConvertImage()
        {
            if (!Directory.Exists(specialPath))
            {
                Directory.CreateDirectory(specialPath);
            }
        }


        public void ConvertImageTo(string filename, string ext, string Image)
        {
            Bitmap image;
            image = new Bitmap(Image);
            switch (ext)
            {
                case ".png":
                    image.Save(specialPath + "\\" + Rename(filename, ext) + ext, ImageFormat.Png);
                    break;
                case ".jpg":
                    image.Save(specialPath + "\\" + Rename(filename, ext) + ext, ImageFormat.Jpeg);
                    break;
                case ".bmp":
                    image.Save(specialPath + "\\" + Rename(filename, ext) + ext, ImageFormat.Bmp);
                    break;
                default:
                    image.Save(specialPath + "\\" + Rename(filename, ext) + ext, ImageFormat.Png);
                    break;
            }

        }

        public string GetPath()
        {
            return specialPath;
        }
    }
}
