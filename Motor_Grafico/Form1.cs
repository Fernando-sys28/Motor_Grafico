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
        Graphics graphic;
        Scene scena;
        float[,] RotationX,RotationY,RotationZ;
        float angle = 0;
        float radianes;
        bool RX=false;
        bool RY=false;
        bool RZ=false;
        
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphic = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            scena = new Scene();
            
            graphic.Clear(Color.Transparent);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs j)
        {

            radianes = convertirRadiantes(angle);
            
            graphic.Clear(Color.Transparent);

            foreach (triangulo triangle in scena.mesh.triangulos)
            {
                Draw(triangle.a, triangle.b);
                Draw(triangle.b, triangle.c);
                Draw(triangle.c, triangle.a);
            }

            pictureBox1.Invalidate();   
        }
        public void Draw(Vertex uno, Vertex dos)
        {
            
            graphic.DrawLine(Pens.Gray, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            graphic.DrawLine(Pens.Gray, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            foreach (var triangle in scena.mesh.triangulos)
            {
                Vertex normal = CalculateNormal(triangle.a, triangle.b, triangle.c);

                // Check if triangle is facing towards camera
                // Convert vertex positions to 2D screen coordinates
                var a = triangle.a.ConvertToPointF(triangle.a.X * 500 / (500 - triangle.a.Z), triangle.a.Y * 500 / (500 - triangle.a.Z));
                var b = triangle.b.ConvertToPointF(triangle.b.X * 500 / (500 - triangle.b.Z), triangle.b.Y * 500 / (500 - triangle.b.Z));
                var c = triangle.c.ConvertToPointF(triangle.c.X * 500 / (500 - triangle.c.Z), triangle.c.Y * 500 / (500 - triangle.c.Z));

                // Move to screen center and draw
                var center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
                graphic.DrawLine(Pens.White, new PointF(a.X + center.X, -a.Y + center.Y), new PointF(b.X + center.X, -b.Y + center.Y));
                graphic.DrawLine(Pens.White, new PointF(b.X + center.X, -b.Y + center.Y), new PointF(c.X + center.X, -c.Y + center.Y));
                graphic.DrawLine(Pens.White, new PointF(c.X + center.X, -c.Y + center.Y), new PointF(a.X + center.X, -a.Y + center.Y));

            }

            /*PointF a = uno.ConvertToPointF(uno.X * 500 / (500 - uno.Z), uno.Y * 500 / (500 - uno.Z));
            PointF b = dos.ConvertToPointF(dos.X * 500 / (500 - dos.Z ), dos.Y * 500 / (500- dos.Z));

             PointF a2, b2;

             int Sx = (pictureBox1.Width / 2);
             int Sy = (pictureBox1.Height / 2);
             a2 = new PointF(Sx + a.X, Sy - a.Y);
             b2 = new PointF(Sx + b.X, Sy - b.Y);
             graphic.DrawLine(Pens.White, a2, b2);*/
        }

        private Vertex CalculateNormal(Vertex a, Vertex b, Vertex c)
        {
            Vertex edge1 = new Vertex(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
            Vertex edge2 = new Vertex(c.X - a.X, c.Y - a.Y, c.Z - a.Z);

            float CrossX = edge1.Y * edge2.Z - edge1.Z * edge2.Y;
            float CrossY = edge1.Z * edge2.X - edge1.X * edge2.Z;
            float CrossZ = edge1.X * edge2.Y - edge1.Y * edge2.X;
            Vertex normal= new Vertex(CrossX, CrossY , CrossZ );

            return normal;
        }

        // Calculates the dot product of two vectors
        private float DotProduct(Vertex a, Vertex b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
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
        private float convertirRadiantes(float angulo)
        {
            if (angulo == 0)
            {
                angulo += 1f / 57.2958f;
            }
            
            return angulo;
        }



    }
}
