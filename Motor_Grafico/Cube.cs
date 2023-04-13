using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Cube : Mesh
    {

        public Cube() {

            Vertex a = new Vertex(1, 1, 1);
            Vertex b = new Vertex(-1, 1, 1);
            Vertex c = new Vertex(-1, -1, 1);
            Vertex d = new Vertex(1, -1, 1);
            Vertex e = new Vertex(1, 1, -1);
            Vertex f = new Vertex(-1, 1, -1);
            Vertex g = new Vertex(-1, -1, -1);
            Vertex h = new Vertex(1, -1, -1);

            triangulo[] triangles = new triangulo[12];
            triangles[0] = new triangulo(a, b, c, Color.Red);
            triangles[1] = new triangulo(a, c, d, Color.Red);
            triangles[2] = new triangulo(e, a, d,Color.Green);
            triangles[3] = new triangulo(e, d, h, Color.Green);
            triangles[4] = new triangulo(f, e, h, Color.Blue);
            triangles[5] = new triangulo(f, h, g, Color.Blue);
            triangles[6] = new triangulo(b, f, g, Color.Yellow);
            triangles[7] = new triangulo(b, g, c, Color.Yellow);
            triangles[8] = new triangulo(e, f, b, Color.Purple);
            triangles[9] = new triangulo(e, b, a, Color.Purple);
            triangles[10] = new triangulo(c, g, h, Color.Cyan);
            triangles[11] = new triangulo(c, h, d, Color.Cyan);

            triangulos.AddRange(triangles);

        }
    }
}
