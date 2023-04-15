using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Management.Instrumentation;
using static System.Windows.Forms.AxHost;

namespace Motor_Grafico
{
    public class Canvas
    {
        public Bitmap bitmap;
        public int Width, Height;
        public Byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;
        float viewport_size = 1;
        float projection_plane_z = 1;

        float[,] m;

        public Camara camera = new Camara(new Vertex(0, 0, 0), Matrix.RotY(0));
        public bool pintar { get; set; }
        public Canvas(Size size)
        {
            init(size.Width, size.Height);
        }

        public void init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;
            pintar = false;
            format = PixelFormat.Format32bppRgb;
            //bitmap= new Bitmap(width, height);
            Width = width;
            Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8;
            stride = width * pixelFormatSize;
            padding = (stride % 4);
            stride += padding == 0 ? 0 : 4 - padding;
            bits = new byte[stride * height];
            handle = GCHandle.Alloc(bitmap, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bitmap = new Bitmap(width, height, stride, format, bitPtr);
            g = Graphics.FromImage(bitmap);

            
        }

        public void Render(Scene[] scena)
        {
            RenderScene(camera, scena);
        }
        public Matrix POV()
        {
            float a = 120; // aperture DEGREES
            float r = 1; // aspecto ratio
            float zNear = 1f;
            float zFar = 10000;
            float fov = (float)((Math.PI / 180) * (a));//aperture rads
            float tanHalfFOV = (float)Math.Tan(fov / 2);
            float zRange = zNear - zFar;
            float f = 1.0f / tanHalfFOV;
            float q = (zNear + zFar) / zRange;
            m = new float[,]{
                            {f*r, 0 , 0 , 0 },
                            {0 , f , 0 , 0 },
                            {0 , 0 , -q , 2*zNear*q },
                            {0 , 0 , 1 , 0 }
};
            return new Matrix(m);
        }

        public void setPixel(int x, int y, Color c)
        {
            long res = (int)((x * pixelFormatSize) + (y * stride));

            bits[res + 0] = c.B;// (byte)Blue;
            bits[res + 1] = c.G;// (byte)Green;
            bits[res + 2] = c.R;// (byte)Red;
            bits[res + 3] = c.A;// (byte)Alpha;
        }

        public void DrawPixel(int x, int y, Color color)
        {
            x = Width / 2 + x;
            y = Height / 2 - y - 1;

            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }

