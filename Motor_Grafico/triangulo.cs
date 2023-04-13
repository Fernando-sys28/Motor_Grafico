using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    
    public class triangulo
    {
        public Vertex a { get; set; }
        public Vertex b { get; set; }
        public Vertex c { get; set; }

        public Color color;

        public static Vertex Luz = new Vertex(-3, -3, 0);
        float h;
        public triangulo(Vertex a, Vertex b, Vertex c, Color color)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.color = color;
        }

        public Vertex NormalTriangle(triangulo triangle)         
        {
            Vertex N = new Vertex(0, 0, 0);
            Vertex normal = CalculateNormal(triangle.b, triangle.a, triangle.c);
            Vertex camara = new Vertex(0, 0, -1);
            float normalize = (float)Math.Sqrt(DotProduct(normal, camara));

            N.X = normal.X / normalize;
            N.Y = normal.Y / normalize;
            N.Z = normal.Z / normalize;

            return N;
        }

        public float shadow(triangulo triangle)
        {
            Vertex N = new Vertex(0, 0, 0);
            Vertex normal = CalculateNormal(triangle.a, triangle.b, triangle.c);
            Vertex camara = new Vertex(0, 0, -1);
            float normalize = (float)Math.Sqrt(DotProduct(camara, normal));

            N.X = normal.X / normalize;
            N.Y = normal.Y / normalize;
            N.Z = normal.Z / normalize;

            float productoPunto = DotProduct(N, Luz);
            float longitudNormal = (float)Math.Sqrt(N.X * N.X + N.Y * N.Y + N.Z * N.Z);
            float longitudDireccion = (float)Math.Sqrt(Luz.X * Luz.X + Luz.Y * Luz.Y + Luz.Z * Luz.Z);
            h = (productoPunto / (longitudNormal * longitudDireccion) + 1) / 2;
            return h;
        }

        private Vertex CalculateNormal(Vertex a, Vertex b, Vertex c)
        {
            Vertex edge1 = new Vertex(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
            Vertex edge2 = new Vertex(c.X - a.X, c.Y - a.Y, c.Z - a.Z);

            float CrossX = edge1.Y * edge2.Z - edge1.Z * edge2.Y;
            float CrossY = edge1.Z * edge2.X - edge1.X * edge2.Z;
            float CrossZ = edge1.X * edge2.Y - edge1.Y * edge2.X;

            Vertex normal = new Vertex(CrossX, CrossY, CrossZ);
            return normal;
        }

        private float DotProduct(Vertex a, Vertex b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        }

    }
}
