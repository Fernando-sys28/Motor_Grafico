﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }



        public PointF ConvertToPointF(double x, double y, double z)
        {
            return new PointF((float)x, (float)y);

        }
    }

}