            setPixel(x, y, color);
        }


        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0;// (byte)oldBlue;
                        bits[x + 1] = 0;// (byte)oldGreen;
                        bits[x + 2] = 0;// (byte)oldRed;
                        bits[x + 3] = 0;// (byte)alpha;
                    }
                });
                bitmap.UnlockBits(bitmapData);
            }
        }
        private void Swap(ref Vertex a, ref Vertex b)
        {
            Vertex temp = a;
            a = b;
            b = temp;
        }

        void DrawLine(Vertex p0, Vertex p1, Color color)
        {
            var dx = p1.X - p0.X;
            var dy = p1.Y - p0.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // The line is horizontal-ish. Make sure it's left to right.
                if (dx < 0)
                {
                    Swap(ref p0, ref p1);
                }

                // Compute the Y values and draw.
                var ys = Interpolate((int)p0.X, p0.Y, (int)p1.X, p1.Y);
                for (var x = (int)p0.X; x <= p1.X; x++)
                {
                    DrawPixel(x, (int)ys[(x - (int)p0.X)], color);
                }
            }
            else
            {
                // The line is vertical-ish. Make sure it's bottom to top.
                if (dy < 0)
                {
                    Swap(ref p0, ref p1);
                }

                // Compute the X values and draw.
                var xs = Interpolate((int)p0.Y, p0.X, (int)p1.Y, p1.X);
                for (var y = (int)p0.Y; y <= p1.Y; y++)
                {
                    DrawPixel((int)xs[(y - (int)p0.Y)], y, color);
                }
            }
        }

        public void DrawWireFrameTriangle(Vertex p0, Vertex p1, Vertex p2, Color color)
        {
            DrawLine(p0, p1, color); 
            DrawLine(p1, p2, color);
            DrawLine(p2, p0, color);
        }

        public List<float> Interpolate(float i0, float d0, float i1, float d1)
        {
            List<float> values = new List<float>();
            if (i0 == i1)
            {
                values.Add(d0);
                return values;
            }
            float a = ((float)d1 - (float)d0) / ((float)i1 - (float)i0);
            float d = d0;
            for (int i = (int)i0; i <= i1; i++)
            {
                values.Add(d);
                d = d + a;
            }
            return values;
        }

        public void FillTriangle(Vertex p0, Vertex p1, Vertex p2, Color c)
        {
            List<float> x_left;
            List<float> x_right;

            if (p1.Y < p0.Y)
            {
                Vertex p = p0;
                p0 = p1;
                p1 = p;
            }
            if (p2.Y < p0.Y)
            {
                Vertex p = p0;
                p0 = p2;
                p2 = p;
            }
            if (p2.Y < p1.Y)
            {
                Vertex p = p2;
                p2 = p1;
                p1 = p;
            }

            List<float> x01 = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
            List<float> x12 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            List<float> x02 = Interpolate(p0.Y, p0.X, p2.Y, p2.X);

            //x01.RemoveAt(x01.Count - 1);
            List<float> x012 = new List<float>();
            x012.AddRange(x01);
            x012.AddRange(x12);

            int m = x02.Count / 2;
            if (m >= 0 && m < x02.Count && m < x012.Count)
            {
                if (x02[m] < x012[m])
                {
                    x_left = x02;
                    x_right = x012;
                }
                else
                {
                    x_left = x012;
                    x_right = x02;
                }

                for (var y = (int)p0.Y; y < p2.Y; y++)
                {
                    int index = y - (int)p0.Y;
                    if (index >= 0 && index < x_left.Count && index < x_right.Count)
                    {
                        for (var x = x_left[index]; x < x_right[index]; x++)
                        {
                            DrawPixel((int)x, y, c);
                        }
                    }
                }
            }

            
        }

        public void DrawShadedTriangle(PointF a, PointF b, PointF d, Color c)
        {
            Point p0 = new Point(), p1 = new Point(), p2 = new Point();
            p0.X = (int)a.X;
            p0.Y = (int)a.Y;
            p1.X = (int)b.X;
            p1.Y = (int)b.Y;
            p2.X = (int)d.X;
            p2.Y = (int)d.Y;

            List<float> x_left;
            List<float> x_right;
            List<float> h_left;
            List<float> h_right;

            if (p1.Y < p0.Y)
            {
                Point p = p0;
                p0 = p1;
                p1 = p;
            }
            if (p2.Y < p0.Y)
            {
                Point p = p0;
                p0 = p2;
                p2 = p;
            }
            if (p2.Y < p1.Y)
            {
                Point p = p2;
                p2 = p1;
                p1 = p;
            }

            List<float> x01 = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
            List<float> x12 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            List<float> x02 = Interpolate(p0.Y, p0.X, p2.Y, p2.X);

            List<float> h01 = Interpolate(p0.Y, 1, p1.Y, 0);
            List<float> h12 = Interpolate(p1.Y, 0, p2.Y, 0);
            List<float> h02 = Interpolate(p0.Y, 1, p2.Y, 0);

            x01.RemoveAt(x01.Count - 1);
            List<float> x012 = new List<float>();
            x012.AddRange(x01);
            x012.AddRange(x12);

            h01.RemoveAt(h01.Count - 1);
            List<float> h012 = new List<float>();
            h012.AddRange(h01);
            h012.AddRange(h12);

            int m = x02.Count / 2;
            if (x02[m] < x012[m])
            {
                x_left = x02;
                x_right = x012;

                h_left = h02;
                h_right = h012;
            }
            else
            {
                x_left = x012;
                x_right = x02;

                h_left = h012;
                h_right = h02;
            }

            for (int y = p0.Y; y < p2.Y; y++)
            {
                float x_l = x_left[y - p0.Y];
                float x_r = x_right[y - p0.Y];
                List<float> h_segment = Interpolate(x_l, h_left[y - p0.Y], x_r, h_right[y - p0.Y]);
                for (float x = x_left[y - p0.Y]; x < x_right[y - p0.Y]; x++)
                {
                    Color shaded_color = Color.FromArgb((int)(c.R * h_segment[(int)(x - x_l)]), (int)(c.G * h_segment[(int)(x - x_l)]), (int)(c.B * h_segment[(int)(x - x_l)]));
                    DrawPixel((int)x, y, shaded_color);
                }
            }

        }


        // Converts 2D viewport coordinates to 2D canvas coordinates.
        Vertex ViewportToCanvas(Vertex p2d)
        {
            float vW = (float)bitmap.Width / bitmap.Height;      
            return new Vertex((p2d.X * bitmap.Width / vW), (p2d.Y * bitmap.Height / viewport_size), 0);
        }

        public Vertex ProjectVertex(Vertex v)
        {
            return ViewportToCanvas(new Vertex(v.X * projection_plane_z  / (v.Z), v.Y * projection_plane_z/ (v.Z), 0));
        }

        public void RenderTriangle(triangulo triangle, List<Vertex> projected)
        {
            DrawWireFrameTriangle(projected[triangle.a], projected[triangle.b], projected[triangle.c], triangle.color);

            if (pintar)
            {
                FillTriangle(projected[triangle.a], projected[triangle.b], projected[triangle.c],Color.LightBlue);          
            }
        }


       public void RenderModel(Mesh model, Matrix transform)
        {
            // we would have to test here the best fit to
            // translate this to the GPU for massive parallelism
            List<Vertex> projected = new List<Vertex>();

            for (int i = 0; i < model.vertices.Length; i++)
            {
                projected.Add(ProjectVertex(transform * model.vertices[i]));
            }

            for (int i = 0; i < model.triangulos.Length; i++)
            {
                RenderTriangle(model.triangulos[i], projected);
            }
        }


        public void RenderScene(Camara camera, Scene[] instances)
        {
            Matrix cameraMatrix;
            Matrix transform;

            // if we want to use FOV here we also need to add the FOV matrix of the camera
            cameraMatrix = (camera.orientation.Transposed()) * Matrix.MakeTranslationMatrix(-camera.position) * POV();
            for (int i = 0; i < instances.Length; i++)
            {
                transform = (cameraMatrix * instances[i].transform.transform());

                RenderModel(instances[i].mesh, transform);
            }
        }

    }
}
