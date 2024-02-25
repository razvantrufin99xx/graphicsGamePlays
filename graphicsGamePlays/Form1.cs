using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphicsGamePlays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics g;
        public Pen p = new Pen(Color.Black, 3);
        public Brush b = new SolidBrush(Color.Black);
        public Font f;
        public bool isMouseDown = false;
        public Color mainColor = Color.White;
        private void Form1_Load(object sender, EventArgs e)
        {
         WindowState = FormWindowState.Maximized;
        }

        public bool drawAPixel(ref Graphics pg, float x, float y , Color c, float w)
        {
            pg.DrawEllipse(new Pen(c,w), x, y, w,w);

            return true;
        }
        public bool drawPixels()
        {
            for (int i = 0; i < this.Height; i+=10)
            {
                for (int j = 0; j < this.Width; j+=10)
                {
                    drawAPixel(ref g, (float)j, (float)i, this.mainColor, 10);
                }
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Visible = false;
            drawPixels();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            f = this.Font;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            drawAPixel(ref g, (float)e.X, (float)e.Y+5, Color.FromArgb(1,mainColor), 1);
            if (isMouseDown == true)
            {
                drawAPixel(ref g, (float)e.X - 5, (float)e.Y + 5, this.mainColor, 10);
                drawAPixel(ref g, (float)e.X + 5, (float)e.Y + 5, this.mainColor, 10);
                drawAPixel(ref g, (float)e.X, (float)e.Y - 5, this.mainColor, 10);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isMouseDown = true;
            drawAPixel(ref g, (float)e.X, (float)e.Y, this.mainColor, 20);
            drawAPixel(ref g, (float)e.X-5, (float)e.Y-5, this.mainColor, 10);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isMouseDown = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            this.mainColor = colorDialog.Color;
        }
    }
}
