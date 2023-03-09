using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Cylinder :Mesh
    {
        public Cylinder( float radius, float height, int numSegments) {
            Vertex center = new Vertex(0, 0, 0);
            float angle = 2 * (float)Math.PI / numSegments;
            Vertex apex = new Vertex(0, height / 2, 0);
            Vertex abajo = new Vertex(0, -height / 2, 0);
            for (int i = 0; i < numSegments; i++)
            {
                Vertex v1 = apex;
                Vertex v2 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), height / 2, radius * (float)Math.Sin((i - 1) * angle));
                Vertex v3 = new Vertex(radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                triangulos.Add(new triangulo(v2, v1, v3));
                Vertex v4 = abajo;
                Vertex v5 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                Vertex v6 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                triangulos.Add(new triangulo(v4, v5, v6));
                triangulos.Add(new triangulo(v5, v2, v3));
                triangulos.Add(new triangulo(v5, v3, v6));
            }
        }
    }
}
