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
        //public List<triangulo> triangulos;
        Matrix RotationX, RotationY, RotationZ;
        public Mesh(Vertex[] vertices, triangulo[] triangulos)
        {
            this.vertices = vertices;
            this.triangulos = triangulos;
            //m = new Matrix();
        }

       public Vertex RotateX(float angle, Vertex v){

            RotationX = Matrix.RotX(angle);
            Vertex vertice = v;
            vertice = RotationX * vertice;;

            return vertice;
        }

        /*public triangulo RotateY(float angle, triangulo t)
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
        }*/


    }
}
