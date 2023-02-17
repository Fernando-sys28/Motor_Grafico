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

        public List<Vertex> vertices;

        public Figures() {

            vertices = new List<Vertex>();      
        }

        public void AddVertex(double x, double y, double z)
        {
            vertices.Add(new Vertex
            {
                X = x,
                Y = y,
                Z = z
               
            }) ;

            
        }

    }
}
