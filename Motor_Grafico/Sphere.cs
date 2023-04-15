using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Sphere
    {
        public static Mesh SphereM(float radius, int numSegments) {

            List<Vertex> vertices = new List<Vertex>();
            List<triangulo> triangles = new List<triangulo>();

            for (int i = 0; i < numSegments + 1; i++)
            {
                float latitud0 = (float)Math.PI * (-0.5f + (float)(i - 1) / numSegments);
                float z = (float)Math.Sin(latitud0) * radius;
                float xz0 = (float)Math.Cos(latitud0) * radius;

                float latitud1 = (float)Math.PI * (-0.5f + (float)i / numSegments);
                float z1 = (float)Math.Sin(latitud1) * radius;
                float xz1 = (float)Math.Cos(latitud1) * radius;

                for (int j = 0; j < numSegments; j++)
                {
                    float longitud0 = (float)(2 * Math.PI * (float)(j - 1) / numSegments);
                    float x0 = (float)Math.Cos(longitud0) * xz0;
                    float y0 = (float)Math.Sin(longitud0) * xz0;

                    float latitu1 = (float)(2 * Math.PI * (float)j / numSegments);
                    float x1 = (float)Math.Cos(latitu1) * xz0;
                    float y1 = (float)Math.Sin(latitu1) * xz0;

                    float x2 = (float)Math.Cos(longitud0) * xz1;
                    float y2 = (float)Math.Sin(longitud0) * xz1;

                    float x3 = (float)Math.Cos(latitu1) * xz1;
                    float y3 = (float)Math.Sin(latitu1) * xz1;

                    Vertex v0 = new Vertex(x0, y0, z);
                    Vertex v1 = new Vertex(x1, y1, z);
                    Vertex v2 = new Vertex(x2, y2, z1);
                    Vertex v3 = new Vertex(x3, y3, z1);

                    if (i == 0) { }
                    else if (i == 1)
                    {
                        triangles.Add(new triangulo(0, 2, 1, Color.White));
                        triangles.Add(new triangulo(1, 2, 3, Color.White));
                    }
                    else
                    {
                        triangles.Add(new triangulo(vertices.Count, vertices.Count + 2, vertices.Count + 1, Color.White));
                        triangles.Add(new triangulo(vertices.Count + 1, vertices.Count + 2, vertices.Count, Color.White));
                    }

                    vertices.Add(v0);
                    vertices.Add(v1);
                    vertices.Add(v2);
                    vertices.Add(v3);
                }
            }
            Mesh mesh = new Mesh(vertices.ToArray(), triangles.ToArray());
            return mesh;
        }
    }
}
