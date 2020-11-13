using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    class Vector3 : Vector2
    {
        private double z;
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public Vector3() : base()
        {
            this.Z = 0;
        }
        public Vector3(Vector3 vec) : base(vec.X, vec.Y)
        {
            this.Z = vec.Z;
        }
        public Vector3(double t) : base(t)
        {
            this.Z = t;
        }
        public Vector3(double x, double y, double z) : base(x, y)
        {
            this.Z = z;
        }
        public Vector3(TextBox[,] boxes) : base(boxes)
        {
            this.Z = Convert.ToDouble(boxes[0, 2].Text);
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
            boxes[0, 2].Text = Z.ToString();
        }
        override public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }
        public static Vector3 operator *(Vector3 vec, double t)
        {
            return new Vector3(vec.X * t, vec.Y * t, vec.Z * t);
        }
        public static Vector3 operator *(double t, Vector3 vec)
        {
            return new Vector3(vec.X * t, vec.Y * t, vec.Z * t);
        }
        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

    }
}
