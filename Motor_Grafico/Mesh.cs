using System;
using System.Collections.Generic;
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
        public Mesh(Vertex[] vertices, triangulo[] triangulos, Vertex bounds_center, float bounds_radius)
        {
            this.vertices = vertices;
            this.triangulos = triangulos;
            this.bounds_center = bounds_center;
            this.bounds_radius = bounds_radius;
        }

    }
}
