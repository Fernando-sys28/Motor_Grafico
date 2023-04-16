using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Grafico
{
   public class Scene
    {
        public Mesh mesh;
        public Vertex position;
        public Matrix orientation;

        public Transform transform;

        public Scene(Mesh mesh, Transform transform)
        {
            this.mesh= mesh;
            this.transform = transform;

        }

        
    }
}
