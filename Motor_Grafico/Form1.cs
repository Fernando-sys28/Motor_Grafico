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

namespace Motor_Grafico
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Figures figure;
        Scene scena;
        double angle=45;
        Matrix rotationMatrix;
        double[,] matrix;
        Matrix matrix_XYZ;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            scena = new Scene();
            figure = new Figures();

            g.DrawLine(Pens.Gray, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(Pens.Gray, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            figure.AddVertex(-50, 50, 0);
            figure.AddVertex(50, 50, 0);
            figure.AddVertex(50, -50, 0);
            figure.AddVertex(-50, -50, 0);

            //angle = Math.PI / 50;

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* //Scene.Figures.Add(figure);
            Matrix rotationMatrix = Matrix.RotationY(angle);
            figure.Rotate(rotationMatrix);
            rotationMatrix = Matrix.RotationX(angle);
            figure.Rotate(rotationMatrix);
            rotationMatrix = Matrix.RotationZ(angle);
            figure.Rotate(rotationMatrix);

            Draw();

            angle += Math.PI / 50;*/


        }
       /* public void Draw()
        {
            for (int i = 0; i < figure.vertices.Count; i++)
            {
                Vertex vertex1 = figure.vertices[i];
                Vertex vertex2 = i == figure.vertices.Count - 1 ? figure.vertices[0] : figure.vertices[i + 1];


                PointF a = vertex1.ConvertToPointF(vertex1.X, vertex1.Y, vertex1.Z);
                PointF b = vertex2.ConvertToPointF(vertex2.X, vertex2.Y, vertex2.Z);

                PointF a2, b2;
                int Sx = (pictureBox1.Width / 2);
                int Sy = (pictureBox1.Height / 2);
                a2 = new PointF(Sx + a.X, Sy - a.Y);
                b2 = new PointF(Sx + b.X, Sy - b.Y);

                g.DrawLine(Pens.White, a2, b2);
            }
        }*/



    }
}
