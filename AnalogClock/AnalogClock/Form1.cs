using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        int WIDTH = 400, HEIGHT = 400, secondsHAND = 160, minutesHAND = 110, hoursHAND = 80;

        int x, y;

        Bitmap bitmap;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(WIDTH + 1, HEIGHT + 1);

            x = WIDTH / 2;
            y = HEIGHT / 2;

            this.BackColor = Color.LightBlue;

            timer.Interval = 1000;  
            timer.Tick += new EventHandler(this.t_Tick);
            timer.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            graphics = Graphics.FromImage(bitmap);

            int seconds = DateTime.Now.Second;
            int minutes = DateTime.Now.Minute;
            int hours = DateTime.Now.Hour;

            int[] coordinates = new int[2];

            graphics.Clear(Color.White);

            graphics.DrawEllipse(new Pen(Color.DarkBlue, 1f), 0, 0, WIDTH, HEIGHT);
            graphics.DrawString("11", new Font("Arial", 15), Brushes.DarkGray, new PointF(95, 30));
            graphics.DrawString("12", new Font("Impact", 20), Brushes.OrangeRed, new PointF(178, 4));
            graphics.DrawString("1", new Font("Arial", 15), Brushes.DarkGray, new PointF(280, 30));
            graphics.DrawString("2", new Font("Arial", 15), Brushes.DarkGray, new PointF(350, 95));
            graphics.DrawString("3", new Font("Impact", 20), Brushes.YellowGreen, new PointF(370, 177));
            graphics.DrawString("4", new Font("Arial", 15), Brushes.DarkGray, new PointF(350, 275));
            graphics.DrawString("5", new Font("Arial", 15), Brushes.DarkGray, new PointF(280, 345));
            graphics.DrawString("6", new Font("Impact", 20), Brushes.MediumPurple, new PointF(180, 360));
            graphics.DrawString("7", new Font("Arial", 15), Brushes.DarkGray, new PointF(95, 345));
            graphics.DrawString("8", new Font("Arial", 15), Brushes.DarkGray, new PointF(28, 275));
            graphics.DrawString("9", new Font("Impact", 20), Brushes.RoyalBlue, new PointF(0, 177));
            graphics.DrawString("10", new Font("Arial", 15), Brushes.DarkGray, new PointF(30, 95));

            coordinates = minutesCoordinates(seconds, secondsHAND);
            graphics.DrawLine(new Pen(Color.DarkBlue, 1f), new Point(x, y), new Point(coordinates[0], coordinates[1]));

            coordinates = minutesCoordinates(minutes, minutesHAND);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(x, y), new Point(coordinates[0], coordinates[1]));

            coordinates = hoursCoordinates(hours % 12, minutes, hoursHAND);
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(x, y), new Point(coordinates[0], coordinates[1]));

            pictureBox1.Image = bitmap;
            this.Text = "Analog Clock -  " + hours + ":" + minutes + ":" + seconds;

            graphics.Dispose();
        }
        private int[] minutesCoordinates(int val, int hlen)
        {
            int[] coordinateS = new int[2];
            val *= 6;   

            if (val >= 0 && val <= 180)
            {
                coordinateS[0] = x + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coordinateS[1] = y - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coordinateS[0] = x - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coordinateS[1] = y - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coordinateS;
        }
        private int[] hoursCoordinates(int hoursVal, int minutesVal, int hlen)
        {
            int[] cords = new int[2];

            int val = (int)((hoursVal * 30) + (minutesVal * 0.5));

            if (val >= 0 && val <= 180)
            {
                cords[0] = x + (int)(hlen * Math.Sin(Math.PI * val / 180));
                cords[1] = y - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                cords[0] = x - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                cords[1] = y - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return cords;
        }
    }
}
