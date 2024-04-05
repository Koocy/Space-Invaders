using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Button bullet = new Button();
        static Button bullet2 = new Button();
        static Button button;

        static int numberOfEnemies = 6, numberOfKills = 0, level = 0, score = 0, counter = 0, speed = 5;
        static bool left_IsPressed = false, right_IsPressed = false, BulletisRemoved = true, BulletisRemoved2 = true;



        public void Form1_Load(object sender, EventArgs e)
        {
            button = new Button();
            button.Text = "restart";
            button.Size = new Size(75, 50);
            button.Left = this.ClientSize.Width / 2 - button.Width / 2;
            button.Top = this.ClientSize.Height / 2 - button.Height / 2;

            button.Click += gameover;

            moveLilGuy.Start();
            moveEnemies.Start();
            moveBullet2.Start();

            bullet.Size = new Size(10, 10);
            bullet.BackColor = Color.Black;

            bullet2.FlatStyle = FlatStyle.Flat;
            bullet2.BackColor = Color.Red;
            bullet2.Size = new Size(10, 10);

            createEnemies();
        }

        public void createEnemies()
        {
            int left = -50;
            int top = 20;

            int x = 1;
            for (int i = 1; i <= numberOfEnemies; i++)
            {
                Label enemy = new Label();
                enemy.Size = new Size(40, 15);
                enemy.BackColor = Color.Black;

                if (i == x * (numberOfEnemies / (level + 1)) + 1)
                {
                    top = top + 40;
                    left = 30;
                    x++;
                }

                else
                {
                    left = left + 80;
                }

                enemy.Top = top;
                enemy.Left = left;

                Controls.Add(enemy);
                enemy.BringToFront();
            }
        }

        public static void gameover(object o, EventArgs e)
        {
            Process p = Process.GetCurrentProcess();

            Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\WindowsFormsApplication1.exe");
            p.Kill();
        }

        private void lilguy_previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;

            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:

                    if (lilguy.Left > 20)
                    {
                        lilguy.Left = lilguy.Left - 10;

                        left_IsPressed = true;
                        right_IsPressed = false;
                    }

                    break;

                case Keys.D:
                case Keys.Right:

                    if (lilguy.Right < 480)
                    {
                        lilguy.Left = lilguy.Left + 10;

                        right_IsPressed = true;
                        left_IsPressed = false;
                    }

                    break;

 
            }
        }

        public void lilguy_Click(object sender, EventArgs e)
        {

            if (BulletisRemoved)
            {
                bullet.Top = lilguy.Top - lilguy.Size.Height;
                bullet.Left = ((lilguy.Left + lilguy.Right) / 2) - 5;

                Controls.Add(bullet);
                bullet.BringToFront();

                moveBullet.Start();
                BulletisRemoved = false;
            }

        }

        private void moveLilGuy_Tick(object sender, EventArgs e)
        {
            if (left_IsPressed)
            {
                lilguy.Left = lilguy.Left - 5;
            }

            if (right_IsPressed)
            {
                lilguy.Left = lilguy.Left + 5;
            }

            if (lilguy.Left < 20)
            {
                right_IsPressed = true;
                left_IsPressed = false;
            }

            if (lilguy.Right > 480)
            {
                left_IsPressed = true;
                right_IsPressed = false;
            }
        }

        private void moveBullet_Tick(object sender, EventArgs e)
        {
            bullet.Top = bullet.Top - 10;

            if (bullet.Top <= 0)
            {
                Controls.Remove(bullet);
                BulletisRemoved = true;
                moveBullet.Stop();
            }

            foreach (Label labels in Controls.OfType<Label>())
            {
                if (bullet.Bounds.IntersectsWith(labels.Bounds))
                {
                    moveBullet.Stop();

                    Controls.Remove(bullet);
                    Controls.Remove(labels);
                    BulletisRemoved = true;

                    score = score + 100;
                    numberOfKills++;
                    Text = "score: " + score;
                }

            }

            if (numberOfKills == numberOfEnemies)
            {
                numberOfEnemies = numberOfEnemies + 6;
                numberOfKills = 0;
                level++;
                moveEnemies.Interval = moveEnemies.Interval - 50;
                speed = speed + 1;

                createEnemies();
            }

        }

        private void moveEnemies_Tick(object sender, EventArgs e)
        {

            if (counter % 2 != 0)
            {
                foreach (Label labels in Controls.OfType<Label>())
                {
                    labels.Left = labels.Left + 10;
                }

                counter = 0;
            }

            else if (counter % 2 == 0)
            {
                foreach (Label labels in Controls.OfType<Label>())
                {
                    labels.Left = labels.Left - 10;
                }

                counter++;
            }

            foreach (Label labels in Controls.OfType<Label>())
            {
                labels.Top = labels.Top + 10;

                if (labels.Bounds.IntersectsWith(GameOverLine.Bounds))
                {
                    moveLilGuy.Stop();
                    moveBullet.Stop();
                    moveEnemies.Stop();
                    moveBullet2.Stop();

                    lilguy.Enabled = false;

                    this.Controls.Add(button);
                    button.BringToFront();

                    break;
                }

            }

        }

        private void moveBullet2_Tick(object sender, EventArgs e)
        {
            if (BulletisRemoved2)
            {
                Random random = new Random();
                int random_int = random.Next(0, this.Size.Width);

                bullet2.Top = 20;
                bullet2.Left = random_int;

                Controls.Add(bullet2);
                bullet2.BringToFront();

                BulletisRemoved2 = false;
            }

            if (bullet2.Bounds.IntersectsWith(lilguy.Bounds))
            {
                moveLilGuy.Stop();
                moveBullet.Stop();
                moveEnemies.Stop();
                moveBullet2.Stop();

                lilguy.Enabled = false;

                this.Controls.Add(button);
                button.BringToFront();
            }

            if (bullet2.Bottom >= 500)
            {
                Controls.Remove(bullet2);
                BulletisRemoved2 = true;
            }

            bullet2.Top = bullet2.Top + speed;
        }

    }
}
