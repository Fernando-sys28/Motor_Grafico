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
        Figures cubo;
        Scene scena;
        double[,] RotationX,RotationY,RotationZ;
        Vertex[] vertices = new Vertex[8];
        double angle = 0;
        double radianes;
        bool RX=false;
        bool RY=false;
        bool RZ=false;
        
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphic = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            scena = new Scene(cubo);

            vertices[0] = new Vertex(-50, 50, -50);
            vertices[1] = new Vertex(50, 50, -50);
            vertices[2] = new Vertex(50, -50, -50);
            vertices[3] = new Vertex(-50, -50, -50);
            vertices[4] = new Vertex(-50, -50, 50);
            vertices[5] = new Vertex(50, -50, 50);
            vertices[6] = new Vertex(50, 50, 50);
            vertices[7] = new Vertex(-50, 50, 50);

            cubo = new Figures(vertices);

            graphic.Clear(Color.Transparent);
        }

        private void timer1_Tick(object sender, EventArgs j)
        {

            radianes = convertirRadiantes(angle);

            if (RX== true)
            {
              
                RotationX = Matrix.RotationX(radianes);

                for (int i = 0; i < cubo.Vertices.Length; i++)
                {
                    Vertex vertexX = cubo.Vertices[i];

                    vertexX = Matrix.multiMatrix(vertexX, RotationX);
                    cubo.Vertices[i] = vertexX;                 
                }
              
            }
            
            if (RY == true)
            {
                
                RotationY = Matrix.RotationY(radianes);

                for (int i = 0; i < cubo.Vertices.Length; i++)
                {
                    Vertex vertexY = cubo.Vertices[i];

                    vertexY = Matrix.multiMatrix(vertexY, RotationY);
                    cubo.Vertices[i] = vertexY;

                }             
            }

            if (RZ == true)
            {             
                RotationZ = Matrix.RotationZ(radianes);

                for (int h = 0; h < cubo.Vertices.Length; h++)
                {
                    Vertex vertexZ = cubo.Vertices[h];

                    vertexZ = Matrix.multiMatrix(vertexZ, RotationZ);
                    cubo.Vertices[h] = vertexZ;
                }
            }
            
            graphic.Clear(Color.Transparent);
            Draw(cubo.Vertices[0], cubo.Vertices[1]);
            Draw(cubo.Vertices[1], cubo.Vertices[2]);
            Draw(cubo.Vertices[2], cubo.Vertices[3]);
            Draw(cubo.Vertices[3], cubo.Vertices[0]);
            Draw(cubo.Vertices[4], cubo.Vertices[5]);
            Draw(cubo.Vertices[5], cubo.Vertices[6]);
            Draw(cubo.Vertices[6], cubo.Vertices[7]);
            Draw(cubo.Vertices[7], cubo.Vertices[4]);
            Draw(cubo.Vertices[7], cubo.Vertices[0]);
            Draw(cubo.Vertices[6], cubo.Vertices[1]);
            Draw(cubo.Vertices[5], cubo.Vertices[2]);
            Draw(cubo.Vertices[4], cubo.Vertices[3]);


            pictureBox1.Invalidate();   
        }
        public void Draw(Vertex uno, Vertex dos)
        {
            
            graphic.DrawLine(Pens.Gray, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            graphic.DrawLine(Pens.Gray, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            PointF a = uno.ConvertToPointF(uno.X * 500 / (500 - uno.Z), uno.Y * 500 / (500 - uno.Z));
            PointF b = dos.ConvertToPointF(dos.X * 500 / (500 - dos.Z ), dos.Y * 500 / (500- dos.Z));

             PointF a2, b2;

             int Sx = (pictureBox1.Width / 2);
             int Sy = (pictureBox1.Height / 2);
             a2 = new PointF(Sx + a.X, Sy - a.Y);
             b2 = new PointF(Sx + b.X, Sy - b.Y);
             graphic.DrawLine(Pens.White, a2, b2);        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RX = true;
            RY = false;
            RZ = false;

            vertices[0] = new Vertex(-50, 50, -50);
            vertices[1] = new Vertex(50, 50, -50);
            vertices[2] = new Vertex(50, -50, -50);
            vertices[3] = new Vertex(-50, -50, -50);
            vertices[4] = new Vertex(-50, -50, 50);
            vertices[5] = new Vertex(50, -50, 50);
            vertices[6] = new Vertex(50, 50, 50);
            vertices[7] = new Vertex(-50, 50, 50);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RX = false;
            RY = true;
            RZ = false;
            
            vertices[0] = new Vertex(-50, 50, -50);
            vertices[1] = new Vertex(50, 50, -50);
            vertices[2] = new Vertex(50, -50, -50);
            vertices[3] = new Vertex(-50, -50, -50);
            vertices[4] = new Vertex(-50, -50, 50);
            vertices[5] = new Vertex(50, -50, 50);
            vertices[6] = new Vertex(50, 50, 50);
            vertices[7] = new Vertex(-50, 50, 50);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RX = false;
            RY = false;
            RZ = true;
            
            vertices[0] = new Vertex(-50, 50, -50);
            vertices[1] = new Vertex(50, 50, -50);
            vertices[2] = new Vertex(50, -50, -50);
            vertices[3] = new Vertex(-50, -50, -50);
            vertices[4] = new Vertex(-50, -50, 50);
            vertices[5] = new Vertex(50, -50, 50);
            vertices[6] = new Vertex(50, 50, 50);
            vertices[7] = new Vertex(-50, 50, 50);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RX = true;
            RY = true;
            RZ = true;
           
            vertices[0] = new Vertex(-50, 50, -50);
            vertices[1] = new Vertex(50, 50, -50);
            vertices[2] = new Vertex(50, -50, -50);
            vertices[3] = new Vertex(-50, -50, -50);
            vertices[4] = new Vertex(-50, -50, 50);
            vertices[5] = new Vertex(50, -50, 50);
            vertices[6] = new Vertex(50, 50, 50);
            vertices[7] = new Vertex(-50, 50, 50);
        }
        private double convertirRadiantes(double angulo)
        {
            if (angulo == 0)
            {
                angulo += 1f / 57.2958f;
            }
            return angulo;
        }

    }
}
