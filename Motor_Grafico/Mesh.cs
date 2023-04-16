using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{   
    public class Mesh
    {

        public Vertex[] vertices;
        public triangulo[] triangulos;
        public Vertex bounds_center;
        public float bounds_radius;

        public Mesh(Vertex[] vertices, triangulo[] triangulos)
        {
            this.vertices = vertices;
            this.triangulos = triangulos;

        }
    }
}
