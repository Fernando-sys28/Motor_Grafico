using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    
    public class Matrix
    {
        private double[,] _values;
        public Matrix(double[,] values) {
            _values = values;
        }

        public static Matrix Identity()
        {
            return new Matrix(new double[,]
            {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
            });
        }

        public  Matrix MulMatrix(Matrix m1, Matrix m2)
        {
            double[,] M1 = m1._values;
            double[,] M2 = m2._values;

            double[,] result = new double[3, 1];

            for (int i = 0; i < 3; i++)
            {
                result[i, 0] = 0;

                for (int j = 0; j < 3; j++)
                {
                    result[i, 0] += M1[i, j] * M1[j, 0];
                }
            }
            return new Matrix(result);
        }

        public Matrix RotationX(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            return new Matrix( new double[,]
            {
                {1, 0, 0},
                {0, cos, -sin},
                {0, sin, cos}
            });
        }

        public  Matrix RotationY(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            return new Matrix(new double[,]
            {
                {cos, 0, sin},
                {0, 1, 0},
                {-sin, 0, cos}
            });
        }

        public static Matrix RotationZ(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            return new Matrix(new double[,]
            {
                {cos, -sin, 0},
                {sin, cos, 0},
                {0, 0, 1}
            });
        }

    }
}
