using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Transform
    {
        public float scale;
        public Vertex traslation;
        public Matrix rotation { get; set; }
        public Transform(float scale, Vertex traslation)
        {
            this.scale = scale;
            this.traslation = traslation;
        }

        public Transform(float scale, Vertex traslation,Matrix rotation=null)
        {
            this.scale = scale;
            this.rotation = rotation ?? Matrix.Identity; ;
            this.traslation = traslation;
        }

        public Matrix transform()
        {
            Matrix m= Matrix.MakeTranslationMatrix(this.traslation) * this.rotation * Matrix.MakeScalingMatrix(this.scale);
            return m;
        }
    }
}
