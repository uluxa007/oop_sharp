using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    class Matrix2 : Matrix
    {
        protected double[,] mat;
        protected int size;
        public Matrix2()
        {
            size = 2;
            mat = new double[size,size];
        }
        public double this[int x,int y]
        {
            get 
            {
                if (x >= 0 && x < size && y >= 0 && y < size) return mat[x, y];
                else throw new ArgumentException("out of range");
            }
            set
            {
                if (x >= 0 && x < size && y >= 0 && y < size) mat[x, y] = value;
                else throw new ArgumentException("out of range");
            }
        }
        public Matrix2(double a11,double a12,double a21, double a22)
        {
            size = 2;
            mat = new double[size, size];
            mat[0, 0] = a11;
            mat[0, 1] = a12;
            mat[1, 0] = a21;
            mat[1, 1] = a22;
        }

        public Matrix2(TextBox[,] boxes)
        {
            size = 2;
            mat = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    mat[i, j] = Convert.ToDouble(boxes[i, j].Text);
        }
        public void Show(TextBox[,] boxes)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    boxes[i, j].Text = mat[i, j].ToString();
        }

        public static Matrix2 operator +(Matrix2 mat1, Matrix2 mat2)
        {
            for(int i=0;i<2;i++)
                for(int j=0;j<2;j++)
                {
                    mat1[i, j] = mat1[i, j] + mat2[i, j];
                }
            return mat1;
        }
        public static Matrix2 operator *(Matrix2 mat, double t)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    mat[i, j] = mat[i, j] * t;
                }
            return mat;
        }
        public static Matrix2 operator *(double t, Matrix2 mat)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    mat[i, j] = mat[i, j] * t;
                }
            return mat;
        }
        public static Matrix2 operator -(Matrix2 mat1, Matrix2 mat2)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    mat1[i, j] = mat1[i, j] - mat2[i, j];
                }
            return mat1;
        }
        public static Vector2 operator *(Matrix2 mat, Vector2 vec)
        {
            Vector2 result = new Vector2();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    result[i] += mat[i, j] * vec[j];
                }
            return result;
        }
        public static Matrix2 operator *(Matrix2 mat1, Matrix2 mat2)
        {
            Matrix2 result = new Matrix2();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        result[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            return result;
        }
    }
}
