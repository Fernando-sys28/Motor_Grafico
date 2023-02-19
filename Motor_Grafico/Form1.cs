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
        Graphics g;
        Figures cubo;
        Scene scena;
        double[] Rotation;
        Vertex[] vertices = new Vertex[4];
        double angle1=0, angle2 = 0, angle3 = 0;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            scena = new Scene();

            vertices[0] = new Vertex(-50, 50, 0);
            vertices[1] = new Vertex(50, 50, 0);
            vertices[2] = new Vertex(50, -50, 0);
            vertices[3] = new Vertex(-50, -50, 0);
          
            cubo = new Figures(vertices);

            cubo.ImprimirVertices();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Actualizar ángulos de rotación
            angle1 += 0.01f / 57.2958f;
            angle2 += 0.02f / 57.2958f;
            angle3 += 0.03f / 57.2958f;

            // Crear matriz de rotación total
            
            Rotation = Matrix.multiMatrix(Rotation, Matrix.RotationY(angle2));

            Rotation = Matrix.multiMatrix(Rotation,Matrix.RotationX(angle1));
            
            Rotation = Matrix.multiMatrix(Rotation, Matrix.RotationZ(angle3));

            // Aplicar la matriz de transformación a la figura
            //cubo.Transform(rotation);

            // Redibujar
            Draw();
            pictureBox1.Invalidate();
        

        /*angle1 += 0.01f;
        angle2 += 0.02f;
        angle3 += 0.03f;


        RotationY = Matrix.RotationX(angle2);
        RotationX = Matrix.RotationY(angle1);
        RotationZ = Matrix.RotationZ(angle3);

        Draw();

        for (int i = 0; i < cubo.Vertices.Length; i++)
        {
            Vertex vertexX = cubo.Vertices[i];
            Vertex vertexY = cubo.Vertices[i];
            Vertex vertexZ = cubo.Vertices[i];

            //vertexZ = Matrix.multiMatrix(vertexZ, RotationZ);
            vertexY = Matrix.multiMatrix(vertexY, RotationY);
            //vertexX = Matrix.multiMatrix(vertexX, RotationX);


            //cubo.Vertices[i].Z = vertexZ.Z;
            cubo.Vertices[i] = vertexY;
            //cubo.Vertices[i]= vertexX;

        }




        pictureBox1.Invalidate();*/

    }
        public void Draw()
        {
            g.Clear(Color.Transparent);
            for (int i = 0; i < cubo.Vertices.Length; i++)
            {
                g.DrawLine(Pens.Gray, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
                g.DrawLine(Pens.Gray, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

                
                Vertex vertex1 = cubo.Vertices[i];
                Vertex vertex2 = i == cubo.Vertices.Length - 1 ? cubo.Vertices[0] : cubo.Vertices[i + 1];

                PointF a = vertex1.ConvertToPointF(vertex1.X, vertex1.Y, vertex1.Z);
                PointF b = vertex2.ConvertToPointF(vertex2.X, vertex2.Y, vertex2.Z);

                PointF a2, b2;
                int Sx = (pictureBox1.Width / 2);
                int Sy = (pictureBox1.Height / 2);
                a2 = new PointF(Sx + a.X, Sy - a.Y);
                b2 = new PointF(Sx + b.X, Sy - b.Y);

                g.DrawLine(Pens.White, a2, b2);

            }
        }

    }
}
