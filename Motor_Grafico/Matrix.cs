using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    
    public class Matrix
    {
        private double[,] matrix_values;
        public Matrix(double[,] matrix) {
               matrix_values = matrix;
        }
        public static Vertex multiMatrix(Vertex vertice, float[,] M)
        {
            float x = (M[0, 0] * vertice.X) + (M[0, 1] * vertice.Y)  + (M[0, 2] * vertice.Z);
            float y = (M[1, 0] * vertice.X) + (M[1, 1] * vertice.Y)  + (M[1, 2] * vertice.Z);
            float z = (M[2, 0] * vertice.X) + (M[2, 1] * vertice.Y)  + (M[2, 2] * vertice.Z);

            return new Vertex(x,y,z);
        }

        
        public static float[,] RotationX(float angle)
        {

            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationX= new float[3, 3] {
                {1, 0, 0},
                {0, cos, -sin},
                {0, sin, cos}
            };      
            return rotationX;
        }

        public static float[,] RotationY(float angle)
        {

            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationY = new float[3, 3] {
                {cos, 0, sin},
                {0, 1, 0},
                {-sin, 0, cos}
            };
            return rotationY;
        }

        public static float[,] RotationZ(float angle)
        {

            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationZ = new float[3, 3] {
                {cos, -sin, 0},
                {sin, cos, 0},
                {0, 0, 1}
            };
            return rotationZ;
        }

    }
}
