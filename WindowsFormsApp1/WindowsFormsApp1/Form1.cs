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
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            List<Rectangle> listRect = new List<Rectangle>();
            Rectangle rect = new Rectangle(50, 50, 50, 50);

            int myLocation = 70;
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



            Point[] v = { new Point(), };
            graphics.FillPolygon(, v);

        }
    }
}
