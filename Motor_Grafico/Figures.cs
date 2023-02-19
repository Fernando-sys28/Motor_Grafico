using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Figures
    {

        public Vertex[] Vertices;

        public Figures(Vertex[] inputVertices) {

            Vertices = inputVertices;
        }


        public void ImprimirVertices()
        {
            foreach (Vertex v in Vertices)
            {
                Console.WriteLine("({0}, {1}, {2})", v.X, v.Y, v.Z);
            }
        }

    }
}
