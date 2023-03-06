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
            //createCube(mesh);
            //createCone(center, radius, height, numSegments, mesh);
            //createPentagono(center, radius, height, 5, mesh);
            //createCylinder(center, radius, height, numSegments, mesh);
            //createSphere(radiusC, numSegmentsC, mesh);
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

        public void createCone(Vertex center, float radius, float height, int numSegments, Mesh mesh)
        {
            // Create the base of the cone
            for (int i = 0; i < numSegments; i++)
            {
                float angle1 = 2 * (float)Math.PI * i / numSegments;
                float angle2 = 2 * (float)Math.PI * (i + 1) / numSegments;

                Vertex v1 = new Vertex(center.X + radius * (float)Math.Cos(angle1), center.Y + radius * (float)Math.Sin(angle1), center.Z);
                Vertex v2 = new Vertex(center.X + radius * (float)Math.Cos(angle2), center.Y + radius * (float)Math.Sin(angle2), center.Z);
                Vertex v3 = center;

                mesh.triangulos.Add(new triangulo(v2,v1,v3));
            }

            // Create the sides of the cone
            Vertex apex = new Vertex(center.X, center.Y, center.Z + height);
            for (int i = 0; i < numSegments; i++)
            {
                double angle1 = 2 * Math.PI * i / numSegments;
                double angle2 = 2 * Math.PI * (i + 1) / numSegments;

                Vertex v1 = new Vertex(center.X + radius * (float)Math.Cos(angle1), center.Y + radius * (float)Math.Sin(angle1), center.Z);
                Vertex v2 = new Vertex(center.X + radius * (float)Math.Cos(angle2), center.Y + radius * (float)Math.Sin(angle2), center.Z);
                Vertex v3 = apex;

                mesh.triangulos.Add(new triangulo(v1,v2,v3));
            }
        }

        public void createPentagono(Vertex center, float radius, float height, int numSegments, Mesh mesh)
        {
            float angle = 2 * (float)Math.PI / numSegments;
            Vertex apex = new Vertex(0, height / 2, 0);
            Vertex abajo = new Vertex(0, -height / 2, 0);
            for (int i = 0; i < numSegments; i++)
            { 
                Vertex v1 = apex;
                Vertex v2 = new Vertex( radius * (float)Math.Cos((i-1)* angle), height / 2, radius * (float)Math.Sin((i-1)*angle));
                Vertex v3 = new Vertex( radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                mesh.triangulos.Add(new triangulo(v2, v1, v3));
                Vertex v4 = abajo;
                Vertex v5 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                Vertex v6 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                mesh.triangulos.Add(new triangulo(v4, v5, v6));
                mesh.triangulos.Add(new triangulo(v5, v2, v3));
                mesh.triangulos.Add(new triangulo(v5, v3, v6));
            }
        }

        public void createCylinder(Vertex center, float radius, float height, int numSegments, Mesh mesh)
        {
            float angle = 2 * (float)Math.PI / numSegments;
            Vertex apex = new Vertex(0, height / 2, 0);
            Vertex abajo = new Vertex(0, -height / 2, 0);
            for (int i = 0; i < numSegments; i++)
            {
                Vertex v1 = apex;
                Vertex v2 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), height / 2, radius * (float)Math.Sin((i - 1) * angle));
                Vertex v3 = new Vertex(radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                mesh.triangulos.Add(new triangulo(v2, v1, v3));
                Vertex v4 = abajo;
                Vertex v5 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                Vertex v6 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                mesh.triangulos.Add(new triangulo(v4, v5, v6));
                mesh.triangulos.Add(new triangulo(v5, v2, v3));
                mesh.triangulos.Add(new triangulo(v5, v3, v6));
            }
        }
        public void createSphere(float radius, int numSegments, Mesh mesh)
        {
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
                        mesh.triangulos.Add(new triangulo(v3, v2, v1));

                    else
                        mesh.triangulos.Add(new triangulo(v0, v1, v2));

                }
            }
        }
    }
}
