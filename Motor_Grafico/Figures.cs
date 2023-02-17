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

            Vertices = new Vertex[8];
        }



        public void AddVertex(double x, double y, double z)
        {
            Vertices = new Vertex[]
            {
                new Vertex(x, y, z),
            } ;

            
        }

        /*public void Rotate(Matrix matrix)
        {
            foreach (Vertex vertex in vertices)
            {
                double[,] point = new double[,] { { vertex.X }, { vertex.Y }, { vertex.Z } };
                double[,] result = Matrix.MulMatrix(matrix, new Matrix(point));
                vertex.X = result[0, 0];
                vertex.Y = result[1, 0];
                vertex.Z = result[2, 0];
            }
        }*/

    }
}
