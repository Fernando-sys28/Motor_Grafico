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
            
            }

            private void timer1_Tick(object sender, EventArgs j)
            {

                radianes = convertirRadiantes(angle);
                if (RX == true)
                {
                    RotationX = Matrix.RotationX(radianes);

                    // Aplicar la matriz de rotación en cada vértice del objeto
                    for (int i = 0; i < scena.mesh.triangulos.Count; i++)
                    {
                        triangulo triangle = scena.mesh.triangulos[i];

                        Vertex vertexA = triangle.a;
                        Vertex vertexB = triangle.b;
                        Vertex vertexC = triangle.c;

                        vertexA = Matrix.multiMatrix(vertexA, RotationX);
                        vertexB = Matrix.multiMatrix(vertexB, RotationX);
                        vertexC = Matrix.multiMatrix(vertexC, RotationX);

                        triangle.a = vertexA;
                        triangle.b = vertexB;
                        triangle.c = vertexC;
                    }
                }
                if (RY == true)
                {
                    RotationY = Matrix.RotationY(radianes);

                    // Aplicar la matriz de rotación en cada vértice del objeto
                    for (int i = 0; i < scena.mesh.triangulos.Count; i++)
                    {
                        triangulo triangle = scena.mesh.triangulos[i];

                        Vertex vertexA = triangle.a;
                        Vertex vertexB = triangle.b;
                        Vertex vertexC = triangle.c;

                        vertexA = Matrix.multiMatrix(vertexA, RotationY);
                        vertexB = Matrix.multiMatrix(vertexB, RotationY);
                        vertexC = Matrix.multiMatrix(vertexC, RotationY);

                        triangle.a = vertexA;
                        triangle.b = vertexB;
                        triangle.c = vertexC;
                    }
                }
                if (RZ == true)
                {
                    RotationZ = Matrix.RotationZ(radianes);

                    // Aplicar la matriz de rotación en cada vértice del objeto
                    for (int i = 0; i < scena.mesh.triangulos.Count; i++)
                    {
                        triangulo triangle = scena.mesh.triangulos[i];

                        Vertex vertexA = triangle.a;
                        Vertex vertexB = triangle.b;
                        Vertex vertexC = triangle.c;

                        vertexA = Matrix.multiMatrix(vertexA, RotationZ);
                        vertexB = Matrix.multiMatrix(vertexB, RotationZ);
                        vertexC = Matrix.multiMatrix(vertexC, RotationZ);

                        triangle.a = vertexA;
                        triangle.b = vertexB;
                        triangle.c = vertexC;
                    }
                }


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
                graphic.Clear(Color.Black);
                graphic.DrawLine(Pens.Gray, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
                graphic.DrawLine(Pens.Gray, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

                foreach (var triangle in scena.mesh.triangulos)
                {
                    Vertex normal = CalculateNormal(triangle.a, triangle.b, triangle.c);
                    Vertex camara = new Vertex(0, 0, -1);
                    float normalize = (float)Math.Sqrt(DotProduct(normal,camara));

                    normal.X /= normalize;
                    normal.Y /= normalize;
                    normal.Z /= normalize;


                    if (normal.Z < 0)
                    {
                        Vertex emp = new Vertex(triangle.a.X, triangle.a.Y, triangle.a.Z);
                        emp.X = triangle.a.X *50 / 1- triangle.a.Z;
                        emp.Y = triangle.a.Y * 50 / 1- triangle.a.Z;
                        Vertex emp2 = new Vertex(triangle.b.X, triangle.b.Y, triangle.b.Z);
                        emp2.X= triangle.b.X * 50 / 1- triangle.b.Z;
                        emp2.Y = triangle.b.Y * 50 / 1-triangle.b.Z;
                        Vertex emp3 = new Vertex(triangle.c.X, triangle.c.Y, triangle.c.Z);
                        emp3.X = triangle.c.X * 50 / 1- triangle.c.Z;
                        emp3.Y = triangle.c.Y * 50 /  1- triangle.c.Z;

                        PointF a = triangle.a.ConvertToPointF(emp.X  , emp.Y );
                        PointF b = triangle.b.ConvertToPointF(emp2.X , emp2.Y);
                        PointF c = triangle.c.ConvertToPointF(emp3.X , emp3.Y);

                        // Move to screen center and draw
                        PointF center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
                        graphic.DrawLine(Pens.LightGreen, new PointF(a.X + center.X, -a.Y + center.Y), new PointF(b.X + center.X, -b.Y + center.Y));
                        graphic.DrawLine(Pens.LightGreen, new PointF(b.X + center.X, -b.Y + center.Y), new PointF(c.X + center.X, -c.Y + center.Y));
                        graphic.DrawLine(Pens.LightGreen, new PointF(c.X + center.X, -c.Y + center.Y), new PointF(a.X + center.X, -a.Y + center.Y));
                    }
            
                }
            }

            private Vertex CalculateNormal(Vertex a, Vertex b, Vertex c)
            {
                Vertex edge1 = new Vertex(b.X - a.X, b.Y - a.Y, b.Z - a.Z);         
                Vertex edge2 = new Vertex(c.X - a.X, c.Y - a.Y, c.Z - a.Z);

                float CrossX = edge1.Y * edge2.Z - edge1.Z * edge2.Y;
                float CrossY = edge1.Z * edge2.X - edge1.X * edge2.Z;
                float CrossZ = edge1.X * edge2.Y - edge1.Y * edge2.X;

                Vertex normal= new Vertex(CrossX, CrossY, CrossZ);

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
