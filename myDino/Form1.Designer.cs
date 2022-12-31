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
            this.backgroundTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreTimer = new System.Windows.Forms.Timer(this.components);
            this.jumpTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.characterAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // backgroundTimer
            // 
            this.backgroundTimer.Interval = 5;
            this.backgroundTimer.Tick += new System.EventHandler(this.backgroundTimer_Tick);
            // 
            // scoreTimer
            // 
            this.scoreTimer.Interval = 50;
            this.scoreTimer.Tick += new System.EventHandler(this.scoreTimer_Tick);
            // 
            // jumpTimer
            // 
            this.jumpTimer.Interval = 20;
            this.jumpTimer.Tick += new System.EventHandler(this.jumpTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 10;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // characterAnimationTimer
            // 
            this.characterAnimationTimer.Tick += new System.EventHandler(this.characterAnimationTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(736, 442);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer backgroundTimer;
        private System.Windows.Forms.Timer scoreTimer;
        private System.Windows.Forms.Timer jumpTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Timer characterAnimationTimer;
    }
}

