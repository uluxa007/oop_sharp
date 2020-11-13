using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    class Vector4 : Vector3
    {
        private double w;
        public double W
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }
        public Vector4() : base()
        {
            this.W = 0;
        }
        public Vector4(Vector4 vec) : base(vec.X,vec.Y,vec.Z)
        {
            this.W = vec.W;
        }
        public Vector4(double t) : base(t)
        {
            this.W = t;
        }
        public Vector4(double x,double y,double z, double t) : base(x,y,z)
        {
            this.W = t;
        }
        public Vector4(TextBox[,] boxes) : base(boxes)
        {
            this.W = Convert.ToDouble(boxes[0, 3].Text);
        }
        new public double this[int t]
        {
            get
            {
                switch (t)
                {
                    case 0:
                        {
                            return X;
                        }
                    case 1:
                        {
                            return Y;
                        }
                    case 2:
                        {
                            return Z;
                        }
                    case 3:
                        {
                            return W;
                        }
                    default:
                        {
                            throw new ArgumentException("out of range");
                        }
                }
            }
            set
            {
                switch (t)
                {
                    case 0:
                        {
                            X = value;
                            break;
                        }
                    case 1:
                        {
                            Y = value;
                            break;
                        }
                    case 2:
                        {
                            Z = value;
                            break;
                        }
                    case 3:
                        {
                            W = value;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("out of range");
                        }
                }
            }
        }
        public void Show(TextBox[,] boxes)
        {
            base.Show(boxes);
            boxes[0, 3].Text = W.ToString();
        }
        public static Vector4 operator +(Vector4 vec1, Vector4 vec2)
        {
            return new Vector4(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z,vec1.W + vec2.W);
        }
        public static Vector4 operator *(Vector4 vec, double t)
        {
            return new Vector4(vec.X * t, vec.Y * t, vec.Z * t, vec.W * t);
        }
        public static Vector4 operator *(double t, Vector4 vec)
        {
            return new Vector4(vec.X * t, vec.Y * t, vec.Z * t, vec.W * t);
        }
        public static Vector4 operator -(Vector4 vec1, Vector4 vec2)
        {
            return new Vector4(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z, vec1.W - vec2.W);
        }
    }
}
