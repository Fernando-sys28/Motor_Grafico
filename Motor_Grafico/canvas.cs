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

        Camara camera = new Camara(new Vertex(1, 1, 1), Matrix.RotY(0));

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

        public void DrawLine(Vertex P0, Vertex P1, Color color)
        {

            if ((Math.Abs(P1.X - P0.X)) > (Math.Abs(P1.Y - P0.Y)))
            {
                if (P0.X > P1.X)
                {
                    Vertex temp = P0;
                    P0 = P1;
                    P1 = temp;
                }
                List<float> ys = Interpolate(P0.X, P0.Y, P1.X, P1.Y);

                for (float x = P0.X; x <= P1.X; x++)
                {
                    DrawPixel((int)x, (int)ys[(int)x - (int)P0.X], color);
                }
            }
            else
            {
                if (P0.Y > P1.Y)
                {
                    Vertex temp = P0;
                    P0 = P1;
                    P1 = temp;
                }
                List<float> xs = Interpolate(P0.Y, P0.X, P1.Y, P1.X);
                for (float y = P0.Y; y <= P1.Y; y++)
                {
                    DrawPixel((int)xs[(int)y - (int)P0.Y], (int)y, color);
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

        public void FillTriangle(PointF p0, PointF p1, PointF p2, Color c)
        {
            List<float> x_left;
            List<float> x_right;

            if (p1.Y < p0.Y)
            {
                PointF p = p0;
                p0 = p1;
                p1 = p;
            }
            if (p2.Y < p0.Y)
            {
                PointF p = p0;
                p0 = p2;
                p2 = p;
            }
            if (p2.Y < p1.Y)
            {
                PointF p = p2;
                p2 = p1;
                p1 = p;
            }

            List<float> x01 = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
            List<float> x12 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            List<float> x02 = Interpolate(p0.Y, p0.X, p2.Y, p2.X);

            x01.RemoveAt(x01.Count - 1);
            List<float> x012 = new List<float>();
            x012.AddRange(x01);
            x012.AddRange(x12);

            int m = x02.Count / 2;
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

            for (int y =(int)p0.Y; y < p2.Y; y++)
            {
                for (float x = x_left[(int)y - (int)p0.Y]; x < x_right[(int)y - (int)p0.Y]; x++)
                {
                    DrawPixel((int)x, y, c);      
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
        }


       public void RenderModel(Mesh mesh)
        {
            // we would have to test here the best fit to
            // translate this to the GPU for massive parallelism
            List<Vertex> projected = new List<Vertex>();
            //Mesh mesh = model.mesh;

            for (int i = 0; i < mesh.vertices.Length; i++)
            {
                projected.Add(ProjectVertex(mesh.vertices[i]));
            }

            for (int i = 0; i < mesh.triangulos.Length; i++)
            {
                RenderTriangle(mesh.triangulos[i], projected);
            }
        }

        private Vertex ApplyTransform(Vertex v, Transform transform)
        {
            Vertex vertex;
            vertex = new Vertex(v.X, v.Y, v.Z);
            vertex *= transform.scale;
            if (transform.rotation != null)
            {
                vertex= transform.rotation;
            }
            vertex += transform.traslation;
            return vertex;
        }

        // Clips a triangle against a plane. Adds output to triangles and vertices.
        private List<triangulo> ClipTriangle(triangulo triangle, Plane plane, List<triangulo> triangles, List<Vertex> vertices)
        {
            Vertex v0 = vertices[triangle.a];
            Vertex v1 = vertices[triangle.b];
            Vertex v2 = vertices[triangle.c];

            // vertices in front of the camera
            bool in0 = ((plane.normal * v0) + plane.Distance) > 0;
            bool in1 = ((plane.normal * v1) + plane.Distance) > 0;
            bool in2 = ((plane.normal * v2) + plane.Distance) > 0;

            int in_count = (in0 ? 1 : 0) + (in1 ? 1 : 0) + (in2 ? 1 : 0);

            if (in_count == 0)
            {
                //Console.WriteLine("count zero");
                // Nothing to do - the triangle is fully clipped out.
            }
            else if (in_count == 3)
            {
                // The triangle is fully in front of the plane.
                triangles.Add(triangle);
            }
            else if (in_count == 1)// one positive  
            {
                //Console.WriteLine("count one");
                // The triangle has one vertex in. Output is one clipped triangle.
            }
            else if (in_count == 2)// one negative
            {
                //Console.WriteLine("count two");
                // The triangle has two vertices in. Output is two clipped triangles.
            }

            return triangles;
        }

        private Mesh TransformAndClip(Plane[] clipping_planes, Mesh model, float scale, Vertex transform)
        {
            // Transform the bounding sphere, and attempt early discard.
            Vertex center = transform * model.bounds_center;
            float radius = model.bounds_radius * scale;
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                float distance = (clipping_planes[p].normal * center) + clipping_planes[p].Distance;
                if (distance < -radius)
                {
                    return null;
                }
            }

            // Apply modelview transform.
            List<Vertex> vertices = new List<Vertex>();
            for (int i = 0; i < model.vertices.Length; i++)
            {
                vertices.Add(transform * model.vertices[i]);
            }

            // Clip the entire model against each successive plane.
            List<triangulo> triangles = new List<triangulo>(model.triangulos);
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                List<triangulo> new_triangles = new List<triangulo>();
                for (int i = 0; i < triangles.Count; i++)
                {
                    new_triangles = (ClipTriangle(triangles[i], clipping_planes[p], new_triangles, vertices));
                }
                triangles.AddRange(new_triangles);
            }

            return new Mesh(vertices.ToArray(), triangles.ToArray(), center, model.bounds_radius);
        }

        public void RenderScene(Camara camera, Scene[] instances)
        {
            Matrix cameraMatrix;
            
            Mesh clipped;

            // if we want to use FOV here we also need to add the FOV matrix of the camera
            cameraMatrix = (camera.orientation.Transposed()) * Matrix.MakeTranslationMatrix(-camera.position);
            for (int i = 0; i < instances.Length; i++)
            {
                
                transform = (cameraMatrix * instances[i].transform);
                clipped = TransformAndClip(camera.clipping_planes.ToArray(), instances[i].mesh, instances[i].transform.scale, transform);

                if (clipped != null)
                {
                    RenderModel(clipped);
                }
            }
        }

    }
}
