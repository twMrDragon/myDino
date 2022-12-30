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
    public class showPixelNumber : Panel
    {
        private Image[] numberImages = null;

        public Image[] NumberImages
        {
            get => numberImages;
            set => numberImages = value;
        }

        public showPixelNumber()
        {

        }

    }
}
