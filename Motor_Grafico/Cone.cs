﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Cone
    {
        public static Mesh ConeM( float radius, float height, int numSegments) {

            List<Vertex> vertices = new List<Vertex>();
            List<triangulo> triangles = new List<triangulo>();

            Vertex center = new Vertex(0, 0, 0);
            for (int i = 0; i < numSegments; i++)
            {
                float angle1 = 2 * (float)Math.PI * i / numSegments;
                float angle2 = 2 * (float)Math.PI * (i + 1) / numSegments;

                Vertex v1 = new Vertex(center.X + radius * (float)Math.Cos(angle1), center.Y + radius * (float)Math.Sin(angle1), center.Z);
                Vertex v2 = new Vertex(center.X + radius * (float)Math.Cos(angle2), center.Y + radius * (float)Math.Sin(angle2), center.Z);
                Vertex v3 = center;

                vertices.Add(v2);
                vertices.Add(v1);
                vertices.Add(v3);

                int index1 = (i * 3) + 2;
                int index2 = (i * 3) + 1;
                int index3 = (i * 3);

                triangles.Add(new triangulo(index1, index2, index3,Color.White));
            }

            Vertex apex = new Vertex(center.X, center.Y, center.Z + height);
            for (int i = 0; i < numSegments; i++)
            {
                float angle1 = 2 * (float)Math.PI * i / numSegments;
                float angle2 = 2 * (float)Math.PI * (i + 1) / numSegments;

                Vertex v1 = new Vertex(center.X + radius * (float)Math.Cos(angle1), center.Y + radius * (float)Math.Sin(angle1), center.Z);
                Vertex v2 = new Vertex(center.X + radius * (float)Math.Cos(angle2), center.Y + radius * (float)Math.Sin(angle2), center.Z);
                Vertex v3 = apex;

                vertices.Add(v1);
                vertices.Add(v2);
                vertices.Add(v3);

                int index1 = (numSegments * 3) + (i * 3);
                int index2 = (numSegments * 3) + (i * 3) + 1;
                int index3 = (numSegments * 3) + (i * 3) + 2;

                triangles.Add(new triangulo(index1, index2, index3, Color.White));
            }

            Mesh mesh = new Mesh(vertices.ToArray(), triangles.ToArray());
            return mesh;
        }   
    }
}
