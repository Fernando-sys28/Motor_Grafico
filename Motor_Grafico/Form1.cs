using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
        Scene[] scena;
        Canvas canvas;
        Mesh cube;
        public bool RX = false;
        public bool RY = false;
        public bool RZ = false;

        bool OpenObj = false;

        bool mouseDown = false;
        bool mouseDownY = false;
        Point ptX, ptY;
        float deltaX = 0;
        float deltaY = 1;

        float angle = 0;

        string filePath;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Init()
        {
            canvas = new Canvas(pictureBox1.Size);
            pictureBox1.Image = canvas.bitmap;

            /* if (OpenObj)
             {
                 canvas = new Canvas(pictureBox1.Size);
                 pictureBox1.Image = canvas.bitmap;

                 Vertex[] vertices;
                 triangulo[] faces;

                 using (StreamReader reader = new StreamReader(filePath))
                 {
                     List<Vertex> vertexList = new List<Vertex>();
                     List<triangulo> faceList = new List<triangulo>();

                     while (!reader.EndOfStream)
                     {
                         string line = reader.ReadLine();
                         // Leer la línea y procesar la información para obtener los vértices
                         if (line.StartsWith("v "))
                         {
                             string[] vertexValues = line.Split(' ');
                             float x = float.Parse(vertexValues[1]);
                             float y = float.Parse(vertexValues[2]);
                             float z = float.Parse(vertexValues[3]);
                             Vertex vertex = new Vertex(x, y, z);
                             vertexList.Add(vertex);
                         }
                         // Leer la línea y procesar la información para obtener las caras
                         else if (line.StartsWith("f "))
                         {
                             string[] faceValues = line.Split(' ');
                             // Asumiendo que las caras están definidas con índices de vértices en formato "f v1 v2 v3"
                             int[] faceIndices = new int[3];
                             for (int i = 0; i < 3; i++)
                             {
                                 faceIndices[i] = int.Parse(faceValues[i + 1]) - 1; // Restar 1 para índices basados en 0
                             }
                             // Crear un objeto de la clase triangulo y asignar los índices y el color gris
                             triangulo face = new triangulo(faceIndices[0], faceIndices[1], faceIndices[2], Color.Gray);
                             faceList.Add(face);
                         }
                     }

                     vertices = vertexList.ToArray();
                     faces = faceList.ToArray();
                 }
                 foreach (var item in vertices)
                 {
                     Console.WriteLine(item);
                 }
                 cube = new Mesh(vertices, faces);
                 scena = new Scene[]{
                                new Scene(cube, new Transform(1f,new Vertex( 1,    1,    8 ), Matrix.Identity))
                                };

                 //canvas.Render(scena);
             }*/

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
            scena = new Scene[]{
                               new Scene(cube, new Transform(1f,new Vertex( 1,    1,    8 ), Matrix.Identity))
                               };
            canvas.Render(scena);

        }

        private void timer1_Tick(object sender, EventArgs j)
        {
            
            Draw();
            if (scena != null)
            {

                for (int i = 0; i < scena.Length; i++)
                {
                    scena[i].transform.scale = deltaY;
                    scena[i].transform.traslation.X = deltaX;
                }
                
            }
            if (RX == true)
            {
                for (int i = 0; i < scena.Length; i++)
                {
                    scena[i].transform.rotation = Matrix.RotX(angle++);
                }
            }
            if (RY == true)
            {
                for (int i = 0; i < scena.Length; i++)
                {
                    scena[i].transform.rotation = Matrix.RotY(angle++);
                }
            }
            if (RZ == true)
            {
                for (int i = 0; i < scena.Length; i++)
                {
                    scena[i].transform.rotation = Matrix.RotZ(angle++);
                }
            }
            pictureBox1.Invalidate();
        }


        public void Draw()
        {
            canvas.FastClear();
            canvas.Render(scena);
            if (filePath != null)
            {
                //canvas.Render(scena);
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
                deltaX += (float)(e.Location.X - ptX.X) / 300;
                ptX.X = e.Location.X;
            }
        }

        private void btnBuscarArchivo_Click_1(object sender, EventArgs e)
        {
            OpenObj = true;
        
            // Crear un nuevo cuadro de diálogo de selección de archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configurar propiedades del cuadro de diálogo
            openFileDialog.Title = "Buscar archivo";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Directorio inicial del cuadro de diálogo

            // Mostrar el cuadro de diálogo y obtener el resultado
            DialogResult result = openFileDialog.ShowDialog();

            // Verificar si el usuario seleccionó un archivo
            if (result == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                filePath = openFileDialog.FileName;
                // Realizar la lógica de procesamiento del archivo aquí
                MessageBox.Show("Archivo seleccionado: " + filePath);
            }
        }
    }
}
