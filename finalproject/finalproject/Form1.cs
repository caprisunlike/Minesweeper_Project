namespace finalproject
{
    public partial class Form1 : Form
    {
        MineButton[,] button;
        int cell_cnt = 9;
        int mine_cnt = 10;
        int f_cnt = 0;
        int correct = 0;
        int gap = 1;
        Label over;
        public Form1()
        {
            InitializeComponent();
            SizeChoose.SelectedIndex = 0;
        }

        private void NewGame_Click(object sender, EventArgs e)   // �� ���� ���� �Լ�
        {
            if (over != null) over.Dispose();
            NewGame.Visible = false;
            SizeChoose.Visible = false;
            start.Visible = true;
            int px = panel1.Location.X;
            int py = panel1.Location.Y;
            float cx = (float)panel1.Width / cell_cnt;
            float cy = (float)panel1.Height / cell_cnt;
            using (Graphics g = panel1.CreateGraphics())
            {
                // �� ����
                button = new MineButton[cell_cnt, cell_cnt];
                for (int i = 0; i < cell_cnt; i++)
                {
                    for (int j = 0; j < cell_cnt; j++)
                    {
                        button[i, j] = new MineButton();
                        button[i, j].x_idx = j; button[i, j].y_idx = i;
                        button[i, j].Location = new Point((int)cx * j + gap, (int)cx * i + gap);
                        button[i, j].Size = new Size((int)cx, (int)cy);
                        button[i, j].MouseDown += btn_click;
                        panel1.Controls.Add(button[i, j]);
                    }
                }
                // ���� ����
                Random rand = new Random();
                for (int i = 0; i < mine_cnt; i++)
                {
                    int u = rand.Next(0, cell_cnt);
                    int v = rand.Next(0, cell_cnt);
                    if (!button[u, v].isMine)
                    {
                        button[u, v].isMine = true;
                        for (int j = -1; j <= 1; j++)
                        {
                            for (int k = -1; k <= 1; k++)
                            {
                                if (u + j < 0 || u + j >= cell_cnt) continue;
                                if (v + k < 0 || v + k >= cell_cnt) continue;
                                button[u + j, v + k].cnt++;
                            }
                        }
                    }
                    else
                    {
                        i--;
                    }
                }

                // ���� ���� ��
                count.Text = "�� : " + mine_cnt.ToString();

                if (Toggle == false)
                {
                    timer1.Start();
                    timer2.Start();
                    Toggle = true;
                    start.Text = "Pause";
                }
            }
        }
        private void start_Click(object sender, EventArgs e)   // ���� Start-Pause ��ư
        {
            // Ÿ�̸� ����
            if (Toggle == false)
            {
                timer1.Start();
                timer2.Start();
                Toggle = true;
                start.Text = "Pause";
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                Toggle = false;
                start.Text = "Start";
            }
        }
        public void btn_click(object sender, MouseEventArgs e)   // ��� Ŭ�� �Լ�
        {
            MineButton btn = sender as MineButton;
            // ���콺 ���� Ŭ������ ��
            if (e.Button == MouseButtons.Left && btn.Image == null && Toggle == true)
            {
                if (btn.isMine)
                {
                    Thread.Sleep(1000);
                    ResetWindow();
                    over = new Label();
                    over.Text = "Game Over!";
                    over.Width = 555; over.Height = 555;
                    over.Font = new Font("Berlin Sans FB", 30, FontStyle.Regular);
                    over.TextAlign = ContentAlignment.MiddleCenter;
                    panel1.Controls.Add(over);
                }
                else
                {
                    if (btn.cnt == 0)
                    {
                        freeMine(btn.x_idx, btn.y_idx);
                    }
                    else
                    {
                        chooseButton(btn);
                    }
                }
            }
            // ���콺 ������ Ŭ������ ��
            if (e.Button == MouseButtons.Right && btn.BackColor != Color.Gray && Toggle == true)
            {
                if (!btn.flag)
                {
                    string imagePath = "flag.png";
                    Image image = Image.FromFile(imagePath);
                    btn.Image = image;

                    btn.flag = !btn.flag;
                    f_cnt++;
                    if (btn.isMine) correct++;
                }
                else
                {
                    btn.Image = null;
                    btn.flag = !btn.flag;
                    f_cnt--;
                    if (btn.isMine) correct--;
                }
                count.Text = "�� : " + (mine_cnt - f_cnt).ToString();
            }

            // ���ڸ� ��� ã���� ��
            if (correct == mine_cnt)
            {
                Thread.Sleep(1000);
                ResetWindow();
                over = new Label();
                over.Text = "Success!";
                over.Width = 555; over.Height = 555;
                over.Font = new Font("Berlin Sans FB", 30, FontStyle.Regular);
                over.TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(over);
            }
        }
        public void freeMine(int xdx, int ydx)
        {
            // ������ ����� ���
            if (xdx < 0 || xdx >= cell_cnt || ydx < 0 || ydx >= cell_cnt)
                return;

            // ���� ���� �����̰ų� �̹� �湮�� ���
            if (button[ydx, xdx].isMine || button[ydx, xdx].BackColor == Color.Gray)
                return;

            // ���� ����� ���� ����
            button[ydx, xdx].BackColor = Color.Gray;

            // �ֺ� ��Ͽ� ���� ��� ȣ��
            if (xdx > 0)
            {
                if (button[ydx, xdx - 1].cnt == 0) freeMine(xdx - 1, ydx);
                else chooseButton(button[ydx, xdx - 1]);
            }
            if (xdx < cell_cnt - 1)
            {
                if (button[ydx, xdx + 1].cnt == 0) freeMine(xdx + 1, ydx);
                else chooseButton(button[ydx, xdx + 1]);
            }
            if (ydx > 0)
            {
                if (button[ydx - 1, xdx].cnt == 0) freeMine(xdx, ydx - 1);
                else chooseButton(button[ydx - 1, xdx]);
            }
            if (ydx < cell_cnt - 1)
            {
                if (button[ydx + 1, xdx].cnt == 0) freeMine(xdx, ydx + 1);
                else chooseButton(button[ydx + 1, xdx]);
            }
            if (xdx > 0 && ydx > 0)
            {
                if (button[ydx - 1, xdx - 1].cnt == 0) freeMine(xdx - 1, ydx - 1);
                else chooseButton(button[ydx - 1, xdx - 1]);
            }
            if (xdx < cell_cnt - 1 && ydx > 0)
            {
                if (button[ydx - 1, xdx + 1].cnt == 0) freeMine(xdx + 1, ydx - 1);
                else chooseButton(button[ydx - 1, xdx + 1]);
            }
            if (xdx > 0 && ydx < cell_cnt - 1)
            {
                if (button[ydx + 1, xdx - 1].cnt == 0) freeMine(xdx - 1, ydx + 1);
                else chooseButton(button[ydx + 1, xdx - 1]);
            }
            if (xdx < cell_cnt - 1 && ydx < cell_cnt - 1)
            {
                if (button[ydx + 1, xdx + 1].cnt == 0) freeMine(xdx + 1, ydx + 1);
                else chooseButton(button[ydx + 1, xdx + 1]);
            }
        }

        public void chooseButton(MineButton btn)   // ��� ���߸���
        {
            btn.BackColor = Color.Gray;
            btn.Text = (btn.cnt).ToString();
        }

        private int CountMS = 0;
        private int CountS = 0;
        private int CountM = 0;
        private bool Toggle = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ++CountMS;
            if (CountMS == 60)
            {
                CountMS = 0;
                ++CountS;
                if (CountS == 60)
                {
                    CountS = 0;
                    ++CountM;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timerM.Text = CountM.ToString("00") + " : " + CountS.ToString("00");
        }

        private void SizeChoose_SelectedIndexChanged(object sender, EventArgs e)   // �޺� �ڽ�
        {
            if (SizeChoose.SelectedIndex == 0)
            {
                cell_cnt = 9;
                mine_cnt = 10;
                gap = 1;
            }
            else
            {
                cell_cnt = 16;
                mine_cnt = 20;
                gap = 5;
            }
        }

        private void ResetWindow()   // ���� ���� �� ȭ�� ����
        {
            for (int i = 0; i < cell_cnt; i++)
            {
                for (int j = 0; j < cell_cnt; j++)
                {
                    button[i, j].Dispose();
                }
            }
            correct = 0; f_cnt = 0; CountM = 0; CountS = 0; CountMS = 0;
            timer1.Stop(); timer2.Stop(); Toggle = false;
            start.Text = "Start";
            start.Visible = false;
            NewGame.Visible = true;
            SizeChoose.Visible = true;
        }
    }
}