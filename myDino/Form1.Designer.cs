namespace myDino
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.characterAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.showPixelNumber1 = new myDino.showPixelNumber();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPixelNumber1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 441);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "0";
            // 
            // characterAnimationTimer
            // 
            this.characterAnimationTimer.Interval = 50;
            this.characterAnimationTimer.Tick += new System.EventHandler(this.characterAnimationTimer_Tick);
            // 
            // showPixelNumber1
            // 
            this.showPixelNumber1.Image = ((System.Drawing.Image)(resources.GetObject("showPixelNumber1.Image")));
            this.showPixelNumber1.Location = new System.Drawing.Point(501, 172);
            this.showPixelNumber1.Name = "showPixelNumber1";
            this.showPixelNumber1.Size = new System.Drawing.Size(279, 323);
            this.showPixelNumber1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showPixelNumber1.TabIndex = 1;
            this.showPixelNumber1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.showPixelNumber1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPixelNumber1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer characterAnimationTimer;
        private showPixelNumber showPixelNumber1;
    }
}

