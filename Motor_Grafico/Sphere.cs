using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Sphere:Mesh
    {
        public Sphere(float radius, int numSegments) {
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
                        triangulos.Add(new triangulo(v1, v3, v2));
                    }
                    else
                    {
                        triangulos.Add(new triangulo(v3, v2, v1));
                        triangulos.Add(new triangulo(v2, v0, v1));
                    }
                }
            }
        }
    }
}
