using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myDino
{
    public partial class Form1 : Form
    {
        string floderName = System.Windows.Forms.Application.StartupPath + @"\character";
        Image[] characterImages = null;
        enum gameState
        {
            playing,
            end
        }
        gameState nowGameState = gameState.end;
        private void getCharacterImage()
        {
            List<Image> images = new List<Image>();
            //讀取腳色資料夾下的全部檔案名稱
            foreach (string filename in System.IO.Directory.GetFiles(floderName))
            {
                using (FileStream fs = File.OpenRead(filename))
                {
                    Image image = Image.FromStream(fs);
                    images.Add(image);
                }
            }
            characterImages = images.ToArray();
        }
        private void changeGameState()
        {
            //切換遊戲狀態
            if (nowGameState == gameState.playing)
                nowGameState = gameState.end;
            else
                nowGameState = gameState.playing;
            changeTimerEnable();
        }
        private void changeTimerEnable()
        {
            if (nowGameState == gameState.playing)
            {
                characterAnimationTimer.Enabled = true;
            }
            else if (nowGameState == gameState.end)
            {
                characterAnimationTimer.Enabled = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            getCharacterImage();
            //預設腳色圖片
            if (characterImages != null && characterImages.Length != 0)
                pictureBox1.Image = characterImages[0];

            //獲取已安裝字體
            //InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            //comboBox1.Items.AddRange(installedFontCollection.Families.Select(x=>x.Name).ToArray());
        }

        private void characterAnimationTimer_Tick(object sender, EventArgs e)
        {
            //切換腳色圖片
            int nowImageIndex = int.Parse(pictureBox1.Tag.ToString());
            nowImageIndex += 1;
            //到達最後一個圖片
            if (nowImageIndex == characterImages.Length)
                nowImageIndex = 0;
            pictureBox1.Tag = nowImageIndex;
            pictureBox1.Image = characterImages[nowImageIndex];
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (nowGameState == gameState.end && e.KeyCode == Keys.Space)
            {
                changeGameState();
            }
            else
            {
                //jump
            }
        }
    }

}
