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

        public Figures() {

            Vertices = new Vertex[]
            {
                new Vertex(-1, -1, -1),
                new Vertex(-1, -1, 1),
                new Vertex(1, -1, 1),
                new Vertex(1, -1, -1),
                new Vertex(-1, 1, -1),
                new Vertex(-1, 1, 1),
                new Vertex(1, 1, 1),
                new Vertex(1, 1, -1)
            };
        }



    }
}
