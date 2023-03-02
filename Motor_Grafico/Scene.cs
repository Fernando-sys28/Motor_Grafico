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

            triangulo[] triangulos = new triangulo[12];
            triangulos[0]= new triangulo(a, b, c);
            triangulos[1] = new triangulo(a, c, d);
            triangulos[2] = new triangulo(e, a, d);
            triangulos[3] = new triangulo(e, d, h);
            triangulos[4] = new triangulo(f, e, h);
            triangulos[5] = new triangulo(f, h, g);
            triangulos[6] = new triangulo(b, f, g);
            triangulos[7] = new triangulo(b, g, c);
            triangulos[8] = new triangulo(e, f, b);
            triangulos[9] = new triangulo(e, b, a);
            triangulos[10] = new triangulo(c, g, h);
            triangulos[11] = new triangulo(c, h, d);
            
        }

    }
}
