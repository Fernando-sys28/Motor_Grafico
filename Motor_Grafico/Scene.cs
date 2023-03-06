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
        Vertex center = new Vertex(0, 0, 0);
        float radius = 1F;
        float height = 2.5f;
        int numSegments = 12;
        int numLongitudes = 9;
        int numLatitudes = 9;

        public Scene()
        {
            mesh = new Mesh();
            //createCube(mesh);
            //createCone(center, radius, height, numSegments, mesh);
            //createPentagono(center, radius, height, 5, mesh);
            createCylinder(center, radius, height, numSegments, mesh);
            //CreateSphere(radius, numLongitudes, numLatitudes, mesh);
            //CreateSphereParallel(radius, numLongitudes, numLatitudes, mesh);
            //createIcosahedron(center, radius, mesh);
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
            // Create the base of the cone
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
            // Create the base of the cone
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

        public void CreateSphere(float radius, int numLongitudes, int numLatitudes, Mesh mesh)
        {
            mesh.triangulos.Clear();
            float latitudeAngleStep = (float)Math.PI / (numLatitudes + 1);
            float longitudeAngleStep = (2 * (float)Math.PI) / numLongitudes;

            // pre-calculate sine and cosine values for latitude angles
            float[] cosLatitudes = new float[numLatitudes + 2];
            float[] sinLatitudes = new float[numLatitudes + 2];
            for (int i = 0; i < numLatitudes + 2; i++)
            {
                float latitudeAngle = i * latitudeAngleStep;
                cosLatitudes[i] = (float)Math.Cos(latitudeAngle);
                sinLatitudes[i] = (float)Math.Sin(latitudeAngle);
            }

            // pre-calculate sine and cosine values for longitude angles
            float[] cosLongitudes = new float[numLongitudes];
            float[] sinLongitudes = new float[numLongitudes];
            for (int j = 0; j < numLongitudes; j++)
            {
                float longitudeAngle = j * longitudeAngleStep;
                cosLongitudes[j] = (float)Math.Cos(longitudeAngle);
                sinLongitudes[j] = (float)Math.Sin(longitudeAngle);
            }

            // create vertices and triangles
            Parallel.For(0, numLatitudes, i =>
            {
                int i1 = i + 1;
                int i2 = i + 2;
                float sinLat1 = sinLatitudes[i1];
                float cosLat1 = cosLatitudes[i1];
                float sinLat2 = sinLatitudes[i2];
                float cosLat2 = cosLatitudes[i2];

                for (int j = 0; j < numLongitudes; j++)
                {
                    int j1 = j % numLongitudes;
                    int j2 = (j + 1) % numLongitudes;
                    float sinLon1 = sinLongitudes[j1];
                    float cosLon1 = cosLongitudes[j1];
                    float sinLon2 = sinLongitudes[j2];
                    float cosLon2 = cosLongitudes[j2];

                    Vertex v1 = new Vertex(radius * sinLat1 * cosLon1, radius * sinLat1 * sinLon1, radius * cosLat1);
                    Vertex v2 = new Vertex(radius * sinLat1 * cosLon2, radius * sinLat1 * sinLon2, radius * cosLat1);
                    Vertex v3 = new Vertex(radius * sinLat2 * cosLon2, radius * sinLat2 * sinLon2, radius * cosLat2);
                    Vertex v4 = new Vertex(radius * sinLat2 * cosLon1, radius * sinLat2 * sinLon1, radius * cosLat2);

                    mesh.triangulos.Add(new triangulo(v1, v3, v2));
                    mesh.triangulos.Add(new triangulo(v1, v4, v3));
                }
            });
        }



        public void createIcosahedron(Vertex center, float radius, Mesh mesh)
        {
            float phi = (1 + (float)Math.Sqrt(5)) / 2;
            float a = radius / (float)Math.Sqrt(phi * phi + 1);
            float b = a * phi;

            Vertex[] vertices = new Vertex[12];
            vertices[0] = new Vertex(-a, 0, b);
            vertices[1] = new Vertex(a, 0, b);
            vertices[2] = new Vertex(-a, 0, -b);
            vertices[3] = new Vertex(a, 0, -b);
            vertices[4] = new Vertex(0, b, a);
            vertices[5] = new Vertex(0, b, -a);
            vertices[6] = new Vertex(0, -b, a);
            vertices[7] = new Vertex(0, -b, -a);
            vertices[8] = new Vertex(b, a, 0);
            vertices[9] = new Vertex(-b, a, 0);
            vertices[10] = new Vertex(b, -a, 0);
            vertices[11] = new Vertex(-b, -a, 0);

            int[][] faces = new int[20][];
            faces[0] = new int[] { 0, 4, 1 };
            faces[1] = new int[] { 0, 9, 4 };
            faces[2] = new int[] { 9, 5, 4 };
            faces[3] = new int[] { 4, 5, 8 };
            faces[4] = new int[] { 4, 8, 1 };
            faces[5] = new int[] { 8, 10, 1 };
            faces[6] = new int[] { 8, 3, 10 };
            faces[7] = new int[] { 5, 3, 8 };
            faces[8] = new int[] { 5, 2, 3 };
            faces[9] = new int[] { 2, 7, 3 };
            faces[10] = new int[] { 7, 10, 3 };
            faces[11] = new int[] { 7, 6, 10 };
            faces[12] = new int[] { 7, 11, 6 };
            faces[13] = new int[] { 11, 0, 6 };
            faces[14] = new int[] { 0, 1, 6 };
            faces[15] = new int[] { 6, 1, 10 };
            faces[16] = new int[] { 9, 0, 11 };
            faces[17] = new int[] { 9, 11, 2 };
            faces[18] = new int[] { 9, 2, 5 };
            faces[19] = new int[] { 7, 2, 11 };

            for (int i = 0; i < faces.Length; i++)
            {
                int[] face = faces[i];
                Vertex v1 = vertices[face[0]];
                Vertex v2 = vertices[face[1]];
                Vertex v3 = vertices[face[2]];
                mesh.triangulos.Add(new triangulo(v3, v1, v2));
            }
        }

        public void CreateSphereParallel(float radius, int numLongitudes, int numLatitudes, Mesh mesh)
        {
            float longitudeStep = 2 * (float)Math.PI / numLongitudes;
            float latitudeStep = (float)Math.PI / numLatitudes;

            // Define the vertices
            List<Vertex> vertices = new List<Vertex>();
            Parallel.For(0, numLatitudes + 1, i =>
            {
                float latitude = (float)Math.PI / 2 - i * latitudeStep;
                float y = radius * (float)Math.Sin(latitude);
                float xz = radius * (float)Math.Cos(latitude);

                for (int j = 0; j <= numLongitudes; j++)
                {
                    float longitude = j * longitudeStep;
                    float x = xz * (float)Math.Cos(longitude);
                    float z = xz * (float)Math.Sin(longitude);

                    lock (vertices)
                    {
                        vertices.Add(new Vertex(z, y, x));
                    }
                }
            });

            // Define the triangles
            Parallel.For(0, numLatitudes, i =>
            {
                for (int j = 0; j < numLongitudes; j++)
                {
                    int first = i * (numLongitudes + 1) + j;
                    int second = first + 1;
                    int third = first + numLongitudes + 1;
                    int fourth = third + 1;

                    lock (mesh.triangulos)
                    {
                        mesh.triangulos.Add(new triangulo(vertices[first], vertices[third], vertices[second]));
                        mesh.triangulos.Add(new triangulo(vertices[third], vertices[fourth], vertices[first]));
                    }
                }
            });
        }

        public void CreateSphere2(float radius, int numLongitudes, int numLatitudes, Mesh mesh)
        {
            float longitudeStep = 2 * (float)Math.PI / numLongitudes;
            float latitudeStep = (float)Math.PI / numLatitudes;

            // Define the vertices
            List<Vertex> vertices = new List<Vertex>();

            // Parallelize the creation of vertices
            Parallel.For(0, numLatitudes + 1, i => {
                float latitude = (float)Math.PI / 2 - i * latitudeStep;
                float y = radius * (float)Math.Sin(latitude);
                float xz = radius * (float)Math.Cos(latitude);

                for (int j = 0; j <= numLongitudes; j++)
                {
                    float longitude = j * longitudeStep;
                    float x = xz * (float)Math.Cos(longitude);
                    float z = xz * (float)Math.Sin(longitude);

                    vertices.Add(new Vertex(x, y, z));
                }
            });

            // Define the triangles
            // Parallelize the creation of triangles
            Parallel.For(0, numLatitudes, i => {
                for (int j = 0; j < numLongitudes; j++)
                {
                    int first = i * (numLongitudes + 1) + j;
                    int second = first + 1;
                    int third = first + numLongitudes + 1;
                    int fourth = third + 1;

                    mesh.triangulos.Add(new triangulo(vertices[first], vertices[third], vertices[second]));
                    mesh.triangulos.Add(new triangulo(vertices[second], vertices[third], vertices[fourth]));
                }
            });
        }


    }
}
