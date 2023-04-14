using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Camara
    {
        public Vertex position;
        public Matrix orientation;

        public Camara(Vertex position, Matrix orientation)
        {
            this.position = position;
            this.orientation = orientation;
        }

    }
}
