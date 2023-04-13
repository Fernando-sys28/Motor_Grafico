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
        public Matrix rotation;
        public Scene(Mesh mesh, Matrix rotation=null)
        {
            this.mesh= mesh;
            this.rotation = rotation ?? Matrix.Identity;
        }
    }
}
