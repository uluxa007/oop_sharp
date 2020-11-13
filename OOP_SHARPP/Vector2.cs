using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    struct Point
    {
        public Point(double x,double y)
        {
            this.X= x;
            this.Y= y;
        }
        public double Y
        {
            get
            {
                return this.Y;
            }
            set
            {
                this.Y= value;
            }
        }
        public double X
        {
            get
            {
                return this.X;
            }
            set
            {
                this.X= value;
            }
        }
    }
    class Vector2 : Vector
    {

        private double x;
        private double y;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Vector2()
        {
            this.X= 0;
            this.Y= 0;
        }

        public Vector2(Vector2 vec)
        {
            this.X= vec.X;
            this.Y= vec.Y;
        }

        public Vector2(double t)
        {
            this.X= t;
            this.Y= t;
        }

        public Vector2(double x,double y)
        {
            this.X= x;
            this.Y= y;
        }
        public Vector2(TextBox[,] boxes)
        {
            this.X = Convert.ToDouble(boxes[0, 0].Text);
            this.Y = Convert.ToDouble(boxes[0, 1].Text);
        }
        public double this[int t]
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
                    default:
                        {
                            throw new ArgumentException("out of range");
                        }
                }
            }
        }
        public void Show(TextBox[,] boxes)
        {
            boxes[0, 0].Text = X.ToString();
            boxes[0, 1].Text = Y.ToString();
        }

        override public double Length()
        {
            return Math.Sqrt(X* X+ Y* Y);
        }

        public static Vector2 operator+(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.X+ vec2.X, vec1.Y+ vec2.Y);
        }

        public static Vector2 operator *(Vector2 vec, double t)
        {
            return new Vector2(vec.X* t, vec.Y* t);
        }

        public static Vector2 operator *(double t, Vector2 vec)
        {
            return new Vector2(vec.X* t, vec.Y* t);
        }

        public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.X- vec2.X, vec1.Y- vec2.Y);
        }
        public static Vector2 operator *(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.X - vec2.X, vec1.Y - vec2.Y);
        }


        public override string ToString()
        {
            return "("+X+";"+Y+")";
        }

        public Point Add(Vector2 vec,Point point)
        {
            return new Point(vec.X+point.X,vec.X+point.Y);
        }

        public double angleWith(Vector2 vec)
        {
            double up = (vec.X* this.X+ vec.Y* this.Y);
            double down = (vec.Length() * this.Length());
            return (Math.Acos(up/down)/Math.PI)*180;
        }

    }
}
