using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    
    public class Scene
    {

        public static List<Figures> Figures = new List<Figures>();
        public Scene(Figures figura)
        {
            Figures.Add(figura);

        }
    }
}
