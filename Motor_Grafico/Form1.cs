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
        //Graphics graphic;
        Scene scena;
        Canvas canvas;
        Mesh cube;
        public bool RX = false;
        public bool RY = false;
        public bool RZ = false;
        public PointF center;
        float angle = 0;


        bool mouseDown = false;
        bool mouseDownY = false;
        Point ptX, ptY, mouse;
        float deltaX = 0;
        float deltaY = 1;
        float valor;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Init()
        {

            canvas = new Canvas(pictureBox1.Size);
            pictureBox1.Image = canvas.bitmap;
            Vertex[] vertices = new Vertex[] {
                                            new Vertex(1, 1, 1),
                                            new Vertex(-1, 1, 1),
                                            new Vertex(-1, -1, 1),
                                            new Vertex(1, -1, 1),
                                            new Vertex(1, 1, -1),
                                            new Vertex(-1, 1, -1),
                                            new Vertex(-1, -1, -1),
                                            new Vertex(1, -1, -1)
                                        };


            triangulo[] triangles = new triangulo[] {
                                            new triangulo(0, 1, 2, Color.Red),
                                            new triangulo(0, 2, 3, Color.Red),
                                            new triangulo(4, 0, 3, Color.Green),
                                            new triangulo(4, 3, 7, Color.Green),
                                            new triangulo(5, 4, 7, Color.Blue),//-----------------------
                                            new triangulo(5, 7, 6, Color.Blue),
                                            new triangulo(1, 5, 6, Color.Yellow),
                                            new triangulo(1, 6, 2, Color.Yellow),
                                            new triangulo(4, 5, 1, Color.Purple),
                                            new triangulo(4, 1, 0, Color.Purple),
                                            new triangulo(2, 6, 7, Color.Cyan),
                                            new triangulo(2, 7, 3, Color.Cyan)
                                           };
            cube = new Mesh(vertices, triangles);
            scena = new Scene(cube, new Transform(1f, new Vertex(2, 1, 8)));
            canvas.RenderModel(scena);


        }

        private void timer1_Tick(object sender, EventArgs j)
        {
            
            Draw();

            if (scena != null)
            {
                //scena.transform.scale = deltaY;
                scena.transform.traslation.X = deltaX;
                
            }
            if (RX == true)
            {
                for (int i = 0; i < scena.mesh.vertices.Length; i++)
                {
                    Vertex v = scena.mesh.vertices[i];
                    Matrix r = Matrix.RotX(angle++);
                    v = r * v;
                    scena.transform.rotation = v;
                }
            }
            if (RY == true)
            {
                for (int i = 0; i < scena.mesh.vertices.Length; i++)
                {
                    Vertex v = scena.mesh.vertices[i];
                    Matrix r = Matrix.RotY(angle++);
                    v = r * v;
                    scena.transform.rotation = v;
                }
            }
            if (RZ == true)
            {
                for (int i = 0; i < scena.mesh.vertices.Length; i++)
                {
                    Vertex v = scena.mesh.vertices[i];
                    Matrix r = Matrix.RotZ(angle++);
                    v = r * v;
                    scena.transform.rotation = v;
                }
            }
            pictureBox1.Invalidate();
        }


        public void Draw()
        {
            canvas.FastClear();
            canvas.RenderModel(scena);
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
          
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //scena.mesh = new Cylinder(1f, 2.5f, 20);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //scena.mesh = new Sphere(2f,30);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //scena.mesh = new Cone(1f,2f,15);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //scena.mesh = new Cylinder(1f, 2.5f, 5);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void trackBar2_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void trackBar2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                deltaY += (float)(ptY.Y - e.Location.Y) / 300;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            ptX = e.Location;
            mouseDown = true;
        }

        private void trackBar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                deltaX += (float)(e.Location.X - ptX.X) / 2;
                ptX.X = e.Location.X;
            }
        }
    }
}
