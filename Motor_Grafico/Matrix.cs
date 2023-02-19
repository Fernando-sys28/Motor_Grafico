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
        public static Vertex multiMatrix(Vertex vertice, double[,] M)
        {
            double x= (M[0, 0] * vertice.X) + (M[1, 0] * vertice.Y)  + (M[2, 0] * vertice.Z);
            double y = (M[0, 1] * vertice.X) + (M[1, 1] * vertice.Y) + (M[2, 1] * vertice.Z);
            double z = (M[0, 2] * vertice.X) + (M[1, 2] * vertice.Y) + (M[2, 2] * vertice.Z);

            return new Vertex(x,y,z);
        }

        public static Vertex multiVector(Vertex v1, Vertex v2, Vertex v3)
        {
            double x = v1.X * v2.X * v3.X + v1.Y * v2.Y * v3.Y  + v1.Z * v2.Z* v3.Z ;
            double y = v1.X * v2.X * v3.X + v1.Y * v2.Y * v3.Y  + v1.Z * v2.Z* v3.Z ;
            double z = v1.X * v2.X * v3.X + v1.Y * v2.Y * v3.Y  + v1.Z * v2.Z* v3.Z ;

            return new Vertex(x, y, z);
        }

        public static double[,] RotationX(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double[,] rotationX= new double[3, 3] {
                {1, 0, 0},
                {0, cos, -sin},
                {0, sin, cos}
            };
            return rotationX;
        }

        public static double[,] RotationY(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double[,] rotationY = new double[3, 3] {
                {cos, 0, sin},
                {0, 1, 0},
                {-sin, 0, cos}
            };
            return rotationY;
        }

        public static double[,] RotationZ(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double[,] rotationZ = new double[3, 3] {
                {cos, -sin, 0},
                {sin, cos, 0},
                {0, 0, 1}
            };
            return rotationZ;
        }

    }
}
