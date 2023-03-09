using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    namespace Motor_Grafico
    {
    public partial class Form1 : Form
    {
        Bitmap bmp;
        //Graphics graphic;
        Scene scena;
        Canvas canvas;
        bool RX = false;
        bool RY = false;
        bool RZ = false;
        public PointF center;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            scena = new Scene();
            center = new PointF(pictureBox1.Width / 2, pictureBox1.Height/2);
        }

        private void timer1_Tick(object sender, EventArgs j)
        {
            Draw();
            if (RX == true)
            {
                for (int i = 0; i < scena.mesh.triangulos.Count; i++)
                {
                    scena.mesh.RotateX(1f, scena.mesh.triangulos[i]);                
                }
            }
            if (RY == true)
            {

                for (int i = 0; i < scena.mesh.triangulos.Count; i++)
                {
                    scena.mesh.RotateY(1f, scena.mesh.triangulos[i]);                 
                }
            }
            if (RZ == true)
            {
                for (int i = 0; i < scena.mesh.triangulos.Count; i++)
                {
                    scena.mesh.RotateZ(1f, scena.mesh.triangulos[i]);
                }
            }
            pictureBox1.Invalidate();
        }


        public void Draw()
        {
            canvas.FastClear();
            canvas.DrawLine(new PointF(0, pictureBox1.Height / 2-1), new PointF(pictureBox1.Width-1, pictureBox1.Height / 2-1), Color.Gray);
            canvas.DrawLine(new PointF(pictureBox1.Width / 2-1, 0), new PointF(pictureBox1.Width / 2-1, pictureBox1.Height-1), Color.Gray);

            foreach (triangulo triangle in scena.mesh.triangulos)
            {
                Vertex N = triangle.NormalTriangle(triangle);
                float h = triangle.shadow(triangle);

                if (N.Z < 0)
                {
                    PointF a = triangle.a.ConvertToPointF(triangle.a.X * 100 / (3 + triangle.a.Z), triangle.a.Y * 100 / (3 + triangle.a.Z));
                    PointF b = triangle.b.ConvertToPointF(triangle.b.X * 100 / (3 + triangle.b.Z), triangle.b.Y * 100 / (3 + triangle.b.Z));
                    PointF c = triangle.c.ConvertToPointF(triangle.c.X * 100 / (3 + triangle.c.Z), triangle.c.Y * 100 / (3 + triangle.c.Z));

                    int Sx = (pictureBox1.Width / 2);
                    int Sy = (pictureBox1.Height / 2);
                    PointF a1, b1, c1;
                    a1= new PointF(Sx + a.X, Sy - a.Y);
                    b1 = new PointF(Sx + b.X, Sy - b.Y);
                    c1 = new PointF(Sx + c.X, Sy - c.Y);

                    canvas.FillTriangle(a1, b1, c1, Color.LightSeaGreen);
                    canvas.DrawLine(a1, b1, Color.Black);
                    canvas.DrawLine(b1, c1, Color.Black);
                    canvas.DrawLine(c1, a1, Color.Black);
                    //canvas.DrawShadedTriangle(a1, b1, c1, Color.LightSeaGreen);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RX = true;
            RY = false;
            RZ = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RX = false;
            RY = true;
            RZ = false;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            RX = false;
            RY = false;
            RZ = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RX = true;
            RY = true;
            RZ = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            scena.mesh = new Cube();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            scena.mesh = new Cylinder(1f, 2.5f, 20);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            scena.mesh = new Sphere(2f,20);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            scena.mesh = new Cone(1f,2f,15);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            scena.mesh = new Cylinder(1f, 2.5f, 5);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Canvas(pictureBox1.Size);
            pictureBox1.Image = canvas.bitmap;
        }
    }
}
