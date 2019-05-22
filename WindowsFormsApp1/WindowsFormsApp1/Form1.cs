using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public float degree = 0;
        Timer timer = new Timer();
        Graphics graphics = null;
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            graphics = this.CreateGraphics();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (degree == 0)
                degree = -0.1f;

            else degree = 0;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            List<Rectangle> listRect = new List<Rectangle>();
            Rectangle rect = new Rectangle(50, 50, 50, 50);

            int myLocation = 50;
            int step1 = myLocation, step2 = myLocation;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    listRect.Add(new Rectangle(step1, step2, myLocation, myLocation));

                    step1 += myLocation;
                }
                step2 += myLocation;
                step1 = myLocation;
            }



            graphics.FillRectangle(Brushes.Pink, listRect[0]);
            graphics.FillRectangle(new HatchBrush(HatchStyle.LightVertical, Color.White, Color.Blue), listRect[1]);
            graphics.FillRectangle(Brushes.Coral, listRect[2]);
            graphics.FillRectangle(new LinearGradientBrush(listRect[3], Color.White, Color.DarkKhaki, LinearGradientMode.Vertical), listRect[3]);
            graphics.FillRectangle(Brushes.BlueViolet, listRect[4]);
            graphics.FillRectangle(Brushes.Orange, listRect[5]);
            graphics.FillRectangle(new LinearGradientBrush(listRect[6], Color.Violet, Color.Yellow, LinearGradientMode.BackwardDiagonal), listRect[6]);
            graphics.FillRectangle(new TextureBrush(Image.FromFile("1.jpg")), listRect[7]);
            graphics.FillRectangle(new TextureBrush(Image.FromFile("2.jpg")), listRect[8]);

            Matrix matrix = new Matrix();

            matrix.Shear(degree,degree);
            graphics.Transform = matrix;
            Point[] points = { new Point(20, 25), new Point(50, 50), new Point(50, 200), new Point(50, 200), new Point(20, 175) };
            graphics.FillPolygon(Brushes.Black, points);

            Point[] points2 = { new Point(20, 25), new Point(175, 25), new Point(200, 50), new Point(200, 50), new Point(50, 50) };
            graphics.FillPolygon(Brushes.Yellow, points2);


        }
    }
}
