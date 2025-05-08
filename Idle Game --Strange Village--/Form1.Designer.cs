namespace Idle_Game___Strange_Village__
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FirstHouse = new System.Windows.Forms.Timer(this.components);
            this.Dollars = new System.Windows.Forms.Timer(this.components);
            this.Vérif = new System.Windows.Forms.Timer(this.components);
            this.autoBirdie_Timer = new System.Windows.Forms.Timer(this.components);
            this.WAluigiTimer = new System.Windows.Forms.Timer(this.components);
            this.background1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CrazyFrogTimer = new System.Windows.Forms.Timer(this.components);
            this.XP_TIMER = new System.Windows.Forms.Timer(this.components);
            this.background1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstHouse
            // 
            this.FirstHouse.Enabled = true;
            this.FirstHouse.Interval = 1000;
            this.FirstHouse.Tick += new System.EventHandler(this.FirstHouse_Tick);
            // 
            // Dollars
            // 
            this.Dollars.Enabled = true;
            this.Dollars.Interval = 1;
            this.Dollars.Tick += new System.EventHandler(this.Dollars_Tick);
            // 
            // Vérif
            // 
            this.Vérif.Enabled = true;
            this.Vérif.Interval = 1;
            this.Vérif.Tick += new System.EventHandler(this.Vérif_Tick);
            // 
            // autoBirdie_Timer
            // 
            this.autoBirdie_Timer.Enabled = true;
            this.autoBirdie_Timer.Interval = 1000;
            this.autoBirdie_Timer.Tick += new System.EventHandler(this.autoBirdie_Timer_Tick);
            // 
            // WAluigiTimer
            // 
            this.WAluigiTimer.Enabled = true;
            this.WAluigiTimer.Interval = 2000;
            this.WAluigiTimer.Tick += new System.EventHandler(this.WAluigiTimer_Tick);
            // 
            // background1
            // 
            this.background1.BackColor = System.Drawing.Color.Transparent;
            this.background1.BackgroundImage = global::Idle_Game___Strange_Village__.Properties.Resources.Background;
            this.background1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.background1.Controls.Add(this.label10);
            this.background1.Controls.Add(this.pictureBox4);
            this.background1.Controls.Add(this.label9);
            this.background1.Controls.Add(this.label8);
            this.background1.Controls.Add(this.label7);
            this.background1.Controls.Add(this.pictureBox3);
            this.background1.Controls.Add(this.button2);
            this.background1.Controls.Add(this.label6);
            this.background1.Controls.Add(this.label5);
            this.background1.Controls.Add(this.pictureBox2);
            this.background1.Controls.Add(this.label4);
            this.background1.Controls.Add(this.label3);
            this.background1.Controls.Add(this.label2);
            this.background1.Controls.Add(this.label1);
            this.background1.Controls.Add(this.pictureBox1);
            this.background1.Location = new System.Drawing.Point(0, -450);
            this.background1.Name = "background1";
            this.background1.Size = new System.Drawing.Size(804, 977);
            this.background1.TabIndex = 0;
            this.background1.SizeChanged += new System.EventHandler(this.background1_SizeChanged);
            this.background1.Click += new System.EventHandler(this.background1_Click);
            this.background1.Paint += new System.Windows.Forms.PaintEventHandler(this.background1_Paint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(313, 734);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 15;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Idle_Game___Strange_Village__.Properties.Resources.CrazyFrogLocked;
            this.pictureBox4.Location = new System.Drawing.Point(240, 600);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(168, 168);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(614, 852);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 50);
            this.label9.TabIndex = 13;
            this.label9.Text = "Niveau : 1\r\nExp : 0 / 100";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(123, 871);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(722, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "niveau : 1";
            this.label7.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Idle_Game___Strange_Village__.Properties.Resources.WaluigiLocked;
            this.pictureBox3.Location = new System.Drawing.Point(34, 728);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(191, 186);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(713, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Auto Birdie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(394, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "V\r\nV\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::Idle_Game___Strange_Village__.Properties.Resources._3ooRmVBloqued;
            this.pictureBox2.Location = new System.Drawing.Point(342, 148);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(384, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 62);
            this.label4.TabIndex = 5;
            this.label4.Text = "^\r\n^";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(512, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Niveau : 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(530, 712);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Money : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Idle_Game___Strange_Village__.Properties.Resources.sr5z7f7962affaaws3;
            this.pictureBox1.Location = new System.Drawing.Point(472, 574);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CrazyFrogTimer
            // 
            this.CrazyFrogTimer.Enabled = true;
            this.CrazyFrogTimer.Interval = 1000;
            this.CrazyFrogTimer.Tick += new System.EventHandler(this.CrazyFrogTimer_Tick);
            // 
            // XP_TIMER
            // 
            this.XP_TIMER.Enabled = true;
            this.XP_TIMER.Interval = 1;
            this.XP_TIMER.Tick += new System.EventHandler(this.XP_TIMER_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(798, 460);
            this.Controls.Add(this.background1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.background1.ResumeLayout(false);
            this.background1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel background1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer FirstHouse;
        private System.Windows.Forms.Timer Dollars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Vérif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer autoBirdie_Timer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer WAluigiTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer CrazyFrogTimer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer XP_TIMER;
    }
}

