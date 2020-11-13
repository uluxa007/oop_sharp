using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    class Matrix3 : Matrix2
    {
        public Matrix3()
        {
            size = 3;
            mat = new double[3, 3];
        }
        public Matrix3(double a11, double a12, double a13, double a21, double a22, double a23, double a31, double a32, double a33)
        {
            size = 3;
            mat = new double[size, size];
            mat[0, 0] = a11;
            mat[0, 1] = a12;
            mat[0, 2] = a13;
            mat[1, 0] = a21;
            mat[1, 1] = a22;
            mat[1, 2] = a23;
            mat[2, 0] = a31;
            mat[2, 1] = a32;
            mat[2, 2] = a33;
        }
        public Matrix3(TextBox[,] boxes)
        {
            size = 4;
            mat = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    mat[i, j] = Convert.ToDouble(boxes[i, j].Text);
        }

        public static Matrix3 operator +(Matrix3 mat1, Matrix3 mat2)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    mat1[i, j] = mat1[i, j] + mat2[i, j];
                }
            return mat1;
        }
        public static Matrix3 operator *(Matrix3 mat, double t)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    mat[i, j] = mat[i, j] * t;
                }
            return mat;
        }
        public static Matrix3 operator *(double t, Matrix3 mat)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    mat[i, j] = mat[i, j] * t;
                }
            return mat;
        }
        public static Matrix3 operator -(Matrix3 mat1, Matrix3 mat2)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    mat1[i, j] = mat1[i, j] - mat2[i, j];
                }
            return mat1;
        }
        public static Vector3 operator *(Matrix3 mat, Vector3 vec)
        {
            Vector3 result = new Vector3();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    result[i] += mat[i, j] * vec[j];
                }
            return result;
        }
        public static Matrix3 operator *(Matrix3 mat1, Matrix3 mat2)
        {
            Matrix3 result = new Matrix3();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        result[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            return result;
        }
    }
}
