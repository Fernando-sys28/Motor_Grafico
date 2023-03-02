using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    
    public class Scene
    {

        public Mesh mesh;

        public Scene()
        {
            mesh = new Mesh();
            createCube(mesh);
        }

        public void createCube(Mesh mesh)
        {
            Vertex a = new Vertex(1, 1, 1);
            Vertex b = new Vertex(-1, 1, 1);
            Vertex c = new Vertex(-1, -1, 1);
            Vertex d = new Vertex(1, -1, 1);
            Vertex e = new Vertex(1, 1, -1);
            Vertex f = new Vertex(-1, 1, -1);
            Vertex g = new Vertex(-1, -1, -1);
            Vertex h = new Vertex(1, -1, -1);

            Console.WriteLine(a.X);
            Console.WriteLine(a.Y);
            Console.WriteLine(a.Z);

            triangulo[] triangles = new triangulo[12];
            triangles[0]= new triangulo(a, b, c);
            triangles[1] = new triangulo(a, c, d);
            triangles[2] = new triangulo(e, a, d);
            triangles[3] = new triangulo(e, d, h);
            triangles[4] = new triangulo(f, e, h);
            triangles[5] = new triangulo(f, h, g);
            triangles[6] = new triangulo(b, f, g);
            triangles[7] = new triangulo(b, g, c);
            triangles[8] = new triangulo(e, f, b);
            triangles[9] = new triangulo(e, b, a);
            triangles[10] = new triangulo(c, g, h);
            triangles[11] = new triangulo(c, h, d);

            mesh.triangulos.AddRange(triangles);
            
        }

    }
}
