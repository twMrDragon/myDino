using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myDino
{
    public class showPixelNumber:PictureBox
    {
        private string test = @"C:\Users\Joseph\source\repos\myDino\myDino\bin\Debug\pixelNumberBlack\tile000.png";
        public showPixelNumber()
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            using (FileStream fs = File.OpenRead(test))
            {
                Image image = Image.FromStream(fs);
                this.Image = image;
            }
        }
    }
}
