namespace finalproject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            start = new Button();
            NewGame = new Button();
            count = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            timerM = new Label();
            SizeChoose = new ComboBox();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(25, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(555, 555);
            panel1.TabIndex = 0;
            // 
            // start
            // 
            start.Location = new Point(612, 25);
            start.Name = "start";
            start.Size = new Size(150, 46);
            start.TabIndex = 1;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // NewGame
            // 
            NewGame.Location = new Point(612, 25);
            NewGame.Name = "NewGame";
            NewGame.Size = new Size(150, 46);
            NewGame.TabIndex = 2;
            NewGame.Text = "New Game";
            NewGame.UseVisualStyleBackColor = true;
            NewGame.Click += NewGame_Click;
            // 
            // count
            // 
            count.Location = new Point(612, 241);
            count.Name = "count";
            count.Size = new Size(142, 32);
            count.TabIndex = 3;
            count.Text = "☆ : 0";
            count.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // timerM
            // 
            timerM.Location = new Point(637, 311);
            timerM.Name = "timerM";
            timerM.Size = new Size(100, 32);
            timerM.TabIndex = 4;
            timerM.Text = "00 : 00";
            timerM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SizeChoose
            // 
            SizeChoose.FormattingEnabled = true;
            SizeChoose.Items.AddRange(new object[] { "9x9", "16x16" });
            SizeChoose.Location = new Point(612, 89);
            SizeChoose.Name = "SizeChoose";
            SizeChoose.Size = new Size(150, 40);
            SizeChoose.TabIndex = 5;
            SizeChoose.SelectedIndexChanged += SizeChoose_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 679);
            Controls.Add(SizeChoose);
            Controls.Add(timerM);
            Controls.Add(count);
            Controls.Add(NewGame);
            Controls.Add(start);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button start;
        private Button NewGame;
        private Label count;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Label timerM;
        private ComboBox SizeChoose;
    }
}