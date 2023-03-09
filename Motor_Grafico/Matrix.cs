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
        public Matrix() {
            
        }
        public static Vertex multiMatrix(Vertex vertice, float[,] M)
        {
            float x = (M[0, 0] * vertice.X) + (M[1, 0] * vertice.Y)  + (M[2, 0] * vertice.Z);
            float y = (M[0, 1] * vertice.X) + (M[1, 1] * vertice.Y)  + (M[2, 1] * vertice.Z);
            float z = (M[0, 2] * vertice.X) + (M[1, 2] * vertice.Y)  + (M[2, 2] * vertice.Z);

            return new Vertex(x,y,z);
        }

        
        public  float[,] RotationX(float angle)
        {      
            angle = convertirRadiantes(angle);
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationX= new float[3, 3] {
                {1, 0, 0},
                {0, cos, -sin},
                {0, sin, cos}
            };      
            return rotationX;
        }

        public  float[,] RotationY(float angle)
        {
            angle = convertirRadiantes(angle);
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationY = new float[3, 3] {
                {cos, 0, sin},
                {0, 1, 0},
                {-sin, 0, cos}
            };
            return rotationY;
        }

        public  float[,] RotationZ(float angle)
        {
            angle = convertirRadiantes(angle);
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float[,] rotationZ = new float[3, 3] {
                {cos, -sin, 0},
                {sin, cos, 0},
                {0, 0, 1}
            };
            return rotationZ;
        }


        public float convertirRadiantes(float angulo)
        {
            return angulo / 57.295f;
        }
    }
}
