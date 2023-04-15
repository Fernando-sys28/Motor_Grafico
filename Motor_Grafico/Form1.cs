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
        TreeNode selectedNode;
        Scene selectedScene;

        Mesh mesh;
        public bool RX = false;
        public bool RY = false;
        public bool RZ = false;

        bool mouseDown = false;
        bool mouseDownY = false;
        Point ptX, ptY;
        float deltaX = 0;
        float deltaY = 1;

        float CamaraX = 0;
        float CamaraY = 0;
        float CamaraZ = 0;

        float TrasladarY = 0;
        float TrasladarZ = 8;

        float angle = 0;

        string filePath;
        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(pictureBox1.Size);
            pictureBox1.Image = canvas.bitmap;
        }

        private void timer1_Tick(object sender, EventArgs j)
        {
            
            Draw();
            if (scena != null)
            {
                canvas.camera.position.X = CamaraX;
                canvas.camera.position.Y = CamaraY;
                canvas.camera.position.Z = CamaraZ;
                if(selectedScene != null)
                {
                    selectedScene.transform.scale = deltaY;
                    selectedScene.transform.traslation.X = deltaX;
                    selectedScene.transform.traslation.Y = TrasladarY;
                    selectedScene.transform.traslation.Z = TrasladarZ;
                }
                
                
            }
            if (RX == true)
            {
                selectedScene.transform.rotation = Matrix.RotX(angle++);
            }
            if (RY == true)
            {
                selectedScene.transform.rotation = Matrix.RotY(angle++);
            }
            if (RZ == true)
            {
                selectedScene.transform.rotation = Matrix.RotZ(angle++);
            }
            if (RX == true && RY == true && RZ == true)
            {
                Matrix combinedRotation = Matrix.RotX(angle) * Matrix.RotY(angle) * Matrix.RotZ(angle);
                selectedScene.transform.rotation = combinedRotation;
                angle++;
            }
            pictureBox1.Invalidate();
        }


        public void Draw()
        {
           
            if (mesh != null)
            {
                canvas.FastClear();
                canvas.Render(scena);
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
        private void ReadOBJ()
        {
            Vertex[] vertices;
            triangulo[] faces;

            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Vertex> vertexList = new List<Vertex>();
                List<triangulo> faceList = new List<triangulo>();

                // Reiniciar el lector del archivo para volver a leer desde el principio
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                reader.DiscardBufferedData();
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
                    else if (line.StartsWith("f "))
                    {
                        string[] faceValues = line.Split(' ');
                        int[] faceIndices = new int[3];
                        for (int j = 0; j < 3; j++)
                        {
                            string[] vertexIndexValues = faceValues[j + 1].Split('/');
                            faceIndices[j] = int.Parse(vertexIndexValues[0]) - 1; // Restar 1 para índices basados en 0
                        }
                        // Crear un objeto de la clase triangulo y asignar los índices y el color gris
                        triangulo face = new triangulo(faceIndices[0], faceIndices[1], faceIndices[2], Color.White);
                        faceList.Add(face);
                    }
                }

                vertices = vertexList.ToArray();
                faces = faceList.ToArray();
            }
            NuevoMesh(vertices, faces);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Mesh cubo;
            cubo= Cube.Cubo();

            NuevoMesh(cubo.vertices, cubo.triangulos);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Mesh cylinder;
            cylinder = Cylinder.CylinderMesh(1f, 2.5f, 10);

            NuevoMesh(cylinder.vertices, cylinder.triangulos);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Mesh sphere;
            sphere = Sphere.SphereM(2f, 30);

            NuevoMesh(sphere.vertices, sphere.triangulos);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mesh cone;
            cone = Cone.ConeM(1f, 2f, 15);

            NuevoMesh(cone.vertices, cone.triangulos);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Mesh cylinder;
            cylinder = Cylinder.CylinderMesh(1f, 2.5f, 5);

            NuevoMesh(cylinder.vertices, cylinder.triangulos);

        }

        private void Form1_Load(object sender, EventArgs e)
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
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            traslationsXScroll.Value = 0; //Regresa al centro cuando lo soltemos
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

        private void escalarScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            escalarScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                canvas.pintar = true;
            }
            else
            {
                canvas.pintar = false;
            }
        }
       
        private void btnBuscarArchivo_Click_1(object sender, EventArgs e)
        {  
            // Crear un nuevo cuadro de diálogo de selección de archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configurar propiedades del cuadro de diálogo
            openFileDialog.Title = "Buscar archivo";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Directorio inicial del cuadro de diálogo

            // Mostrar el cuadro de diálogo y obtener el resultado
            DialogResult result = openFileDialog.ShowDialog();

            // Obtener la ruta del archivo seleccionado
            filePath = openFileDialog.FileName;

            ReadOBJ();
        }

        private void camaraYScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void camaraYScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                CamaraY += (float)(ptY.Y - e.Location.Y) / 300;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void camaraYScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            camaraYScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void camaraZScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void camaraZScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                CamaraZ += (float)(ptY.Y - e.Location.Y) / 300;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void camaraZScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            camaraZScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void traslationsYScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void traslationsYScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                TrasladarY += (float)(ptY.Y - e.Location.Y) / 300;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void traslationsYScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            traslationsYScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void traslationsZScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            mouseDownY = true;
        }

        private void traslationsZScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownY)
            {
                TrasladarZ += (float)(ptY.Y - e.Location.Y) / 300;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void traslationsZScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownY = false;
            traslationsZScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }

        private void camaraXScroll_MouseDown(object sender, MouseEventArgs e)
        {
            ptX = e.Location;
            mouseDown = true;
        }

        private void camaraXScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                CamaraX += (float)(e.Location.X - ptX.X) / 300;
                ptX.X = e.Location.X;
            }
        }

        private void camaraXScroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            camaraXScroll.Value = 0; //Regresa al centro cuando lo soltemos
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = e.Node;
            selectedScene = (Scene)selectedNode.Tag;

        }
        private void NuevoMesh(Vertex[] vertices, triangulo[] triangulos)
        {
            mesh = new Mesh(vertices, triangulos);

            // Verificar si scena es null y, en ese caso, inicializarlo con un arreglo vacío
            if (scena == null)
            {
                scena = new Scene[0];
            }
            // Redimensionar el arreglo de escenas (Scene[]) para incluir el nuevo mesh
            Array.Resize(ref scena, scena.Length + 1);

            // Asignar el nuevo mesh al último índice del arreglo
            scena[scena.Length - 1] = new Scene(mesh, new Transform(1f, new Vertex(0, 0, 8), Matrix.Identity));

            if (scena != null)
            {
                // Cargar escenas en el TreeView
                TreeNode rootNode = new TreeNode("Escenas");
                for (int i = 0; i < scena.Length; i++)
                {
                    TreeNode node = new TreeNode("Escena " + (i + 1));
                    node.Tag = scena[i]; // Guardar una referencia a la escena en la propiedad Tag del nodo
                    rootNode.Nodes.Add(node);
                }
                treeView1.Nodes.Add(rootNode);
            }

            canvas.Render(scena);
        }
    }
}
