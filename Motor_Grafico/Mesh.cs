using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{   
    public class Mesh
    {
        Matrix m;
        public List<triangulo> triangulos;
        float[,] RotationX, RotationY, RotationZ;
        public Mesh()
        {
            triangulos = new List<triangulo>();
            m = new Matrix();
        }

        public triangulo RotateX(float angle, triangulo t){

            RotationX = m.RotationX(angle);
            triangulo triangle = t;

            Vertex vertexA = triangle.a;
            Vertex vertexB = triangle.b;
            Vertex vertexC = triangle.c;

            vertexA = Matrix.multiMatrix(vertexA, RotationX);
            vertexB = Matrix.multiMatrix(vertexB, RotationX);
            vertexC = Matrix.multiMatrix(vertexC, RotationX);

            triangle.a = vertexA;
            triangle.b = vertexB;
            triangle.c = vertexC;

            return triangle;
        }

        public triangulo RotateY(float angle, triangulo t)
        {
            RotationY = m.RotationY(angle);
            triangulo triangle = t;

            Vertex vertexA = triangle.a;
            Vertex vertexB = triangle.b;
            Vertex vertexC = triangle.c;

            vertexA = Matrix.multiMatrix(vertexA, RotationY);
            vertexB = Matrix.multiMatrix(vertexB, RotationY);
            vertexC = Matrix.multiMatrix(vertexC, RotationY);

            triangle.a = vertexA;
            triangle.b = vertexB;
            triangle.c = vertexC;

            return triangle;
        }

        public triangulo RotateZ(float angle, triangulo t)
        {
            RotationZ = m.RotationZ(angle);
            triangulo triangle = t;

            Vertex vertexA = triangle.a;
            Vertex vertexB = triangle.b;
            Vertex vertexC = triangle.c;

            vertexA = Matrix.multiMatrix(vertexA, RotationZ);
            vertexB = Matrix.multiMatrix(vertexB, RotationZ);
            vertexC = Matrix.multiMatrix(vertexC, RotationZ);

            triangle.a = vertexA;
            triangle.b = vertexB;
            triangle.c = vertexC;

            return triangle;
        }


    }
}
