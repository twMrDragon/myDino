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
        //在程式執行時會載入
        Image[] characterImages = null;
        Image[] pokemonBallImage = null;
        Image myBackgroundImage = null;
        Image restartImage = null;
        List<pokemonBall> pokemonBalls = new List<pokemonBall>();

        //背景參數
        int backgroundOffset = 0;
        //分數
        int score = 0;

        //腳色參數
        Point characterLocation = new Point(11, 320);
        Size characterSize = new Size(80, 80);
        int characterImageIndex = 0;
        int characterVerticalSpeed = 0;
        int characterVerticalAcceleration = 0;
        int groundY = 0;

        enum gameState
        {
            playing,
            end
        }
        gameState nowGameState = gameState.end;

        //載入角色圖片
        private void loadCharacterImage()
        {
            string characterFolderName = System.Windows.Forms.Application.StartupPath + @"\..\..\character";
            characterImages = loadImages(characterFolderName);
        }

        //載入精靈球圖片
        private void loadPokemonBallImage()
        {
            string characterFolderName = System.Windows.Forms.Application.StartupPath + @"\..\..\pokemonBall";
            pokemonBallImage = loadImages(characterFolderName);
        }

        //載入資料夾圖片圖片
        private Image[] loadImages(string folderPath)
        {
            List<Image> images = new List<Image>();
            //讀取腳色資料夾下的全部檔案名稱
            foreach (string filename in System.IO.Directory.GetFiles(folderPath))
            {
                using (FileStream fs = File.OpenRead(filename))
                {
                    Image image = Image.FromStream(fs);
                    images.Add(image);
                }
            }
            return images.ToArray();
        }
        private Image loadImage(string path)
        {
            Image image = null;
            using (FileStream fs = File.OpenRead(path))
            {
                image = Image.FromStream(fs);
            }
            return image;
        }

        //載入資源圖片
        private void loadResImage()
        {
            string resPath = System.Windows.Forms.Application.StartupPath + @"\..\..\res\";
            myBackgroundImage = loadImage(resPath + "background.jpg");
            this.BackgroundImage = myBackgroundImage;
            restartImage = loadImage(resPath + "restart.png");
        }

        //變更遊戲狀態
        private void changeGameState()
        {
            //切換遊戲狀態
            if (nowGameState == gameState.playing)
                nowGameState = gameState.end;
            else
            {
                nowGameState = gameState.playing;
            }
            changeTimerEnable();
        }

        //產生新的精靈球
        private void createBall()
        {
            pokemonBall lastBall = pokemonBalls.LastOrDefault();
            //沒球或是最遠的球小於1/3
            if (lastBall == null || lastBall.rectangle.X + lastBall.rectangle.Width < this.Width / 3)
            {
                Random random = new Random(DateTime.Now.Millisecond);
                pokemonBall newBall = new pokemonBall()
                {
                    ball = pokemonBallImage[random.Next(pokemonBallImage.Length)],
                    rotate = random.Next(360),
                };
                newBall.rectangle.X = this.Width + random.Next(75);
                newBall.rectangle.Y = random.Next(20, 50) + 320;
                pokemonBalls.Add(newBall);
            }
        }

        //重新開始
        private void restartGame()
        {
            score = 0;
            characterLocation.Y = groundY;
            characterVerticalSpeed = 0;
            characterVerticalAcceleration = 0;
            int len = pokemonBalls.Count;
            for (int i = 0; i < len; i++)
            {
                pokemonBalls.RemoveAt(0);
            }
        }

        //程式進入點
        public Form1()
        {
            InitializeComponent();
            //載入圖片
            loadCharacterImage();
            loadPokemonBallImage();
            loadResImage();
            //初始化資料
            this.BackgroundImage = makeScreen();
            groundY = characterLocation.Y;
        }

        //製作背景
        private Bitmap makeBackground()
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(
                    myBackgroundImage,
                    new Rectangle(-backgroundOffset, 0, this.Width, this.Height));
                graphics.DrawImage(
                   myBackgroundImage,
                   new Rectangle(this.Width - backgroundOffset - 2, 0, this.Width, this.Height));
            }
            return bitmap;
        }

        //製作腳色動畫(切換腳色圖片)
        private void makeCharacterAnimation()
        {
            //切換腳色圖片
            characterImageIndex += 1;

            //到達最後一個圖片
            if (characterImageIndex == characterImages.Length)
                characterImageIndex = 0;
        }

        //繪製整個畫面
        private Bitmap makeScreen()
        {
            //check need to add ball
            createBall();
            updateBallLocation();

            Bitmap bitmap = makeBackground();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                //draw character
                graphics.DrawImage(
                    characterImages[characterImageIndex],
                    new Rectangle(
                        characterLocation,
                        characterSize
                        )
                    );
                //draw ball
                foreach (pokemonBall ball in pokemonBalls)
                {
                    graphics.DrawImage(
                        ball.getBall(),
                        ball.rectangle
                        );
                }
            }
            return bitmap;
        }

        //更新精靈球位置
        private void updateBallLocation()
        {
            List<pokemonBall> deletePokemonBall = new List<pokemonBall>();
            foreach (pokemonBall ball in pokemonBalls)
            {
                ball.rectangle.X -= ball.speed;
                ball.rotate -= 5;
                if (ball.rectangle.Width + ball.rectangle.X < 0)
                    deletePokemonBall.Add(ball);
            }
            foreach (pokemonBall ball in deletePokemonBall)
            {
                pokemonBalls.Remove(ball);
            }
        }

        //是否與精靈球碰撞
        private bool isCollisionPokemonBall()
        {
            Rectangle characterHitbox = new Rectangle(
                characterLocation.X + 20, characterLocation.Y, characterSize.Width - 40, characterSize.Height
                );
            foreach (pokemonBall ball in pokemonBalls)
            {
                if (characterHitbox.IntersectsWith(ball.rectangle))
                {
                    return true;
                }
            }
            return false;
        }

        //變更timer(切換遊戲狀態時)
        private void changeTimerEnable()
        {
            Timer[] timers = {
                backgroundTimer,
                scoreTimer,
                jumpTimer,
                mainTimer,
                characterAnimationTimer
            };

            foreach (Timer timer in timers)
                timer.Enabled = (nowGameState == gameState.playing);
        }

        //鍵盤操作
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (nowGameState == gameState.end && e.KeyCode == Keys.Space)
            {
                restartGame();
                changeGameState();
            }
            else if (e.KeyCode == Keys.Space)
            {
                //jump
                //在地面時才可以跳躍
                if (characterLocation.Y >= groundY)
                    characterVerticalAcceleration = 2;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (characterLocation.Y < groundY)
                {
                    characterVerticalAcceleration = -6;
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            characterVerticalAcceleration = -2;
        }

        //重製腳色參數(接觸到地板時重製位置、速度及加速度)
        private void resetCharacter()
        {
            if (characterLocation.Y >= groundY)
            {
                characterLocation.Y = groundY;
                characterVerticalSpeed = 0;
                characterVerticalAcceleration = 0;
            }
        }

        //製作背景動畫(更改背景座標)
        private void backgroundTimer_Tick(object sender, EventArgs e)
        {
            this.backgroundOffset = (this.backgroundOffset + 2) % this.Width;
        }

        //完成跳躍功能
        private void jumpTimer_Tick(object sender, EventArgs e)
        {
            //跳起落下
            characterVerticalSpeed += characterVerticalAcceleration;
            characterLocation.Y -= characterVerticalSpeed;
            //跳到最高
            if (characterVerticalSpeed == 18)
                characterVerticalAcceleration = -2;
            resetCharacter();
        }

        //主要幀數
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (this.BackgroundImage != null)
                this.BackgroundImage.Dispose();
            this.BackgroundImage = makeScreen();
            if (isCollisionPokemonBall())
            {
                changeGameState();
                drawRestartButton();
            }
        }
        private void drawRestartButton()
        {
            Image image = this.BackgroundImage;
            Size restartSize = new Size(100, 100);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.DrawImage(
                    restartImage,
                    (this.Width - restartSize.Width) / 2,
                    (this.Height - restartSize.Height) / 2,
                    restartSize.Width,
                    restartSize.Height
                    );
            }
        }

        //角色動畫timer
        private void characterAnimationTimer_Tick(object sender, EventArgs e)
        {
            //character
            makeCharacterAnimation();
        }

        //分數更新
        private void scoreTimer_Tick(object sender, EventArgs e)
        {
            score += 2;
            label1.Text = score.ToString();
        }
    }
    //精靈球class
    public class pokemonBall
    {
        public Image ball;
        public Rectangle rectangle = new Rectangle(0, 0, 30, 30);
        public int rotate;
        public int speed = new Random().Next(5, 10);

        public Image getBall()
        {
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.TranslateTransform(bitmap.Width / 2, bitmap.Height / 2);
                graphics.RotateTransform(rotate);
                graphics.TranslateTransform(-bitmap.Width / 2, -bitmap.Height / 2);
                graphics.DrawImage(ball, 0, 0, rectangle.Width, rectangle.Height);
            }
            return bitmap;
        }
    }
}