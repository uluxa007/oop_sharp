using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    class Matrix4 : Matrix3
    {
        public Matrix4()
        {
            size = 4;
            mat = new double[4, 4];
        }
        public Matrix4(double a11, double a12, double a13, double a14, double a21, double a22, double a23, double a24, double a31, double a32, double a33, double a34, double a41, double a42, double a43, double a44) : base( a11,  a12,  a13,  a21,  a22,  a23,  a31,  a32, a33)
        {
            size = 4;
            mat = new double[size, size];

            mat[0, 3] = a14;
            mat[1, 3] = a24;
            mat[2, 3] = a34;

            mat[3, 0] = a41;
            mat[3, 1] = a42;
            mat[3, 2] = a43;
            mat[3, 3] = a44;
        }
        public Matrix4(TextBox[,] boxes)
        {
            size = 4;
            mat = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    mat[i, j] = Convert.ToDouble(boxes[i, j].Text);
        }

        public static Matrix4 operator +(Matrix4 mat1, Matrix4 mat2)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    mat1[i, j] = mat1[i, j] + mat2[i, j];
                }
            return mat1;
        }
        public static Matrix4 operator *(Matrix4 mat, double t)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    mat[i, j] = mat[i, j] * t;
                }
            return mat;
        }
        public static Matrix4 operator *(double t, Matrix4 mat)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    mat[i, j] = mat[i, j] * t;
                }
            return mat;
        }
        public static Vector4 operator *(Matrix4 mat, Vector4 vec)
        {
            Vector4 result = new Vector4();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    result[i] += mat[i, j] * vec[j];
                }
            return result;
        }
        public static Matrix4 operator -(Matrix4 mat1, Matrix4 mat2)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    mat1[i, j] = mat1[i, j] - mat2[i, j];
                }
            return mat1;
        }
        public static Matrix4 operator *(Matrix4 mat1, Matrix4 mat2)
        {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        result[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            return result;
        }
    }
}
