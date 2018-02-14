namespace Day8_TrackTheMario
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vspMain = new Accord.Controls.VideoSourcePlayer();
            this.pbThreshold = new System.Windows.Forms.PictureBox();
            this.pbMasked = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasked)).BeginInit();
            this.SuspendLayout();
            // 
            // vspMain
            // 
            this.vspMain.Location = new System.Drawing.Point(0, -2);
            this.vspMain.Name = "vspMain";
            this.vspMain.Size = new System.Drawing.Size(793, 468);
            this.vspMain.TabIndex = 0;
            this.vspMain.Text = "videoSourcePlayer1";
            this.vspMain.VideoSource = null;
            this.vspMain.NewFrame += new Accord.Controls.VideoSourcePlayer.NewFrameHandler(this.vspMain_NewFrame);
            // 
            // pbThreshold
            // 
            this.pbThreshold.Location = new System.Drawing.Point(0, 472);
            this.pbThreshold.Name = "pbThreshold";
            this.pbThreshold.Size = new System.Drawing.Size(405, 218);
            this.pbThreshold.TabIndex = 1;
            this.pbThreshold.TabStop = false;
            // 
            // pbMasked
            // 
            this.pbMasked.Location = new System.Drawing.Point(408, 472);
            this.pbMasked.Name = "pbMasked";
            this.pbMasked.Size = new System.Drawing.Size(382, 218);
            this.pbMasked.TabIndex = 2;
            this.pbMasked.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(831, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 693);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbMasked);
            this.Controls.Add(this.pbThreshold);
            this.Controls.Add(this.vspMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Accord.Controls.VideoSourcePlayer vspMain;
        private System.Windows.Forms.PictureBox pbThreshold;
        private System.Windows.Forms.PictureBox pbMasked;
        private System.Windows.Forms.Button button1;
    }
}