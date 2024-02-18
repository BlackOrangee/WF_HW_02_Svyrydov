using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_CW_11._02._24
{
    public partial class Form1 : Form
    {
        int min = 15;
        int max = 30;
        double speed = 1;
        int interval = 900;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = interval;
            timer1.Enabled = true;
            timer1.Start();


            //this.BackgroundImage = Image.FromFile("C:\\Users\\CC\\Desktop\\fon.jpg");

        
            //Random random = new Random();

            //Ball ball = new Ball(this.Size, random.Next(500, 1000));

            //List<Ball> balls = new List<Ball>();

            //for (int i = 0; i < 50; i++)
            //{
              
            //    balls.Add(new Ball(this.Size, random.Next(10, 50)));
            //}

            //balls.ForEach(ball => { 
            //    this.Controls.Add(ball.pictureBox);
            //    ball.ballTimer.Start();
            //});
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            this.Controls.Remove(picture);
            label1.Text = (Int32.Parse(label1.Text) + 1).ToString();
            //min -= 1;
            //max -= 1;
            speed += 0.1;
            interval -= 20;

        }

        public void PictureBox_Location(object sender, EventArgs e)
        {
     
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            Ball ball = new Ball(this.Size, random.Next(15, 30), (int)speed);
            this.Controls.Add(ball.pictureBox);
            ball.ballTimer.Start();

            ball.pictureBox.Click += PictureBox_Click;
  
              

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }

    public class Ball
    {
        public PictureBox pictureBox { get; }

        private RandomPoint randomPoint;
        public Timer ballTimer { get; set; }

        public int speed {  get; set; }

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - speed);



            //if (pictureBox.Location.Y > 62)
            //{
            //    PictureBox picture = (PictureBox)sender;
            //    this.Controls.Remove(picture);
            //}
        }


        public Ball(Size size, int interval, int speed)
        {
            ballTimer = BallTimer.GetTimer(interval);
            ballTimer.Tick += timer_Tick;
            randomPoint = new RandomPoint(size);
            pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("C:\\Users\\CC\\Desktop\\ball.png");
            pictureBox.Size = new Size(48, 62);
            pictureBox.Location = randomPoint.getPoint();
            this.speed = speed;
        }
    }
    public class RandomPoint
    {
        private Random rnd = new Random();
        private Size windowSize;
        public RandomPoint(Size size)
        {
            size.Width = size.Width - 48;
            windowSize = size;
        }
        public Point getPoint()
        {
            return new Point(rnd.Next(0, windowSize.Width), windowSize.Height);
        }
    }
    public class BallTimer
    {
        public static Timer GetTimer(int interval)
        {
            Timer timer = new Timer();
            timer.Interval = interval; timer.Enabled = true;
            return timer;
        }
    }
}
